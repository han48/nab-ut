using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestsTests;

[TestClass]
public sealed class MathematicsTests
{
    private static IWebDriver? driver;

    static void InitializeDriver(string userDataDir = "UserData", string profileDirectory = "Selenium")
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument($"--user-data-dir={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userDataDir)}");
        options.AddArgument($"--profile-directory={profileDirectory}");
        options.AddArgument($"--disable-extensions");
        ChromeConfig chromeConfig = new ChromeConfig();
        new DriverManager().SetUpDriver(chromeConfig);
        driver = new ChromeDriver(options);
    }

    [TestMethod]
    public void OpenWeb_NormalCase()
    {
        InitializeDriver();
        if (null != driver)
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            Assert.AreEqual(true, driver.Title.Contains("Google"));
            driver.Quit();
        }
    }
}
