using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SteamTests.Drivers;
using SteamTests.Managers;
using SteamTests.Utilities;

namespace SteamTests.Pages
{
    public abstract class BasePage
    {
        protected readonly By pageMarker;
        protected readonly By aboutButton = By.XPath("//*[@class='supernav_container']//a[contains(@href,'https://store.steampowered.com/about/')]");
        protected readonly By communityButton = By.XPath("//*[@class='supernav_container']//a[contains(@href,'https://steamcommunity.com')]");
        protected readonly By marketButton = By.XPath("//*[@id='tooltip-1']//a[contains(@href,'https://steamcommunity.com/market/')]");
        protected readonly By storeButton = By.XPath("//*[@class='supernav_container']//a[contains(@href,'https://store.steampowered.com')]");
        protected BasePage(By pageMarker)
        {
            this.pageMarker = pageMarker;
        }

        public StorePage OpenStore()
        {
            WaitUtility.WaitForElement(storeButton).Click();
            return new StorePage();
        }
        public AboutPage OpenAbout()
        {
            WaitUtility.WaitForElement(aboutButton).Click();
            return new AboutPage();
        }
        public CommunityMarketPage OpenMarket()
        {
            new Actions(DriverManager.GetInstance()).MoveToElement(WaitUtility.WaitForElement(communityButton)).Perform();
            WaitUtility.WaitForElement(marketButton).Click();
            return new CommunityMarketPage();
        }
        public bool IsOpened()
        {
            WaitUtility.WaitForElement(pageMarker);
            return true;
        }
    }
}