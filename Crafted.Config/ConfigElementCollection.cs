using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Crafted.Configuration.Extensions;

namespace Crafted.Configuration {
    public abstract class ConfigElementCollection<K, V> : ConfigurationElementCollection, IEnumerable<V> where V : ConfigListElement<K>, new() {
        public ConfigElementCollection() {
        }

        private bool _typeSet = false;
        private ConfigurationElementCollectionType _collectionType;

        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>The name of the section.</value>
        public override ConfigurationElementCollectionType CollectionType {
            get {
                if(!_typeSet) {
                    Type t = this.GetType();
                    Attribute[] attrs = Attribute.GetCustomAttributes(t);
                    foreach(Attribute attr in attrs) {
                        if(attr is Crafted.Configuration.Attributes.ConfigListAttribute) {
                            Crafted.Configuration.Attributes.ConfigListAttribute section = (Crafted.Configuration.Attributes.ConfigListAttribute)attr;
                            _elementName = section.ElementName;
                            _collectionType = section.Type;
                            _typeSet = true;
                            return section.Type;
                        }
                    }
                    throw new ApplicationException("Collection type is required on ConfigElementCollections");
                }
                return _collectionType;
            }
        }
        private string _elementName = string.Empty;

        /// <summary>
        /// Gets the name of the section.
        /// </summary>
        /// <value>The name of the section.</value>
        protected override string ElementName {
            get {
                if(string.IsNullOrEmpty(_elementName)) {
                    Type t = this.GetType();
                    Attribute[] attrs = Attribute.GetCustomAttributes(t);
                    foreach(Attribute attr in attrs) {
                        if(attr is Crafted.Configuration.Attributes.ConfigListAttribute) {
                            Crafted.Configuration.Attributes.ConfigListAttribute section = (Crafted.Configuration.Attributes.ConfigListAttribute)attr;
                            _elementName = section.ElementName;
                            _collectionType = section.Type;
                            _typeSet = true;
                            return section.ElementName;
                        }
                    }
                    throw new ApplicationException("Element Name is required on ConfigElementCollections");
                }
                return _elementName;
            }
        }

        protected override ConfigurationElement CreateNewElement() {
            return new V();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return GetElementKey((V)element);
        }

        protected K GetElementKey(V element) {
            return element.Key;
        }

        public void Add(V path) {
            BaseAdd(path);
        }

        public void Remove(K key) {
            BaseRemove(key);
        }

        public V this[K key] {
            get { return (V)BaseGet(key); }
        }

        public V this[int index] {
            get { return (V)BaseGet(index); }
        }

        #region IEnumerable<V> Members

        #endregion

        #region IEnumerable<V> Members

        public new IEnumerator<V> GetEnumerator() {
            return (IEnumerator<V>)new ConfigListElementEnumerator<K, V>(this);
        }

        #endregion
    }   

}
