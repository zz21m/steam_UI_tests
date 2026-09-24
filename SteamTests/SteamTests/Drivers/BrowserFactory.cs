using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SteamTests.Data;

namespace SteamTests.Drivers;

public class BrowserFactory
{
    public IWebDriver CreateDriver(ConfigurationData configuration)
    {
        switch (configuration.Browser.ToLower())
        {
            case "chrome":
                ChromeOptions chromeOptions = new ChromeOptions();

                chromeOptions.AddArgument(
                    $"--lang={configuration.Language}");

                chromeOptions.AddUserProfilePreference(
                    "intl.accept_languages",
                    configuration.Language);

                if (configuration.Incognito)
                {
                    chromeOptions.AddArgument("--incognito");
                }

                return new ChromeDriver(chromeOptions);

            case "firefox":
                FirefoxOptions firefoxOptions = new FirefoxOptions();

                firefoxOptions.SetPreference(
                    "intl.accept_languages",
                    configuration.Language);

                if (configuration.Incognito)
                {
                    firefoxOptions.AddArgument("--private-window");
                }

                return new FirefoxDriver(firefoxOptions);

            default:
                throw new ArgumentException(
                    $"Unsupported browser: {configuration.Browser}");
        }
    }
}