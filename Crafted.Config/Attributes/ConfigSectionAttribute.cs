using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafted.Configuration.Attributes {
    /// <summary>
    /// Config section settings
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigSectionAttribute : Attribute {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>The section.</value>
        public string Section { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSection"/> class.
        /// </summary>
        public ConfigSectionAttribute() {
            this.Section = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigSection"/> class.
        /// </summary>
        /// <param name="section">The section.</param>
        public ConfigSectionAttribute(string section)
            : this() {
            this.Section = section;
        }
    }
}
