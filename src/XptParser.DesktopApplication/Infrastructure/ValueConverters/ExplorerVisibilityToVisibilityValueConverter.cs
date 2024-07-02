using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerVisibilityToVisibilityValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (ExplorerVisibility)value;

            return explorerVisiability == ExplorerVisibility.Visible ? 
                Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (int)value;

            return explorerVisiability == (int)Visibility.Visible ?
                ExplorerVisibility.Visible : Visibility.Collapsed;
        }
    }
}