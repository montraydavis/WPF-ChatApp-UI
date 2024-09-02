using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace QNAGen.Controls
{
    /// <summary>
    /// Interaction logic for TypingIndicator.xaml
    /// </summary>
    public partial class TypingIndicator : UserControl
    {
        /// <summary>
        /// The Storyboard that contains the animation to be played when the control is loaded.
        /// This property holds a reference to the "BounceAnimation" resource in the XAML file.
        /// </summary>
        private Storyboard bounceAnimation;

        /// <summary>
        /// Initializes a new instance of the TypingIndicator class. 
        /// This constructor sets up event handlers for the Loaded and Unloaded events, initializing the animation property.
        /// </summary>
        public TypingIndicator()
        {
            InitializeComponent();
            
            // Retrieve the "BounceAnimation" resource from XAML file
            bounceAnimation = (Storyboard)FindResource("BounceAnimation");
            
            // Set up event handlers for Loaded and Unloaded events
            Loaded += TypingIndicator_Loaded;
            Unloaded += TypingIndicator_Unloaded;
        }

        /// <summary>
        /// Event handler that is called when the control is loaded. 
        /// This method starts the animation by calling StartAnimation() method.
        /// </summary>
        private void TypingIndicator_Loaded(object sender, RoutedEventArgs e)
        {
            StartAnimation();
        }

        /// <summary>
        /// Event handler that is called when the control is unloaded. 
        /// This method stops the animation by calling StopAnimation() method.
        /// </summary>
        private void TypingIndicator_Unloaded(object sender, RoutedEventArgs e)
        {
            StopAnimation();
        }

        /// <summary>
        /// Method that starts the animation by beginning the Storyboard.
        /// </summary>
        public void StartAnimation()
        {
            bounceAnimation.Begin();
        }

        /// <summary>
        /// Method that stops the animation by stopping the Storyboard.
        /// </summary>
        public void StopAnimation()
        {
            bounceAnimation.Stop();
        }
    }
}
