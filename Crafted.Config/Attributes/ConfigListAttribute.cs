using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Crafted.Configuration.Attributes {
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ConfigListAttribute : Attribute {
        public string ElementName { get; set; }

        public ConfigurationElementCollectionType Type { get; set; }

        public ConfigListAttribute(string elementName) {
            this.ElementName = elementName;
            this.Type = ConfigurationElementCollectionType.BasicMap;
        }

        public ConfigListAttribute(string elementName, ConfigurationElementCollectionType type) {
            this.ElementName = elementName;
            this.Type = type;
        }
    }
}
