using System;
using System.Xml;

namespace Crafted.Config
{
    /// <summary>
    /// Config interface
    /// </summary>
    [Obsolete("Crafted.Config is now obsolete. Please Use Crafted.Configuration")]
    public interface IConfig
    {
        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>The name of the section.</value>
        string SectionName { get; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        string Path { get; set; }

        /// <summary>
        /// Gets or sets the XML section.
        /// </summary>
        /// <value>The XML section.</value>
        XmlNode XmlSection { get; set; }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified key.
        /// </summary>
        /// <value></value>
        string this[string key] { get; }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <returns></returns>
        XmlNode GetNode();

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        XmlNode GetNode(string key);

        /// <summary>
        /// Gets the config section.
        /// </summary>
        /// <value>The config section.</value>
        IConfig ConfigSection { get; }
    }
}
