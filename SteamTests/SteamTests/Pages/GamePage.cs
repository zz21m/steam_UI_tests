using OpenQA.Selenium;
using SteamTests.Managers;
using SteamTests.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace SteamTests.Pages;

public class GamePage : BasePage
{

    private readonly By gameName = By.Id("appHubAppName");
    private readonly By releaseDate = By.XPath("//*[@id='glanceMidCtn']//*[@class='date']");
    private readonly By freePrice = By.XPath("//*[@id='freeGameBtn']/preceding-sibling::*");
    private readonly By finalPrice = By.XPath(" //*[@class='game_area_purchase_game_wrapper']//*[@class='discount_final_price']");
    private readonly By purchasePrice = By.XPath("//*[contains(@class,'game_purchase_price') and @data-price-final]");

    public GamePage() : base(By.Id("gameHeaderCtn"))
    {
    }
    public string GetGameName()
    {
        return WaitUtility.WaitForElement(gameName).Text;
    }
    public string GetReleaseDate()
    {
        return WaitUtility.WaitForElement(releaseDate).Text;
    }
    public string GetPrice()
    {
        return WaitUtility.GetInstance().Until(d =>
        {
            if (d.FindElements(freePrice).Count > 0)
            {
                return "Free";
            }
            if (d.FindElements(finalPrice).Count > 0)
            {
                return new string(d.FindElement(finalPrice).Text.Where(char.IsDigit).ToArray());
            }
            if (d.FindElements(purchasePrice).Count > 0)
            {
                return new string(d.FindElement(purchasePrice).Text.Where(char.IsDigit).ToArray());
            }
            return null;
        });
    }

}