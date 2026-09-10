using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace XptParser.DesktopApplication
{
    /// <summary>
    /// Provides extension methods for WPF <see cref="UserControl"/> instances.
    /// </summary>
    public static class UserControlExtensions
    {
        /// <summary>
        /// Gets a dependency property value cast to the specified type.
        /// </summary>
        /// <typeparam name="TType">The expected type of the dependency property value.</typeparam>
        /// <param name="userControl">The user control containing the dependency property.</param>
        /// <param name="dependencyProperty">The dependency property to retrieve.</param>
        /// <returns>The dependency property value cast to the specified type.</returns>
        public static TType GetTypedValue<TType>(this UserControl userControl, DependencyProperty dependencyProperty) =>
            (TType)userControl.GetValue(dependencyProperty);

        /// <summary>
        /// Finds the nearest ancestor of the specified type in the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the ancestor to find.</typeparam>
        /// <param name="userControl">The user control used to find the ancestor.</param>
        /// <param name="dependencyObject">The dependency object from which to start searching.</param>
        /// <returns>The nearest ancestor of the specified type, or <see langword="null"/> if no matching ancestor is found.</returns>
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