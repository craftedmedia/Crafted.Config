using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafted.Configuration {
    public abstract class ConfigListElement<K> : System.Configuration.ConfigurationElement {

        public abstract K Key { get; set; }

    }
}
