using OpenQA.Selenium;
using SteamTests.Forms;
using SteamTests.Utilities;

namespace SteamTests.Pages
{
    public class CommunityMarketPage : BasePage
    {
        private readonly By advancedSearchButton = By.Id("market_search_advanced_show");
        public CommunityMarketPage() : base(By.Id("popularItemsTable"))
        {
        }
        public CommunityMarketSearchForm OpenAdvancedSearch()
        {
            WaitUtility.WaitForElement(advancedSearchButton).Click();
            return new CommunityMarketSearchForm();
        }
    }
}