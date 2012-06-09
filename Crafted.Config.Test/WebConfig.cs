using System.Configuration;
using Crafted.Configuration;
using Crafted.Configuration.Attributes;

namespace ConfigTest {

    [Crafted.Configuration.Attributes.ConfigSection("webConfig")]
    public class WebConfig : System.Configuration.ConfigurationSection {

        [ConfigurationProperty("MyConfigValue", IsRequired = true, DefaultValue = "Nothing")]
        public string MyConfigValue {
            get {
                return this["MyConfigValue"].ToString();
            }
            set {
                this["MyConfigValue"] = value;
            }
        }
        /*
        public string Something{
            get{
                return _something.InnerText;
            }
            set {
                _something.InnerText = value;
            }
        }
        */
        [ConfigurationProperty("Something")]
        [TextConfigurationProperty]
        public DefaultTextConfigElement Something {
            get {
                return (DefaultTextConfigElement)this["Something"];
            }
        }
    }
}