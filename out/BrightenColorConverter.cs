using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace QNAGen.Converters
{
    /// <summary>
    /// Converter class that brightens a given color.
    /// </summary>
    public class BrightenColorConverter : IValueConverter
    {
        /// <summary>
        /// Converts a SolidColorBrush to a brighter version by increasing RGB values.
        /// </summary>
        /// <param name="value">The input value, expected to be a SolidColorBrush.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">An optional conversion parameter.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A new SolidColorBrush with brightened color, or the original value if not a SolidColorBrush.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                Color color = brush.Color;
                return new SolidColorBrush(Color.FromArgb(color.A,
                    (byte)Math.Min(255, color.R + 30),
                    (byte)Math.Min(255, color.G + 30),
                    (byte)Math.Min(255, color.B + 30)));
            }
            return value;
        }

        /// <summary>
        /// Converts a value back to its source type.
        /// </summary>
        /// <remarks>
        /// This method is not implemented and will throw a NotImplementedException if called.
        /// </remarks>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Not applicable as this method always throws an exception.</returns>
        /// <exception cref="NotImplementedException">This method is not implemented.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
