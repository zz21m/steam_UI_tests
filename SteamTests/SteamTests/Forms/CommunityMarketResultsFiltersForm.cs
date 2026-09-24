using OpenQA.Selenium;
using SteamTests.Data;
using SteamTests.Managers;
using SteamTests.Utilities;

namespace SteamTests.Forms
{
    public class CommunityMarketResultsFiltersForm : BaseForm
    {
        private readonly By gameFilter = By.XPath($"//*[@role='combobox']//*[contains(text(),'{TestDataManager.GetInstance().Game}')]");
        private readonly By heroFilter = By.XPath($"//*[@role='combobox']//*[contains(text(),'{TestDataManager.GetInstance().Hero}')]");
        private readonly By rarityFilter = By.XPath($"//*[@role='combobox']//*[contains(text(),'{TestDataManager.GetInstance().Rarity}')]");
        private readonly By searchFilter = By.XPath($"//input[@type='text' and @value='{TestDataManager.GetInstance().Search}']");
        private readonly By searchFilterRemove = By.XPath("//input[@placeholder='Filter Results...']/parent::*//following-sibling::*");
        public CommunityMarketResultsFiltersForm() : base()
        {
        }
        public string GetGameFilter()
        {
            return WaitUtility.WaitForElement(gameFilter).Text;
        }
        public string GetHeroFilter()
        {
            return WaitUtility.WaitForElement(heroFilter).Text;
        }
        public string GetRarityFilter()
        {
            return WaitUtility.WaitForElement(rarityFilter).Text;
        }
        public string GetSearchFilter()
        {
            return WaitUtility.WaitForElement(searchFilter).GetAttribute("value");
        }
        public void RemoveSearchFilter()
        {
            WaitUtility.WaitForElement(searchFilterRemove).Click();
        }
    }
}