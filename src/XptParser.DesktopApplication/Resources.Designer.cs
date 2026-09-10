namespace XptParser.DesktopApplication 
{
    using System;

    /// <summary>
    /// Provides access to application resource strings for localization and globalization support
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources 
    {
        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() { }

        /// <summary>
        /// Gets the cached <see cref="System.Resources.ResourceManager"/> instance used to retrieve localized strings
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager 
        {
            get 
            {
                if (object.ReferenceEquals(resourceMan, null)) 
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XptParser.DesktopApplication.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Gets or sets the culture used for resource lookups
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture 
        {
            get => resourceCulture;
            set => resourceCulture = value;      
        }

        /// <summary>
        /// Gets the localized string for "FileAlreadyExists"
        /// </summary>
        internal static string FileAlreadyExists 
        {
            get => ResourceManager.GetString(nameof(FileAlreadyExists), resourceCulture);
        }

        /// <summary>
        /// Gets the localized string for "ParseCommnad"
        /// </summary>
        internal static string ParseCommnad 
        {
            get => ResourceManager.GetString(nameof(ParseCommnad), resourceCulture);  
        }

        /// <summary>
        /// Gets the localized string for "RemoveCommand"
        /// </summary>
        internal static string RemoveCommand 
        {
            get => ResourceManager.GetString(nameof(RemoveCommand), resourceCulture);
        }
    }
}