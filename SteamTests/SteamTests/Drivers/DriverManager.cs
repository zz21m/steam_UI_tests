using OpenQA.Selenium;
using SteamTests.Data;
using SteamTests.Managers;

namespace SteamTests.Drivers;

public sealed class DriverManager
{
    private static IWebDriver? _instance;
    public static IWebDriver GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BrowserFactory().CreateDriver(ConfigurationManager.GetInstance());
        }
        return _instance;
    }

    public static void QuitDriver()
    {
        if (_instance != null)
        {
            _instance.Quit();
            _instance = null;
        }
    }
}