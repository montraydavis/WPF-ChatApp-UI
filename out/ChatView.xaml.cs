using Microsoft.Extensions.DependencyInjection;
using QNAGen.Models;
using QNAGen.Workflows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace QNAGen.Views
{
    /// <summary>
    /// Interaction logic for ChatView.xaml
    /// </summary>
    public partial class ChatView : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the ChatView class.
        /// </summary>
        private readonly IWorkflowHost _workflowHost;
        private readonly IPersistenceProvider _persistenceProvider;

        /// <summary>
        /// Gets or sets the collection of chat messages.
        /// </summary>
        public ObservableCollection<ChatMessage> ChatMessages { get; set; }

        private bool _isInputEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether input is enabled.
        /// </summary>
        public bool IsInputEnabled
        {
            get => _isInputEnabled;
            set
            {
                if (_isInputEnabled != value)
                {
                    _isInputEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isLoading;
        /// <summary>
        /// Gets or sets a value indicating whether the chat is loading.
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged();
                    AITypingIndicator.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Event handler for property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Initializes the ChatView and sets up the workflow host and persistence provider.
        /// </summary>
        public ChatView()
        {
            InitializeComponent();

            var serviceProvider = ((App)Application.Current).ServiceProvider;
            _workflowHost = serviceProvider.GetRequiredService<IWorkflowHost>();
            _persistenceProvider = serviceProvider.GetRequiredService<IPersistenceProvider>();

            ChatMessages = new ObservableCollection<ChatMessage>();
            chatListBox.ItemsSource = ChatMessages;
            DataContext = this;
        }

        /// <summary>
        /// Handles the click event for the Accept button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage(true);
        }

        /// <summary>
        /// Handles the click event for the Deny button.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            await SendMessage(false);
        }

        /// <summary>
        /// Sends a message to the AI assistant and handles the response.
        /// </summary>
        /// <param name="isAccepted">Indicates if the message should be accepted.</param>
        private async Task SendMessage(bool isAccepted)
        {
            string userMessage = userInputTextBox.Text;
            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                IsInputEnabled = false;
                IsLoading = true;

                AddMessage(userMessage, true);
                userInputTextBox.Clear();

                ScrollToBottom();

                var workflowData = new SQLGenerationData
                {
                    UserPrompt = userMessage
                };

                var workflowId = await _workflowHost.StartWorkflow("sql-generation-workflow", 1, workflowData);

                // Wait for the workflow to complete
                await Task.Run(async () =>
                {
                    while (true)
                    {
                        var instance = await _persistenceProvider.GetWorkflowInstance(workflowId);
                        if (instance.Status == WorkflowStatus.Complete || instance.Status == WorkflowStatus.Terminated)
                        {
                            workflowData = (SQLGenerationData)instance.Data;
                            break;
                        }
                        await Task.Delay(100);
                    }
                });

                string aiResponse = isAccepted ? workflowData.FinalResponse : "Your message has been denied. Please try again.";

                AddMessage(aiResponse, false);

                IsLoading = false;
                IsInputEnabled = true;
                ScrollToBottom();
            }
        }

        /// <summary>
        /// Scrolls to the bottom of the chat list box.
        /// </summary>
        private void ScrollToBottom()
        {
            var scrollViewer = GetDescendantByType<ScrollViewer>(chatListBox);
            scrollViewer?.ScrollToBottom();
        }

        /// <summary>
        /// Adds a new chat message to the chat messages collection.
        /// </summary>
        /// <param name="message">The message content.</param>
        /// <param name="isUser">Indicates if the message is from the user.</param>
        private void AddMessage(string message, bool isUser)
        {
            ChatMessages.Add(new ChatMessage { Message = message, IsUser = isUser });
        }

        /// <summary>
        /// Finds a descendant of a specified type within a visual tree.
        /// </summary>
        /// <typeparam name="T">The type to search for.</typeparam>
        /// <param name="element">The root element of the visual tree.</param>
        /// <returns>The first descendant of type T, or null if not found.</returns>
        private static T GetDescendantByType<T>(Visual element) where T : class
        {
            if (element == null) return null;
            if (element is T) return element as T;
            T foundElement = null;
            if (element is FrameworkElement)
            {
                (element as FrameworkElement).ApplyTemplate();
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
                foundElement = GetDescendantByType<T>(visual);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }
    }
}