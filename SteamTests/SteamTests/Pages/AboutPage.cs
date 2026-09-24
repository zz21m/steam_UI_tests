using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTests.Data;
using SteamTests.Managers;
using SteamTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Pages
{
    public class AboutPage : BasePage
    {
        private readonly By onlinePlayers = By.XPath("//div[contains(@class,'gamers_online')]/..");
        private readonly By currentPlayers = By.XPath("//div[contains(@class,'gamers_in_game')]/..");
        public AboutPage() : base(By.Id("about_greeting"))
        {
        }
        public int GetOnlinePlayers()
        {
            string text = WaitUtility.WaitForElement(onlinePlayers).Text;
            return int.Parse(new string(text.Where(char.IsDigit).ToArray()));
        }
        public int GetCurrentPlayers()
        {
            string text = WaitUtility.WaitForElement(currentPlayers).Text;
            return int.Parse(new string(text.Where(char.IsDigit).ToArray()));
        }
    }
}
