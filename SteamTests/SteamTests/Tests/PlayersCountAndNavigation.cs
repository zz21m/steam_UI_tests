using SteamTests.Pages;
using SteamTests.Tests;

namespace SteamTests;

public class PlayersCountAndNavigation : BaseTest
{
    [Test]
    public void PlayersCountAndNavigationTest()
    {
        StorePage storePage = new StorePage();
        Assert.That(storePage.IsOpened(), Is.True, "Store page is not opened");

        AboutPage aboutPage = storePage.OpenAbout();
        Assert.That(aboutPage.IsOpened(), Is.True, "About page is not opened");

        Assert.That(aboutPage.GetCurrentPlayers(), Is.LessThan(aboutPage.GetOnlinePlayers()), "Current players count should be less than online players count");

        storePage = aboutPage.OpenStore();
        Assert.That(storePage.IsOpened(), Is.True, "Store page is not opened after returning from About");
    }
}
