using SteamTests.BusinessObjects;
using SteamTests.Forms;
using SteamTests.Managers;
using SteamTests.Pages;
using SteamTests.Tests;

namespace SteamTests;

public class MarketSearch : BaseTest
{
    [Test]
    public void MarketSearchTest()
    {
        StorePage storePage = new StorePage();
        Assert.That(storePage.IsOpened(), Is.True, "Store page is not opened");

        CommunityMarketPage communityMarketPage = storePage.OpenMarket();
        Assert.That(communityMarketPage.IsOpened(), Is.True, "Community Market page is not opened");

        CommunityMarketSearchForm communityMarketSearchForm = communityMarketPage.OpenAdvancedSearch();
        Assert.That(communityMarketSearchForm.IsOpened(), Is.True, "Search form is not opened");

        communityMarketSearchForm.SelectGame(TestDataManager.GetInstance().Game);
        communityMarketSearchForm.SelectHero(TestDataManager.GetInstance().Hero);
        communityMarketSearchForm.SelectRarity(TestDataManager.GetInstance().Rarity);
        communityMarketSearchForm.SearchElement(TestDataManager.GetInstance().Search);

        CommunityMarketSearchResultsPage communityMarketSearchResultsPage = communityMarketSearchForm.Search();
        Assert.That(communityMarketSearchResultsPage.IsOpened(), Is.True, "Search results page is not opened");
        Assert.That(communityMarketSearchResultsPage.Filters.GetGameFilter(), Is.EqualTo(TestDataManager.GetInstance().Game), "Game filter does not match");
        Assert.That(communityMarketSearchResultsPage.Filters.GetHeroFilter(), Is.EqualTo(TestDataManager.GetInstance().Hero), "Hero filter does not match");
        Assert.That(communityMarketSearchResultsPage.Filters.GetRarityFilter(), Is.EqualTo(TestDataManager.GetInstance().Rarity), "Rarity filter does not match");
        Assert.That(communityMarketSearchResultsPage.Filters.GetSearchFilter(), Is.EqualTo(TestDataManager.GetInstance().Search), "Search filter does not match");

        foreach (var item in communityMarketSearchResultsPage.GetItems().Take(5))
        {
            Assert.That(item, Does.Contain(TestDataManager.GetInstance().Search).IgnoreCase, "Search result does not contain the search text");
        }

        int resultsBefore = communityMarketSearchResultsPage.GetResultsCount();
        communityMarketSearchResultsPage.Filters.RemoveSearchFilter();
        communityMarketSearchResultsPage.WaitForResultsCountChange(resultsBefore);
        int resultsAfter = communityMarketSearchResultsPage.GetResultsCount();
        Assert.That(resultsAfter, Is.Not.EqualTo(resultsBefore), "Results count did not change");

        string gameFilter = communityMarketSearchResultsPage.Filters.GetGameFilter();
        string heroFilter = communityMarketSearchResultsPage.Filters.GetHeroFilter();
        string rarityFilter = communityMarketSearchResultsPage.Filters.GetRarityFilter();
        string firstItemName = communityMarketSearchResultsPage.GetFirstItemName();
        CommunityMarketItemPage itemPage = communityMarketSearchResultsPage.OpenFirstItem();
        Assert.That(itemPage.IsOpened(), Is.True, "Item page is not opened");
        MarketItem marketItem = itemPage.GetItem();
        Assert.That(marketItem.Name, Is.EqualTo(firstItemName), "Item name does not match");
        Assert.That(marketItem.Game, Is.EqualTo(gameFilter), "Game does not match");
        Assert.That(marketItem.Hero, Is.EqualTo(heroFilter), "Hero does not match");
        Assert.That(marketItem.Rarity, Is.EqualTo(rarityFilter), "Rarity does not match");
    }
}
