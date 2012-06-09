using System;

namespace ConfigTest {

    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
            using(Crafted.Configuration.Config<WebConfig> c = new Crafted.Configuration.Config<WebConfig>()) {
                c.Values.MyConfigValue = DateTime.Now.ToShortTimeString();
                c.Values.Something.Content = "Other";
                c.Save();
            }
            
            using(Crafted.Configuration.Config<WebConfig> c = new Crafted.Configuration.Config<WebConfig>()) {
                litConfig.Text = c.Values.Something.ToString();
            }

        }
    }
}