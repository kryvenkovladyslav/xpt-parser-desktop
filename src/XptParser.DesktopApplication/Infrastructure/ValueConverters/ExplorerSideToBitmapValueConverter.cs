using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Converts an <see cref="ExplorerSides"/> value to a bitmap image representing the corresponding navigation direction.
    /// </summary>
    public sealed class ExplorerSideToBitmapValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts an <see cref="ExplorerSides"/> value to the corresponding arrow image.
        /// </summary>
        /// <param name="value">The Explorer side to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The bitmap image representing the corresponding navigation direction.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerSide = (ExplorerSides)value;

            var imageDefaultPath = explorerSide == ExplorerSides.Left ?
                Images.RightArrow : Images.LeftArrow;

            return new BitmapImage(new Uri($"pack://application:,,,/{imageDefaultPath}"));
        }

        /// <summary>
        /// Converts a bitmap image back to an <see cref="ExplorerSides"/> value.
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