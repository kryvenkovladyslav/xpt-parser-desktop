using System.Globalization;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Converts <see cref="ExplorerVisibility"/> values to bitmap images representing the corresponding visibility state.
    /// </summary>
    public sealed class ExplorerVisibilityToBitmapValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts an <see cref="ExplorerVisibility"/> value to the corresponding bitmap image.
        /// </summary>
        /// <param name="value">The Explorer visibility state to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The bitmap image representing the corresponding visibility state.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (ExplorerVisibility)value;

            var imageDefaultPath = explorerVisiability == ExplorerVisibility.Hidden ?
                Images.DoubleLeftArrow : Images.DoubleUpArrow;

            return new BitmapImage(new Uri($"pack://application:,,,/{imageDefaultPath}"));
        }

        /// <summary>
        /// Converts a bitmap image back to an <see cref="ExplorerVisibility"/> value.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>This conversion is not supported.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}