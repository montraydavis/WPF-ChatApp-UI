using System;
using System.Windows;
using System.Windows.Controls;

namespace QNAGen.Controls
{
    /// <summary>
    /// Interaction logic for AppTopBar.xaml
    /// </summary>
    public partial class AppTopBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppTopBar"/> class.
        /// This is the constructor for this user control, which initializes the component and sets up event handlers for tab changes.
        /// </summary>
        public AppTopBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event that is fired when a new tab has been selected. The string argument indicates the name of the newly selected tab.
        /// </summary>
        public event EventHandler<string> TabChanged;

        /// <summary>
        /// Handles the Click event for the QNA button. When clicked, it fires the TabChanged event with "QNA" as argument.
        /// </summary>
        private void QNA_Click(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "QNA");
        }

        /// <summary>
        /// Handles the Click event for the Chat button. When clicked, it fires the TabChanged event with "Chat" as argument.
        /// </summary>
        private void Chat_Click(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "Chat");
        }

        /// <summary>
        /// Handles the Click event for the Settings button. When clicked, it fires the TabChanged event with "Settings" as argument.
        /// </summary>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "Settings");
            TabChanged?.Invoke(this, "Settings");
        }
    }
}
