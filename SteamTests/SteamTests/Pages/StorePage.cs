using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SteamTests.Drivers;
using SteamTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Pages
{
    public class StorePage : BasePage
    {
        private readonly By browseButton = By.XPath("//button//*[contains(.,'Browse')]");
        private readonly By bestSellersButton = By.XPath("//a[contains(@href,'https://store.steampowered.com/charts/topselling')]");
        public StorePage() : base(By.Id("home_featured_and_recommended"))
        {
        }
        public BestSellersPage OpenBestSellers()
        {
            WaitUtility.WaitForElement(browseButton).Click();
            WaitUtility.WaitForElement(bestSellersButton).Click();
            return new BestSellersPage();
        }
    }
}
