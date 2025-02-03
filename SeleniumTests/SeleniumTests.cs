using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace SeleniumTestsTests;

[TestClass]
public sealed class MathematicsTests
{
    private static IWebDriver? driver;

    static void InitializeDriver(string userDataDir = "UserData", string profileDirectory = "Selenium")
    {
        if (null == driver)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument($"--user-data-dir={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userDataDir)}");
            options.AddArgument($"--profile-directory={profileDirectory}");
            options.AddArgument($"--disable-extensions");
            ChromeConfig chromeConfig = new ChromeConfig();
            new DriverManager().SetUpDriver(chromeConfig);
            driver = new ChromeDriver(options);
        }
    }

    static void CleanDriver()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }

    [TestMethod]
    public void OpenGoogle_NormalCase()
    {
        InitializeDriver();
        if (null != driver)
        {
            driver.Navigate().GoToUrl("https://www.google.com/");
            Assert.AreEqual(true, driver.Title.Contains("Google"));
            driver.Quit();
        }
    }

    [TestMethod]
    public void FontAwesome_NormalCase()
    {
        InitializeDriver();
        if (null != driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://fontawesome.com/");
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            Assert.AreEqual("Font Awesome", driver.Title);
            IWebElement iconLink = driver.FindElement(By.XPath("//a[@href='/icons']"));
            Assert.AreEqual("Icons", iconLink.Text);
            Assert.AreEqual("a", iconLink.TagName);
            iconLink.Click();
            wait.Until(d => d.Url.Contains("/icons"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            ReadOnlyCollection<IWebElement> inputs = driver.FindElements(By.Id("icons-search"));
            IWebElement input = inputs[inputs.Count() - 1];
            Assert.AreEqual("input", input.TagName);
            input.SendKeys("bar");
            input.SendKeys(Keys.Enter);
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button:has(i.fa-bolt)")));
            IWebElement iconFree = driver.FindElement(By.CssSelector("button:has(i.fa-bolt)"));
            Assert.AreEqual("Free", iconFree.Text);
            Assert.AreEqual("button", iconFree.TagName);
            iconFree.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("icons-results")));
            IWebElement divResult = driver.FindElement(By.Id("icons-results"));
            Assert.AreEqual("div", divResult.TagName);
            IWebElement firstButton = divResult.FindElement(By.TagName("button"));
            Assert.AreEqual("button", firstButton.TagName);
            firstButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("icon-detail-Bars")));
            ReadOnlyCollection<IWebElement> codeBlocks = driver.FindElements(By.ClassName("codeblock-container"));
            if (codeBlocks.Count() > 0)
            {
                string clipboard = "Sample text to clipboard";
                ((IJavaScriptExecutor)driver).ExecuteScript($"await navigator.clipboard.writeText('{clipboard}')");
                object resultClipboard = ((IJavaScriptExecutor)driver).ExecuteScript("return navigator.clipboard.readText()");
                Assert.AreEqual(clipboard, resultClipboard);
                IWebElement codeBlock = codeBlocks[codeBlocks.Count() - 1];
                codeBlock.Click();
                resultClipboard = ((IJavaScriptExecutor)driver).ExecuteScript("return await navigator.clipboard.readText()");
                Assert.AreEqual("<i class=\"fa-solid fa-bars\"></i>", resultClipboard);
            }
            else
            {
                Assert.Fail("Can not found code block");
            }
        }
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        CleanDriver();
    }
}
