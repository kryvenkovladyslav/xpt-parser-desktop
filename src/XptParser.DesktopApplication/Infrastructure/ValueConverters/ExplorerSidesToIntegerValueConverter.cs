using System;
using System.Globalization;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    public sealed class ExplorerSidesToIntegerValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var navigationSide = (ExplorerSides)value;

            return navigationSide == ExplorerSides.Left ?
                GridColumnsDefinitions.Zero : GridColumnsDefinitions.Second;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gridColumnDefinition = (int)value;

            return gridColumnDefinition == GridColumnsDefinitions.Zero ?
                ExplorerSides.Left : ExplorerSides.Right;
        }
    }
}