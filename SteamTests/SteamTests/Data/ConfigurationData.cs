using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Data
{
    public class ConfigurationData
    {
        public string BaseUrl { get; set; }
        public string Language { get; set; }
        public string Browser { get; set; }
        public bool Incognito { get; set; }
        public int Timeout { get; set; }
    }
}
