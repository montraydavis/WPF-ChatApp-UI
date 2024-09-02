using QNAGen.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QNAGen
{
    public partial class MainWindow : Window
    {
        private UserControl _currentView;

        public MainWindow()
        {
            InitializeComponent();
            _currentView = QNAView;

        }

        private void TopBar_TabChanged(object sender, string e)
        {
            switch (e)
            {
                case "QNA":
                    SwitchToView(QNAView);
                    break;
                case "Chat":
                    SwitchToView(ChatView);
                    break;
                case "Settings":
                    SwitchToView(SettingsView);
                    break;
            }
        }

        private void SwitchToView(UserControl newView)
        {
            if (_currentView == newView) return;

            var fadeOutStoryboard = (Storyboard)FindResource("FadeOut");
            var fadeInStoryboard = (Storyboard)FindResource("FadeIn");

            fadeOutStoryboard.Completed += (s, e) =>
            {
                _currentView.Visibility = Visibility.Collapsed;
                newView.Visibility = Visibility.Visible;
                _currentView = newView;

                fadeInStoryboard.Begin(newView);
            };

            fadeOutStoryboard.Begin(_currentView);
        }

        public void ShowExportPopup()
        {
            PopupOverlay.Visibility = Visibility.Visible;
        }

        private void ExportPopup_CloseRequested(object sender, System.EventArgs e)
        {
            PopupOverlay.Visibility = Visibility.Collapsed;
        }

        private void ExportPopup_ConfirmRequested(object sender, System.EventArgs e)
        {
            // Handle export confirmation
            MessageBox.Show("Export confirmed!");
            PopupOverlay.Visibility = Visibility.Collapsed;
        }

        private void PopupOverlay_Loaded(object sender, RoutedEventArgs e)
        {

            ShowExportPopup();
        }
    }
}