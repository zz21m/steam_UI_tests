using OpenQA.Selenium;
using SteamTests.BusinessObjects;
using SteamTests.Forms;
using SteamTests.Managers;
using SteamTests.Utilities;
using System.Text.RegularExpressions;

namespace SteamTests.Pages
{
    public class CommunityMarketSearchResultsPage : BasePage
    {
        private readonly By items = By.XPath("//a[contains(@href,'/market/listings/570/')]");
        private readonly By resultsCount = By.XPath("//*[contains(text(),'results for:')]");
        private readonly By firstItem = By.XPath("//a[contains(@href,'/market/listings/570/')][1]//*");

        public CommunityMarketResultsFiltersForm Filters { get; }

        public CommunityMarketSearchResultsPage() : base(By.XPath("//a//*[text()='Steam Community Market']"))
        {
            Filters = new CommunityMarketResultsFiltersForm();
        }
        public List<string> GetItems()
        {
            return WaitUtility.WaitForElements(items).Select(e => e.Text).ToList();
        }
        public int GetResultsCount()
        {
            return int.Parse(new string(WaitUtility.WaitForElement(resultsCount).Text.Where(char.IsDigit).ToArray()));
        }

        public void WaitForResultsCountChange(int oldCount)
        {
            WaitUtility.GetInstance().Until(d =>
            {
                int currentCount = int.Parse(new string(WaitUtility.WaitForElement(resultsCount).Text.Where(char.IsDigit).ToArray()));
                return currentCount != oldCount;
            });
        }
        public string GetFirstItemName()
        {
            return WaitUtility.WaitForElement(firstItem)
                .Text
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)[1]
                .Trim();
        }
        public CommunityMarketItemPage OpenFirstItem()
        {
            WaitUtility.WaitForElement(firstItem).Click();
            return new CommunityMarketItemPage();
        }

    }
}