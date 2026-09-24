using OpenQA.Selenium;
using SteamTests.BusinessObjects;
using SteamTests.Managers;
using SteamTests.Utilities;

namespace SteamTests.Pages
{
    public class CommunityMarketItemPage : BasePage
    {
        private readonly By itemName;
        private readonly By game;
        private readonly By hero;
        private readonly By rarity;
        public CommunityMarketItemPage() : base(By.ClassName("recharts-wrapper"))
        {
            this.itemName = By.XPath("//h2//*");
            this.game = By.XPath($"//*[preceding-sibling::h2]//a[text()='{TestDataManager.GetInstance().Game}']");
            this.hero = By.XPath($"//a[contains(@href,'https://steamcommunity.com/market/search?category')]//*[text()='{TestDataManager.GetInstance().Hero}']");
            this.rarity = By.XPath($"//a[contains(@href,'https://steamcommunity.com/market/search?category')]//*[text()='{TestDataManager.GetInstance().Rarity}']");
        }
        public MarketItem GetItem()
        {
            return new MarketItem
            {
                Name = WaitUtility.WaitForElement(itemName).Text,
                Game = WaitUtility.WaitForElement(game).Text,
                Hero = WaitUtility.WaitForElement(hero).Text.Split(':', 2)[1].Trim(),
                Rarity = WaitUtility.WaitForElement(rarity).Text.Split(':', 2)[1].Trim()
            };
        }
    }
}