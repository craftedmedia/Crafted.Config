# Crafted.Config 2.3.5 #

Back in .Net 1.1, creating custom sections in web.config was quite difficult. In .Net Framework 2.0 and greater, this is now a lot easier.
However when it comes to accessing text elements or saving values, there are a couple of additional steps.

With this library, the steps to saving a configuration value back to the web.config is made easier.

## Usage ##

To use, first of all, include the reference to the Crafted.Config assemby in your project.

First, create your configuration class. This will be the same type as ones created using ConfigurationSections in .Net 2.0. 

```  
**[Crafted.Configuration.Attributes.ConfigSection("webConfig")]**  
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

	public string Something{
		get{
			return _something.Content;
		}
		set {
			_something.Content = value;
		}
	}

	[ConfigurationProperty("Something")]
	[TextConfigurationProperty]
	public DefaultTextConfigElement Something {
		get {
			return (DefaultTextConfigElement)this["Something"];
		}
	}
}  
```

Next, update your web.config with your custom section. Next add the new section in the list of config sections:  

```
<section name="webConfig" type="ConfigTest.WebConfig" />
```

Then add your configuration section to the web.config:

```
<webConfig MyConfigValue="17:18">  
<Something>Other</Something>  
</webConfig>  
```

Now to use the values all you need to do is wrap your Configuration class with Crafted.Configuration.Config<T> where T is your class. You can then access and save the values as following:

```  
using(Crafted.Configuration.Config<WebConfig> c = new Crafted.Configuration.Config<WebConfig>()) {  
    c.Values.MyConfigValue = DateTime.Now.ToShortTimeString();  
    c.Values.Something.Content = "Other";  
    c.Save();  
}

using(Crafted.Configuration.Config<WebConfig> c = new Crafted.Configuration.Config<WebConfig>()) {  
    litConfig.Text = c.Values.Something.ToString();  
}  
```

### Deprecated ###
Please note that the Crafted.Config is deprecated and is included for backward compatibilty.