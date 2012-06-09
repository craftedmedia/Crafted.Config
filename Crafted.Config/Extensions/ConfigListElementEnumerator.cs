using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Crafted.Configuration.Extensions {
    public class ConfigListElementEnumerator<K, V> : IEnumerator<V> where V : ConfigListElement<K>, new() {
        private ConfigElementCollection<K, V> _elements;

        int position = -1;

        public ConfigListElementEnumerator(ConfigElementCollection<K, V> elements) {
            _elements = elements;
        }

        public bool MoveNext() {
            position++;
            return (position < _elements.Count);
        }

        public void Reset() {
            position = -1;
        }

        object IEnumerator.Current {
            get {
                return Current;
            }
        }

        public V Current {
            get {
                try {
                    return _elements[position];
                } catch(IndexOutOfRangeException) {
                    throw new InvalidOperationException();
                }
            }
        }

        #region IDisposable Members

        public void Dispose() {
            _elements = null;
            position = -1;
        }

        #endregion
    }
    
}
