using Microsoft.Testing.Platform.Configurations;
using OpenQA.Selenium;
using SteamTests.BusinessObjects;
using SteamTests.Data;
using SteamTests.Drivers;
using SteamTests.Managers;
using SteamTests.Pages;
using SteamTests.Tests;

namespace SteamTests;

public class BestSellersFiltering : BaseTest
{
    [Test]
    public void BestSellersFilteringTest()
    {
        StorePage storePage = new StorePage();
        Assert.That(storePage.IsOpened(), Is.True, "Store page is not opened");

        BestSellersPage bestSellersPage = storePage.OpenBestSellers();
        Assert.That(bestSellersPage.IsOpened(), Is.True, "Best Sellers page is not opened");

        MoreBestSellersPage moreBestSellersPage = bestSellersPage.OpenMoreBestSellers();
        Assert.That(moreBestSellersPage.IsOpened(), Is.True, "More Best Sellers page is not opened");

        Assert.That(moreBestSellersPage.Filters.SelectOS(TestDataManager.GetInstance().OperatingSystem), Is.True, "Operating system filter is not selected");
        Assert.That(moreBestSellersPage.Filters.SelectNumberOfPlayers(TestDataManager.GetInstance().Players), Is.True, "Players filter is not selected");
        Assert.That(moreBestSellersPage.Filters.SelectTag(TestDataManager.GetInstance().Tag), Is.True, "Tag filter is not selected");

        Assert.That(moreBestSellersPage.GetGamesCount(), Is.EqualTo(moreBestSellersPage.GetResultsCount()), "Games count does not match results count");

        Game game = moreBestSellersPage.GetFirstGame();
        GamePage gamePage = moreBestSellersPage.OpenFirstGame();
        Assert.That(gamePage.IsOpened(), Is.True, "Game page is not opened");

        Assert.That(gamePage.GetGameName(), Is.EqualTo(game.Name), "Game name does not match");
        Assert.That(gamePage.GetReleaseDate(), Is.EqualTo(game.ReleaseDate), "Release date does not match");
        Assert.That(gamePage.GetPrice(), Is.EqualTo(game.Price), "Game price does not match");
    }
}
