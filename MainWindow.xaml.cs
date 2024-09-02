using QNAGen.Views;
using System;
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

            var fadeOutAnimation = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(0.3));
            var fadeInAnimation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(0.3));

            fadeOutAnimation.Completed += (s, e) =>
            {
                _currentView.Visibility = Visibility.Collapsed;
                newView.Visibility = Visibility.Visible;
                _currentView = newView;

                newView.BeginAnimation(OpacityProperty, fadeInAnimation);
            };

            _currentView.BeginAnimation(OpacityProperty, fadeOutAnimation);
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