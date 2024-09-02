using System;
using System.Windows.Data;

namespace QNAGen.Converters
{
    /// <summary>
    /// Converter that converts a boolean value to a string label.
    /// If the input is true, it returns "User"; otherwise, it returns "Assistant".
    /// </summary>
    public class BoolToLabelConverter : IValueConverter
    {
        /// <summary>
        /// Converts a boolean value to a string label.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <param name="targetType">The type of the binding target property. Not used in this converter.</param>
        /// <param name="parameter">Additional parameter to be used for conversion. Not used in this converter.</param>
        /// <param name="culture">Culture information. Not used in this converter.</param>
        /// <returns>"User" if the input is true, "Assistant" otherwise.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "User" : "Assistant";
        }

        /// <summary>
        /// Not implemented for this converter. Throws a NotImplementedException if called.
        /// </summary>
        /// <exception cref="NotImplementedException">This method is not implemented and will always throw this exception.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
