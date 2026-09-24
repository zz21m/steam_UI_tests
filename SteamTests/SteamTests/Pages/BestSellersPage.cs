using OpenQA.Selenium;
using SteamTests.Drivers;
using SteamTests.Utilities;

namespace SteamTests.Pages;

public class BestSellersPage : BasePage
{
    private readonly By showMoreBestSellersButton = By.XPath("//button[@type='button' and contains(.,'Browse More Top Sellers')]");
    public BestSellersPage() : base(By.XPath("//*[contains(@class,'SteamChartsShell')]"))
    {
    }
    public MoreBestSellersPage OpenMoreBestSellers()
    {
        ((IJavaScriptExecutor)DriverManager.GetInstance()).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        WaitUtility.WaitForElement(showMoreBestSellersButton).Click();
        return new MoreBestSellersPage();
    }
}