using SteamTests.Data;
using SteamTests.Utilities;

namespace SteamTests.Managers;

public sealed class ConfigurationManager
{
    private static ConfigurationData? _instance;
    public static ConfigurationData GetInstance()
    {
        if (_instance == null)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "ConfigurationData.json");
            _instance = new JsonDeserializer().Deserialize<ConfigurationData>(path);
        }
        return _instance;
    }
}