using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTests.Data;
using SteamTests.Managers;
using SteamTests.Utilities;

namespace SteamTests.Forms;

public class BestSellersFilterForm : BaseForm
{
    private readonly By numberOfPlayersSection = By.XPath("//*[@data-collapse-name='category3']");
    private readonly By tagSearch = By.Id("TagSuggest");
    public BestSellersFilterForm() : base()
    {
    }
    public bool SelectOS(string name)
    {
        By OSCheckbox = By.XPath($"//*[@role='button' and contains(@data-loc,'{name}')]");
        WaitUtility.WaitForElement(OSCheckbox).Click();
        return WaitUtility.WaitForElement(OSCheckbox).GetAttribute("class")?.Contains("checked") == true;

    }
    public bool SelectNumberOfPlayers(string name)
    {
        By numberOfPlayersCheckbox = By.XPath($"//*[@role='button' and contains(@data-loc,'{name}')]");
        WaitUtility.WaitForElement(numberOfPlayersSection).Click();
        WaitUtility.WaitForElement(numberOfPlayersCheckbox).Click();
        return WaitUtility.WaitForElement(numberOfPlayersCheckbox).GetAttribute("class")?.Contains("checked") == true;
    }
    public bool SelectTag(string name)
    {
        By tagCheckbox = By.XPath($"//*[@role='button' and contains(@data-loc,'{name}')]");
        WaitUtility.WaitForElement(tagSearch).Clear();
        WaitUtility.WaitForElement(tagSearch).SendKeys(TestDataManager.GetInstance().Tag);
        WaitUtility.WaitForElement(tagCheckbox).Click();
        return WaitUtility.WaitForElement(tagCheckbox).GetAttribute("class")?.Contains("checked") == true;
    }
}