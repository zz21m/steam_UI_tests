using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTests.Drivers;
using SteamTests.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Utilities
{
    public static class WaitUtility
    {
        private static WebDriverWait? _wait;
        public static WebDriverWait GetInstance()
        {
            if (_wait == null)
            {
                _wait = new WebDriverWait(DriverManager.GetInstance(), TimeSpan.FromSeconds(ConfigurationManager.GetInstance().Timeout));
            }
            return _wait;
        }
        public static void ResetWait()
        {
            _wait = null;
        }
        public static IWebElement WaitForElement(By locator)
        {
            return WaitUtility.GetInstance().Until(d =>
            {
                var elements = d.FindElements(locator);
                if (elements.Count == 0)
                {
                    return null;
                }
                IWebElement element = elements[0];
                return element.Displayed && element.Enabled ? element : null;
            });
        }
        public static IReadOnlyCollection<IWebElement> WaitForElements(By locator)
        {
            return WaitUtility.GetInstance().Until(d =>
            {
                var elements = d.FindElements(locator);
                return elements.Count > 0 && elements.All(e => e.Displayed) ? elements : null;
            });
        }
    }
}
