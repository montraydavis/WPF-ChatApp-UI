using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QNAGen.Converters
{
    /// <summary>
    /// Converter class that converts between SolidColorBrush and Color.
    /// </summary>
    public class ColorToColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a SolidColorBrush to a Color.
        /// </summary>
        /// <param name="value">The input value, expected to be a SolidColorBrush.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional conversion parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A Color object representing the color of the brush, or Colors.Transparent if the input is not a SolidColorBrush.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color;
            }
            return Colors.Transparent;
        }

        /// <summary>
        /// Converts a Color back to a SolidColorBrush.
        /// </summary>
        /// <param name="value">The input value, expected to be a Color.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional conversion parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A SolidColorBrush object representing the color, or a new SolidColorBrush with transparent color if the input is not a Color.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                return new SolidColorBrush(color);
            }
            return new SolidColorBrush(Colors.Transparent);
        }
    }
}
