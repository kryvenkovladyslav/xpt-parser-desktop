using System;
using System.Globalization;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Converts <see cref="ExplorerSides"/> values to grid column indices and back.
    /// </summary>
    public sealed class ExplorerSidesToIntegerValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts an <see cref="ExplorerSides"/> value to a grid column index.
        /// </summary>
        /// <param name="value">The Explorer side to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The corresponding grid column index.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (ExplorerSides)value;

            return navigationSide == ExplorerSides.Left ?
                GridColumnsDefinitions.Zero : GridColumnsDefinitions.Second;
        }

        /// <summary>
        /// Converts a grid column index to an <see cref="ExplorerSides"/> value.
        /// </summary>
        /// <param name="value">The grid column index to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The corresponding Explorer side.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gridColumnDefinition = (int)value;

            return gridColumnDefinition == GridColumnsDefinitions.Zero ?
                ExplorerSides.Left : ExplorerSides.Right;
        }
    }
}