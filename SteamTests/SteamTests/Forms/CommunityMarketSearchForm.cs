using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTests.Data;
using SteamTests.Managers;
using SteamTests.Pages;
using SteamTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Forms
{
    public class CommunityMarketSearchForm : BaseForm
    {
        private readonly By gameSelect = By.XPath("//*[@role='combobox'][.//*[contains(.,'Select a game')]]");
        private readonly By gameSearchInput = By.XPath("//*[@role='listbox']//input");
        private readonly By heroSelect = By.XPath("//*[@role='combobox'][.//*[contains(text(),'Hero')]]");
        private readonly By raritySelect = By.XPath("//*[@role='combobox'][.//*[contains(text(),'Rarity')]]");
        private readonly By search = By.XPath("//form[.//*[contains(.,'Search Community Market')]]//input");
        private readonly By searchButton = By.XPath("//button[@type='submit']");
        public CommunityMarketSearchForm() : base(By.ClassName("DialogContent_InnerWidth"))
        {
        }
        public void SelectGame(string name)
        {
            WaitUtility.WaitForElement(gameSelect).Click();
            WaitUtility.WaitForElement(gameSearchInput).SendKeys(name);
            By game = By.XPath($"//*[@role='listbox']//*[contains(text(),'{name}')]");
            WaitUtility.WaitForElement(game).Click();
        }
        public void SelectHero(string name)
        {
            WaitUtility.WaitForElement(heroSelect).Click();
            By hero = By.XPath($"//*[@role='option']//*[contains(text(),'{name}')]");
            WaitUtility.WaitForElement(hero).Click();
        }
        public void SelectRarity(string name)
        {
            WaitUtility.WaitForElement(raritySelect).Click();
            By rarity = By.XPath($"//*[@role='option']//*[contains(text(),'{name}')]");
            WaitUtility.WaitForElement(rarity).Click();
        }
        public void SearchElement(string name)
        {
            WaitUtility.WaitForElement(search).Clear();
            WaitUtility.WaitForElement(search).SendKeys(name);
        }
        public CommunityMarketSearchResultsPage Search()
        {
            WaitUtility.WaitForElement(searchButton).Click();
            return new CommunityMarketSearchResultsPage();
        }
    }
}
