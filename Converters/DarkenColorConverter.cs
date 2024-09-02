using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QNAGen.Converters
{
    /// <summary>
    public class DarkenColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a SolidColorBrush to a darker version by decreasing RGB values.
        /// </summary>
        /// <param name="value">The input value, expected to be a SolidColorBrush.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional conversion parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A new SolidColorBrush with darkened color, or the original value if not a SolidColorBrush.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                Color color = brush.Color;
                return new SolidColorBrush(Color.FromArgb(color.A,
                    (byte)Math.Max(0, color.R - 30),
                    (byte)Math.Max(0, color.G - 30),
                    (byte)Math.Max(0, color.B - 30)));
            }
            return value;
        }

        /// <summary>
        /// Not implemented for this converter. Throws a NotImplementedException if called.
        /// </summary>
        /// <exception cref="NotImplementedException">This method is not implemented and will always throw this exception.</exception>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Not applicable as this method always throws an exception.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
