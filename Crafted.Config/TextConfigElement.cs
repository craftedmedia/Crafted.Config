using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

using Resources = Crafted.Configuration.Properties.Resources;
using Crafted.Configuration.Attributes;

namespace Crafted.Configuration {
    public class DefaultTextConfigElement : TextConfigElement {

        [ConfigurationProperty("content", IsRequired = true, IsKey = true)]
        [TextConfigurationProperty]
        public string Content {
            get {
                return (string)this["content"];
            }
            set {
                this["content"] = value;
            }
        }

        public override string ToString() {
            return this.Content;
        }
    }

    public class TextConfigElement : ConfigurationElement {
        private readonly string _textConfigurationPropertyName;

        public TextConfigElement() {
            PropertyInfo[] properties = GetType().GetProperties();
            int textConfigurationPropertyCount = 0;
            int configurationElementPropertyCount = 0;
            for(int i = 0; i < properties.Length; i++) {
                PropertyInfo property = properties[i];
                ConfigurationPropertyAttribute[] configurationPropertyAttributes =
                    getAttributes<ConfigurationPropertyAttribute>(property);
                TextConfigurationPropertyAttribute[] textConfigurationPropertyAttribute =
                    getAttributes<TextConfigurationPropertyAttribute>(property);

                bool hasConfigurationPropertyAttribute =
                    configurationPropertyAttributes.Length != 0;
                bool hastextConfigurationPropertyAttribute =
                    textConfigurationPropertyAttribute.Length != 0;

                if(hasConfigurationPropertyAttribute &&
                    property.PropertyType.IsSubclassOf(
                        typeof(ConfigurationElement))) {
                    configurationElementPropertyCount++;
                }

                if(hastextConfigurationPropertyAttribute) {
                    textConfigurationPropertyCount++;
                    throwIf(
                        textConfigurationPropertyCount > 1,
                        Resources.ERROR_TOO_MANY_TEXT_CONFIGURATION_ELEMENTS);

                    throwIf(
                        !hasConfigurationPropertyAttribute,
                        Resources.ERROR_MISSING_CONFIGURATION_PROPERTY_ATTRIBUTE,
                        property.Name);

                    throwIf(
                        !property.PropertyType.Equals(typeof(string)),
                        Resources.ERROR_TEXT_CONFIGURATION_PROPERTY_MUST_BE_STRING,
                        property.Name);

                    _textConfigurationPropertyName =
                        configurationPropertyAttributes[0].Name;
                }
            }

            throwIf(
                configurationElementPropertyCount > 0 &&
                    textConfigurationPropertyCount > 0,
                Resources.ERROR_CLASS_CONTAINS_CONFIGURATION_PROPERTY,
                GetType().FullName);
        }

        private T[] getAttributes<T>(PropertyInfo property)
            where T : Attribute {
            object[] objectAttributes = property.GetCustomAttributes(
                    typeof(T),
                    true);
            return Array.ConvertAll<object, T>(
                    objectAttributes,
                    delegate(object o) {
                        return o as T;
                    });
        }

        private void throwIf(
            bool condition,
            string formatString,
            params object[] values) {
            if(condition) {
                if(values.Length > 0) {
                    formatString = string.Format(formatString, values);
                }

                Trace.WriteLine(formatString);
                throw new ConfigurationErrorsException(
                    formatString);
            }
        }

        protected override bool SerializeElement(
            System.Xml.XmlWriter writer,
            bool serializeCollectionKey) {
            bool returnValue;
            if(string.IsNullOrEmpty(
                _textConfigurationPropertyName)) {
                returnValue = base.SerializeElement(
                    writer, serializeCollectionKey);
            } else {
                foreach(ConfigurationProperty configurationProperty in
                    Properties) {
                    string name = configurationProperty.Name;
                    TypeConverter converter = configurationProperty.Converter;
                    string propertyValue = converter.ConvertToString(
                            base[name]);

                    if(writer != null) {
                        if(name == _textConfigurationPropertyName) {
                            writer.WriteString(propertyValue);
                        } else {
                            writer.WriteAttributeString("name", propertyValue);
                        }
                    }
                }
                returnValue = true;
            }
            return returnValue;
        }

        protected override void DeserializeElement(
            System.Xml.XmlReader reader,
            bool serializeCollectionKey) {
            if(string.IsNullOrEmpty(
                _textConfigurationPropertyName)) {
                base.DeserializeElement(
                    reader, serializeCollectionKey);
            } else {
                foreach(ConfigurationProperty configurationProperty in
                    Properties) {
                    string name = configurationProperty.Name;
                    if(name == _textConfigurationPropertyName) {
                        string contentString = reader.ReadString();
                        base[name] = contentString.Trim();
                    } else {
                        string attributeValue = reader.GetAttribute(name);
                        base[name] = attributeValue;
                    }
                }
                reader.ReadEndElement();
            }
        }
    }
}
