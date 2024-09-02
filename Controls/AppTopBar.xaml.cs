using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace QNAGen.Controls
{
    /// <summary>
    /// Interaction logic for AppTopBar.xaml
    /// </summary>
    public partial class AppTopBar : UserControl
    {
        public AppTopBar()
        {
            InitializeComponent();
            QNAButton.IsChecked = true; // Set QNA as default selected tab
        }

        public event EventHandler<string> TabChanged;

        private void QNA_Checked(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "QNA");
        }

        private void Chat_Checked(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "Chat");
        }

        private void Settings_Checked(object sender, RoutedEventArgs e)
        {
            TabChanged?.Invoke(this, "Settings");
        }
    }
}
