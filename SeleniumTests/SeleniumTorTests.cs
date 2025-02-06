using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;

namespace SeleniumTestsTests;

// [TestClass]
public sealed class SeleniumTorTests
{
    private static IWebDriver? driver;
    private static string torPath = @"C:\Users\Desktop\Desktop\Tor Browser\Browser\firefox.exe";
    private static Process? torProcess { get; set; }

    static void InitializeDriver()
    {
        if (null == driver)
        {
            torProcess = new Process();
            torProcess.StartInfo.FileName = torPath;
            torProcess.StartInfo.Arguments = "-n";
            torProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            torProcess.Start();
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("network.proxy.type", 1);
            profile.SetPreference("network.proxy.socks", "127.0.0.1");
            profile.SetPreference("network.proxy.socks_port", 9150);
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            driver = new FirefoxDriver(options);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver = new FirefoxDriver(options);
        }
    }

    static void CleanDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
        if (torProcess != null)
        {
            torProcess.Kill();
            torProcess = null;
        }
    }

    [TestMethod]
    public void Tor_MyIp()
    {
        InitializeDriver();
        if (null != driver)
        {
            driver.Navigate().GoToUrl("http://whatismyipaddress.com");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            By expression = By.Id("ipv6");
            wait.Until(x => x.FindElement(expression));
            IWebElement element = driver.FindElement(expression);
            Assert.IsNotNull(element.Text);
            expression = By.Id("ipv4");
            wait.Until(x => x.FindElement(expression));
            element = driver.FindElement(expression);
            Assert.IsNotNull(element.Text);
        }
    }

    [TestInitialize]
    public void TestInitialize()
    {
        ;
    }

    [TestCleanup]
    public void TestCleanup()
    {
        CleanDriver();
    }

}
