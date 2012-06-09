using System;
using System.Xml;
using Crafted.Config.Extensions;

namespace Crafted.Config
{
    /// <summary>
    /// Base class for the config
    /// </summary>
    [Obsolete("Crafted.Config is now obsolete. Please Use Crafted.Configuration")]
    public abstract class BaseConfig : System.Configuration.IConfigurationSectionHandler, IConfig
    {
        /// <summary>
        /// Creates a configuration section handler.
        /// </summary>
        /// <param name="parent">Parent object.</param>
        /// <param name="configContext">Configuration context object.</param>
        /// <param name="section">Section XML node.</param>
        /// <returns>The created section handler object.</returns>
        public object Create(object parent, object configContext, XmlNode section)
        {
            this.XmlSection = section;
            return (IConfig)this;
        }

        public virtual bool IsInsensitive
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the XML section.
        /// </summary>
        /// <value>The XML section.</value>
        public XmlNode XmlSection { get; set; }

        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <value>The config section.</value>
        public IConfig ConfigSection
        {
            get
            {
                if (string.IsNullOrEmpty(SectionName))
                {
                    throw new ApplicationException("Section not defined in config class.");
                }
                IConfig config = (IConfig)System.Configuration.ConfigurationManager.GetSection(SectionName);

                if (config == null)
                {
                    if (System.Web.HttpContext.Current == null)
                    {
                        throw new ApplicationException(
                            "The main control is not design-time compatible due to it's complexity. Please load the individual page controls to modify the forum.");
                    }
                    throw new ApplicationException("Failed to get configuration section " + SectionName + " from Web.config.");
                }
                config.Path = this.GetPath();
                return config;
            }
        }

        private string _sectionName = string.Empty;

        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>The name of the section.</value>
        public string SectionName
        {
            get
            {
                if (string.IsNullOrEmpty(_sectionName))
                {
                    Type t = this.GetType();
                    Attribute[] attrs = Attribute.GetCustomAttributes(t);
                    foreach (Attribute attr in attrs)
                    {
                        if (attr is Attributes.ConfigSection)
                        {
                            Attributes.ConfigSection section = (Attributes.ConfigSection)attr;
                            _sectionName = section.Section;
                            return section.Section;
                        }
                    }
                    return string.Empty;
                }
                return _sectionName;
            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        private string GetPath()
        {
            Type t = this.GetType();
            Attribute[] attrs = Attribute.GetCustomAttributes(t);
            foreach (Attribute attr in attrs)
            {
                if (attr is Attributes.ConfigSection)
                {
                    Attributes.ConfigSection section = (Attributes.ConfigSection)attr;
                    return section.Path;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the config value with the specified key.
        /// </summary>
        /// <value></value>
        public string this[string key]
        {
            get
            {
                if (!IsInsensitive)
                {
                    XmlNode node = string.IsNullOrEmpty(Path) ? this.XmlSection.SelectSingleNode(key) : this.XmlSection.SelectSingleNode(Path).SelectSingleNode(key);
                    return node != null ? node.InnerText : null;
                }
                else
                {
                    return GetInsensitiveValue(key);
                }
            }
        }

        private string GetInsensitiveValue(string key)
        {
            XmlNode node = string.IsNullOrEmpty(Path) ? this.XmlSection.SelectInsensitiveNode(key) : this.XmlSection.SelectSingleNode(Path).SelectInsensitiveNode(key);
            return node != null ? node.InnerText : null;
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <returns></returns>
        public XmlNode GetNode()
        {
            XmlNode node = string.IsNullOrEmpty(Path) ? this.XmlSection : this.XmlSection.SelectSingleNode(Path);
            return node != null ? node : null;
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public XmlNode GetNode(string key)
        {
            XmlNode node = string.IsNullOrEmpty(Path) ? this.XmlSection.SelectSingleNode(key) : this.XmlSection.SelectSingleNode(Path).SelectSingleNode(key);
            return node != null ? node : null;
        }

        /// <summary>
        /// Fetches the config section.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IConfig FetchConfigSection<T>() where T : IConfig, new()
        {
            try
            {
                T cnf = new T();
                return cnf.ConfigSection;
            }
            catch(NullReferenceException)
            {
                throw new Exception("Config handler doesn't have a parameterless constructor");
            }
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static XmlNode GetNode<T>() where T : IConfig, new()
        {
            return FetchConfigSection<T>().GetNode();
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static XmlNode GetNode<T>(string key) where T : IConfig, new()
        {
            return FetchConfigSection<T>().GetNode(key);
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetValue<T>(string key) where T : IConfig, new()
        {
            return FetchConfigSection<T>()[key];
        }
    }
}
