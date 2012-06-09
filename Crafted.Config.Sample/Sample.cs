using Crafted.Configuration;

namespace SampleNamespace {
    public static class Sample {
        public static void SampleMethod() {
            using(Config<SampleNamespace.SampleConfig> c = new Config<SampleNamespace.SampleConfig>()) {
                // Access and save values via c.Values
				// if saving use c.Save() to save and refresh
                c.Save();
            }
        }
    }
}
