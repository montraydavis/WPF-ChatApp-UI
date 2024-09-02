using System.Windows;
using System.Windows.Controls;

namespace QNAGen.Controls
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class AppSideBar : UserControl
    {


        /// <summary>
        /// Initializes a new instance of the AppSideBar class. This method is called when a new instance of the AppSideBar user control is created. It calls InitializeComponent(), which loads the XAML markup for this control and associates it with the AppSideBar class in the object hierarchy.
        /// </summary>
        public AppSideBar()
        {
            InitializeComponent();
            SidebarColumn.Width = new GridLength(EXPANDED_WIDTH);
        }

        private const double EXPANDED_WIDTH = 200;
        private const double COLLAPSED_WIDTH = 50;

        /// <summary>
        /// This method is called when the checkbox controlling the sidebar toggle is checked. It sets the width of the SidebarColumn to 0, effectively hiding it.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the CheckBox).</param>
        /// <param name="e">Event arguments containing information about the routed event.</param>
        private void SidebarToggle_Checked(object sender, RoutedEventArgs e)
        {
            SidebarColumn.Width = new GridLength(COLLAPSED_WIDTH);
        }

        /// <summary>
        /// This method is called when the checkbox controlling the sidebar toggle is unchecked. It sets the width of the SidebarColumn to 100, effectively showing it again.
        /// </summary>
        /// <param name="sender">The object that triggered the event (the CheckBox).</param>
        /// <param name="e">Event arguments containing information about the routed event.</param>
        private void SidebarToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            SidebarColumn.Width = new GridLength(EXPANDED_WIDTH);
        }
    }
}
