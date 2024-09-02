using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows;
using System.Windows.Controls;

namespace QNAGen.Views
{
    /// <summary>
    /// Interaction logic for QNAView.xaml
    /// </summary>
    public partial class QNAView : UserControl
    {
        public QNAView()
        {
            InitializeComponent();
            InitializeAvalonEdit();
        }

        private void InitializeAvalonEdit()
        {
            // Set up SQL syntax highlighting
            SqlEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("SQL");

            // You can add more customization for AvalonEdit here
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle submit action
            string userPrompt = UserPromptTextBox.Text;
            string sqlCode = SqlEditor.Text;
            // Process the input and generated SQL
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle deny action
            // This could reset the view or trigger a regeneration
        }

        private void SkipButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle skip action
            // This could move to the next question or task
        }

        /// <summary>
        /// Initialize AvalonEdit with custom styles
        /// </summary>
        /// <remarks>
        /// This method sets up SQL syntax highlighting and applies styles from resources.
        /// </remarks>
        private void InitializeAvalonEdit()
        {
            // Set up SQL syntax highlighting
            SqlEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("SQL");

            // Apply styles from resources
            SqlEditor.Background = (SolidColorBrush)Application.Current.Resources["SecondaryBackgroundBrush"];
            SqlEditor.Foreground = (SolidColorBrush)Application.Current.Resources["PrimaryTextBrush"];

            // You can add more customization for AvalonEdit here if needed
        }
    }
}
