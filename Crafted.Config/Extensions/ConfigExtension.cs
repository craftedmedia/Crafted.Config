using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Crafted.Configuration.Extensions
{
    public static class ConfigExtension
    {
        /// <summary>
        /// Selects insensitively an node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public static XmlNode SelectInsensitiveNode(this XmlNode parent, string node)
        {
            return parent.SelectSingleNode(Insensitivise(node));
        }

        /// <summary>
        /// As lowercase keys are used to denote wanting the text to be lowercase, the node has to be case insensitive.
        /// </summary>
        private static string Insensitivise(string key)
        {
            return string.Format("*[translate(local-name(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')='{0}']", key.ToLower());
        }
    }
}
