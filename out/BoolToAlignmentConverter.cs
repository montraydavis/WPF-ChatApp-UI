using System;
using System.Windows;
using System.Windows.Data;

namespace QNAGen.Converters
{
    /// <summary>
    /// Converter that converts a boolean value to a HorizontalAlignment value. 
    /// If the input is true, it returns Right alignment; otherwise, it returns Left alignment.
    /// </summary>
    public class BoolToAlignmentConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a HorizontalAlignment value. 
        /// If the input is true, it returns Right alignment; otherwise, it returns Left alignment.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The type of the binding target property. Not used in this converter.</param>
        /// <param name="parameter">Additional parameter to be used for conversion. Not used in this converter.</param>
        /// <param name="culture">Culture information. Not used in this converter.</param>
        /// <returns>Right if the input is true, Left otherwise.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        /// <summary>
        /// Not implemented for this converter. Throws a NotImplementedException if called.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
