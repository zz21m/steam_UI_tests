using SteamTests.Data;
using SteamTests.Utilities;

namespace SteamTests.Managers;

public class TestDataManager
{
    private static TestData? _instance;
    public static TestData GetInstance()
    {
        if (_instance == null)
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "TestData.json");
            _instance = new JsonDeserializer().Deserialize<TestData>(path);
        }
        return _instance;
    }
}