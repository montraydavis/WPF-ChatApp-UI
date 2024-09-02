using System;
using System.Windows;
using System.Windows.Controls;

namespace QNAGen.Controls
{
    public partial class StylePopup : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(StylePopup), new PropertyMetadata(""));

        public static readonly DependencyProperty ConfirmButtonTextProperty =
            DependencyProperty.Register("ConfirmButtonText", typeof(string), typeof(StylePopup), new PropertyMetadata("Confirm"));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string ConfirmButtonText
        {
            get { return (string)GetValue(ConfirmButtonTextProperty); }
            set { SetValue(ConfirmButtonTextProperty, value); }
        }

        public event EventHandler CloseRequested;
        public event EventHandler ConfirmRequested;

        public StylePopup()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}