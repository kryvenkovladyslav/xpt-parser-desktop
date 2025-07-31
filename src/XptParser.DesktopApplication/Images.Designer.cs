namespace XptParser.DesktopApplication 
{
    using System;

    /// </summary>
    /// Provides strongly-typed access to embedded image resource strings for the application
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Images 
    {
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;

        /// <summary>
        /// Initializes a new instance of the <see cref="Images"/> class
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Images() { }

        /// <summary>
        /// Gets the <see cref="System.Resources.ResourceManager"/> instance used to retrieve image resources
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager 
        {
            get 
            {
                if (object.ReferenceEquals(resourceMan, null)) 
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XptParser.DesktopApplication.Images", typeof(Images).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        /// Gets or sets the culture used to look up localized image resources
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture 
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }

        /// <summary>
        /// Gets the string identifier for the "DoubleLeftArrow" image resource
        /// </summary>
        internal static string DoubleLeftArrow 
        {
            get => ResourceManager.GetString(nameof(DoubleLeftArrow), resourceCulture);
        }

        /// <summary>
        /// Gets the string identifier for the "DoubleUpArrow" image resource
        /// </summary>
        internal static string DoubleUpArrow 
        {
            get => ResourceManager.GetString(nameof(DoubleUpArrow), resourceCulture);
        }

        /// <summary>
        /// Gets the string identifier for the "LeftArrow" image resource
        /// </summary>
        internal static string LeftArrow 
        {
            get => ResourceManager.GetString(nameof(LeftArrow), resourceCulture);
            
        }

        /// <summary>
        /// Gets the string identifier for the "RightArrow" image resource
        /// </summary>
        internal static string RightArrow 
        {
            get => ResourceManager.GetString(nameof(RightArrow), resourceCulture); 
        }
    }
}