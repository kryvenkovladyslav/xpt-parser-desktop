using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerSideToBitmapValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerSide = (ExplorerSides)value;

            var imageDefaultPath = explorerSide == ExplorerSides.Left ? 
                Images.RightArrow : Images.LeftArrow;

            return new BitmapImage(new Uri($"pack://application:,,,/{imageDefaultPath}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}