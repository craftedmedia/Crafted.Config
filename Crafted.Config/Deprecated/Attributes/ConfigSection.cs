using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafted.Config.Attributes
{
    /// <summary>
    /// Config section settings
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [Obsolete("Crafted.Config is now obsolete. Please Use Crafted.Configuration")]
    public class ConfigSection : Attribute
    {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>The section.</value>
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSection"/> class.
        /// </summary>
        public ConfigSection()
        {
            this.Section = string.Empty;
            this.Path = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSection"/> class.
        /// </summary>
        /// <param name="section">The section.</param>
        public ConfigSection(string section) : this()
        {
            this.Section = section;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSection"/> class.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="path">The path.</param>
        public ConfigSection(string section, string path)
        {
            this.Section = section;
            this.Path = path;
        }
    }
}
