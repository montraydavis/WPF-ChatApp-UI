using System;
using System.Windows.Data;
using System.Windows.Media;

namespace QNAGen.Converters
{
    /// <summary>
    /// Converter class that converts a boolean value to a SolidColorBrush object, 
    /// which is used for color representation in WPF applications. The colors are defined as RGB values:
    /// (64, 65, 79) for user messages and (68, 70, 84) for AI messages.
    /// </summary>
    public class BoolToColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a SolidColorBrush object. If the input is true, 
        /// it returns a color with RGB values (64, 65, 79), otherwise it returns a color with RGB values (68, 70, 84).
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The type of the binding target property. This parameter is not used in this method.</param>
        /// <param name="parameter">Additional information about how to perform the conversion. This parameter is not used in this method.</param>
        /// <param name="culture">The culture of the conversion. This parameter is not used in this method.</param>
        /// <returns>A SolidColorBrush object representing the input boolean value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value
                ? new SolidColorBrush(Color.FromRgb(64, 65, 79))   // Lighter color for user messages
                : new SolidColorBrush(Color.FromRgb(68, 70, 84));  // Existing color for AI messages
        }

        /// <summary>
        /// Not implemented in this converter as it is not needed.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
