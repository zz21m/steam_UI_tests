using SteamTests.Drivers;
using SteamTests.Managers;
using SteamTests.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SteamTests.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void Setup()
        {
            DriverManager.GetInstance();
            DriverManager.GetInstance().Navigate().GoToUrl(ConfigurationManager.GetInstance().BaseUrl);
        }
        [TearDown]
        public void TearDown()
        {
            DriverManager.QuitDriver();
            WaitUtility.ResetWait();
        }
    }
}
