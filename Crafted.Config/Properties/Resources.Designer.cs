﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crafted.Configuration.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Crafted.Configuration.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; decorated with CDataConfigurationProperty attribute must be of type string..
        /// </summary>
        internal static string ERROR_CDATA_CONFIGURATION_PROPERTY_MUST_BE_STRING {
            get {
                return ResourceManager.GetString("ERROR_CDATA_CONFIGURATION_PROPERTY_MUST_BE_STRING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type &apos;{0}&apos; which already has a property decorated with a CDataConfigurationProperty can not contain other properties that are decorated by ConfigurationProperty and whose type is subclass of ConfigurationElement.
        /// </summary>
        internal static string ERROR_CLASS_CONTAINS_CONFIGURATION_PROPERTY {
            get {
                return ResourceManager.GetString("ERROR_CLASS_CONTAINS_CONFIGURATION_PROPERTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; must be decorated by a ConfigurationProperty attribute..
        /// </summary>
        internal static string ERROR_MISSING_CONFIGURATION_PROPERTY_ATTRIBUTE {
            get {
                return ResourceManager.GetString("ERROR_MISSING_CONFIGURATION_PROPERTY_ATTRIBUTE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object of type &apos;{0}&apos; is already disposed..
        /// </summary>
        internal static string ERROR_OBJECT_DISPOSED {
            get {
                return ResourceManager.GetString("ERROR_OBJECT_DISPOSED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Object is currently disposing..
        /// </summary>
        internal static string ERROR_OBJECT_DISPOSING {
            get {
                return ResourceManager.GetString("ERROR_OBJECT_DISPOSING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}&apos; decorated with TextConfigurationProperty attribute must be of type string..
        /// </summary>
        internal static string ERROR_TEXT_CONFIGURATION_PROPERTY_MUST_BE_STRING {
            get {
                return ResourceManager.GetString("ERROR_TEXT_CONFIGURATION_PROPERTY_MUST_BE_STRING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are too many properties decorated with CDataConfigurationProperty attribute..
        /// </summary>
        internal static string ERROR_TOO_MANY_CDATA_CONFIGURATION_ELEMENTS {
            get {
                return ResourceManager.GetString("ERROR_TOO_MANY_CDATA_CONFIGURATION_ELEMENTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are too many properties decorated with TextConfigurationProperty attribute..
        /// </summary>
        internal static string ERROR_TOO_MANY_TEXT_CONFIGURATION_ELEMENTS {
            get {
                return ResourceManager.GetString("ERROR_TOO_MANY_TEXT_CONFIGURATION_ELEMENTS", resourceCulture);
            }
        }
    }
}
