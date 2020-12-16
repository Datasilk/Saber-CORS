using Saber.Vendor;

namespace Saber.Vendors.CORS
{
    public class Info : IVendorInfo
    {
        public string Key { get; set; } = "CORS";
        public string Name { get; set; } = "CORS";
        public string Description { get; set; } = "Enables CORS (Cross-Origin Resource Sharing) headers in Saber";
        public Version Version { get; set; } = "1.0.0.0";
    }
}
