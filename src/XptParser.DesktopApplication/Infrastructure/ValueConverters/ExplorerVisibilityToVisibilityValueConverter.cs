using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Converts <see cref="ExplorerVisibility"/> values to WPF <see cref="Visibility"/> values and back.
    /// </summary>
    public sealed class ExplorerVisibilityToVisibilityValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts an <see cref="ExplorerVisibility"/> value to a WPF <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The Explorer visibility state to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The corresponding WPF visibility value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (ExplorerVisibility)value;

            return explorerVisiability == ExplorerVisibility.Visible ?
                Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts a WPF <see cref="Visibility"/> value to an <see cref="ExplorerVisibility"/> value.
        /// </summary>
        /// <param name="value">The WPF visibility value to convert.</param>
        /// <param name="targetType">The target type of the conversion.</param>
        /// <param name="parameter">The conversion parameter.</param>
        /// <param name="culture">The culture to use for the conversion.</param>
        /// <returns>The corresponding Explorer visibility state.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var explorerVisiability = (int)value;

            return explorerVisiability == (int)Visibility.Visible ?
                ExplorerVisibility.Visible : Visibility.Collapsed;
        }
    }
}