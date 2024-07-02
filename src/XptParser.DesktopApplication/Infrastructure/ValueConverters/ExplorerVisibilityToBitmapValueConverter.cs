using System.Globalization;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerVisibilityToBitmapValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (ExplorerVisibility)value;

            var imageDefaultPath = explorerVisiability == ExplorerVisibility.Hidden ? 
                Images.DoubleLeftArrow : Images.DoubleUpArrow;

            return new BitmapImage(new Uri($"pack://application:,,,/{imageDefaultPath}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}