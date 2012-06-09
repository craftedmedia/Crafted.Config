using System;
using System.Configuration;
using System.Web.Configuration;
using System.Xml;

namespace Crafted.Configuration {
    
    /// <summary>
   /// Custom Configuration Element
    /// </summary>
    public class ConfigTextElement<T> : System.Configuration.ConfigurationElement{
        public ConfigTextElement() : base() {
            
        }
        public ConfigTextElement(T value) : this(){
            this._value = value;
        }

        private T _value;

        public T Value {
            get {
                return _value;
            }
        }

        public override string ToString() {
            if(_value != null) {
                return _value.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Reads XML from the configuration file.
        /// </summary>
        /// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> that reads from the configuration file.</param>
        /// <param name="serializeCollectionKey">true to serialize only the collection key properties; otherwise, false.</param>
        /// <exception cref="T:System.Configuration.ConfigurationErrorsException">The element to read is locked.- or -An attribute of the current node is not recognized.- or -The lock status of the current node cannot be determined.  </exception>
        protected override void DeserializeElement(XmlReader reader, bool serializeCollectionKey) {
            _value = (T)reader.ReadElementContentAs(typeof(T), null);
        }
        /*
        protected override bool SerializeElement(XmlWriter writer, bool serializeCollectionKey) {
            writer.WriteRaw(this.ToString());
            return true;
            //return base.SerializeElement(writer, serializeCollectionKey);
        }
         * */
    }

    /// <summary>
    /// Wrapper class for config sections
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Config<T> : IDisposable where T : System.Configuration.ConfigurationSection{

        private string _sectionName = string.Empty;

        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>The name of the section.</value>
        protected string SectionName {
            get {
                if(string.IsNullOrEmpty(_sectionName)) {
                    Type t = typeof(T);
                    Attribute[] attrs = Attribute.GetCustomAttributes(t);
                    foreach(Attribute attr in attrs) {
                        if(attr is Crafted.Configuration.Attributes.ConfigSectionAttribute) {
                            Crafted.Configuration.Attributes.ConfigSectionAttribute section = (Crafted.Configuration.Attributes.ConfigSectionAttribute)attr;
                            _sectionName = section.Section;
                            return section.Section;
                        }
                    }
                    return string.Empty;
                }
                return _sectionName;
            }
            set {
                _sectionName = value;
            }
        }

        private System.Configuration.Configuration _config;
        private T _configSection;

        /// <summary>
        /// Gets the values.
        /// </summary>
        public T Values {
            get{
                if(_configSection == null) {
                    _configSection = ((T)_config.GetSection(this.SectionName));
                }
                return _configSection;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config&lt;T&gt;"/> class.
        /// </summary>
        public Config() {

            _config = WebConfigurationManager.OpenWebConfiguration("~");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public Config(System.Configuration.Configuration config) {
            _config = config;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="sectionName">Name of the section.</param>
        public Config(System.Configuration.Configuration config, string sectionName) {
            _config = config;
            _sectionName = sectionName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Config&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="sectionName">Name of the section.</param>
        public Config(string sectionName) {
            _config = WebConfigurationManager.OpenWebConfiguration("~");
            _sectionName = sectionName;
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save() {
            Save(ConfigurationSaveMode.Modified, true);
        }

        /// <summary>
        /// Saves the specified mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public void Save(ConfigurationSaveMode mode) {
            Save(mode, true);
        }

        /// <summary>
        /// Saves the specified mode.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="refreshSection">if set to <c>true</c> [refresh section].</param>
        public void Save(ConfigurationSaveMode mode, bool refreshSection) {
            _config.Save(mode);
            if(refreshSection) {
                ConfigurationManager.RefreshSection(this.SectionName);
            }
        }

        #region IDisposable Members

        public void Dispose() {
            _config = null;
        }

        #endregion
    }
}
