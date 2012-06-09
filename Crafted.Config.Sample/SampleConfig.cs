using System.Configuration;
using Crafted.Configuration;
using Crafted.Configuration.Attributes;

namespace SampleNamespace {


    [ConfigSection("SampleConfig")]
    public class SampleConfig : ConfigurationSection {

        [ConfigurationProperty("SampleAttribute", IsRequired = true, DefaultValue = "Sample")]
        public string SampleAttribute {
            get {
                return (string) this["SampleAttribute"];
            }
            set {
                this["SampleAttribute"] = value;
            }
        }

        public string SampleConfigItem {
            get {
                return _sampleConfigItem.Content;
            }
            set {
                _sampleConfigItem.Content = value;
            }
        }

        [ConfigurationProperty("SampleConfigItem")]
        private DefaultTextConfigElement _sampleConfigItem {
            get {
                return (DefaultTextConfigElement)this["SampleConfigItem"];
            }
            set {
                this["SampleConfigItem"] = value;
            }
        }

        [ConfigurationProperty("SampleProperty")]
        public SampleProperty SampleProperty {
            get {
                return (SampleProperty)this["SampleProperty"];
            }
        }

        [ConfigurationProperty("SampleList")]
        public SampleList SampleList {
            get {
                return (SampleList)this["SampleList"];
            }
        }

    }

    public class SampleConfigItemWithAttributes : TextConfigElement {

        [ConfigurationProperty("Content")]
        [TextConfigurationProperty]
        public string Content {
            get {
                return (string)this["Content"];
            }
            set {
                this["Content"] = value;
            }
        }

        [ConfigurationProperty("isHtml", IsRequired = true, DefaultValue = false)]
        public bool isHtml {
            get {
                return (bool)this["isHtml"];
            }
            set {
                this["isHtml"] = value;
            }
        }
    }

    public class SampleProperty : ConfigurationElement {
        [ConfigurationProperty("SampleProperty", IsRequired = false)]
        public string SampleAttribute {
            get {
                return (string)this["SampleAttribute"];
            }
            set {
                this["SampleAttribute"] = value;
            }
        }
    }

    [ConfigList("SampleItem")]
    public class SampleList : ConfigElementCollection<string, SampleItem> {

    }

    public class SampleItem : ConfigListElement<string> {
        [ConfigurationProperty("Key", IsRequired = true)]
        public override string Key {
            get {
                return (string)this["Key"];
            }
            set {
                this["Key"] = value;
            }
        }

        [ConfigurationProperty("SampleInt", IsRequired = false)]
        public int SampleInt {
            get {
                return (int)this["SampleInt"];
            }
            set {
                this["SampleInt"] = value;
            }
        }
    }
}