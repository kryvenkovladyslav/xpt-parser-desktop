using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XptParser.DesktopApplication
{
    public static class UserControlExtensions
    {
        public static TType GetTypedValue<TType>(this UserControl userControl, DependencyProperty dependencyProperty) =>
            (TType)userControl.GetValue(dependencyProperty);

        public static T FindAncestor<T>(this UserControl userControl, DependencyObject dependencyObject) where T : DependencyObject
        {
            while (dependencyObject != null)
            {
                if (dependencyObject is T)
                {
                    return (T)dependencyObject;
                }

                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            return null;
        }
    }
}