using OpenQA.Selenium;
using SteamTests.BusinessObjects;
using SteamTests.Forms;
using SteamTests.Managers;
using SteamTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Pages
{
    public class MoreBestSellersPage : BasePage
    {
        private readonly By resultsCount = By.ClassName("search_results_count");
        private readonly By resultsgameslist = By.Id("search_resultsRows");
        private readonly By firstGame = By.XPath("//*[@id='search_resultsRows']//a");
        private readonly By firstGameName = By.XPath("//*[@id='search_resultsRows']//*[@class='title']");
        private readonly By firstGameReleaseDate = By.XPath("//*[@id='search_resultsRows']//*[@class='search_released responsive_secondrow']");
        private readonly By firstGamePrice = By.XPath("//*[@id='search_resultsRows']//*[contains(@class,'discount_final_price')]");

        public BestSellersFilterForm Filters { get; }

        public MoreBestSellersPage() : base(By.Id("search_results"))
        {
            Filters = new BestSellersFilterForm();
        }
        public int GetResultsCount()
        {
            string text = WaitUtility.WaitForElement(resultsCount).Text;
            return int.Parse(new string(text.Where(char.IsDigit).ToArray()));
        }
        public int GetGamesCount()
        {
            int gamesCount = 0;
            WaitUtility.GetInstance().Until(d =>
            {
                int expectedCount = int.Parse(new string(WaitUtility.WaitForElement(resultsCount).Text.Where(char.IsDigit).ToArray()));
                gamesCount = WaitUtility.WaitForElement(resultsgameslist).FindElements(By.XPath("./*")).Count;
                return gamesCount == expectedCount;
            });
            return gamesCount;
        }
        public Game GetFirstGame()
        {
            return new Game
            {
                Name = WaitUtility.WaitForElement(firstGameName).Text,
                ReleaseDate = WaitUtility.WaitForElement(firstGameReleaseDate).Text,
                Price = WaitUtility.WaitForElement(firstGamePrice).Text.Contains(
                    "Free",
                    StringComparison.OrdinalIgnoreCase)
                    ? "Free"
                    : new string(WaitUtility.WaitForElement(firstGamePrice).Text.Where(char.IsDigit).ToArray())
            };
        }
        public GamePage OpenFirstGame()
        {
            WaitUtility.WaitForElement(firstGame).Click();
            return new GamePage();
        }
    }
}
