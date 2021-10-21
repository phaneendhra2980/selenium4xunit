using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Xunit.Abstractions;




public class Selenium4UnitTest : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture webDriverFixture;
    private readonly ITestOutputHelper testOutputHelper;

    public Selenium4UnitTest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
    {
        this.webDriverFixture = webDriverFixture;
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test_without_DataDriven()
    {
        WebDriverWait wait = new WebDriverWait(webDriverFixture.ChromeDriver, TimeSpan.FromSeconds(10));
        webDriverFixture.ChromeDriver.Navigate().GoToUrl("https://www.google.com/");
        //testOutputHelper.WriteLine("Opened Google Page");
        webDriverFixture.ChromeDriver.Manage().Window.Maximize();
        IWebElement agreebutton = webDriverFixture.ChromeDriver.FindElement(By.Id("L2AGLb"));
        //Utility.CaptureScreenshot(webDriverFixture.ChromeDriver);
        agreebutton.Click();
        testOutputHelper.WriteLine("Clicked agree button");

        webDriverFixture.ChromeDriver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
        testOutputHelper.WriteLine("Entered search term cheese");
        wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
        IWebElement firstResult = webDriverFixture.ChromeDriver.FindElement(By.CssSelector("h3"));
        testOutputHelper.WriteLine(firstResult.GetAttribute("textContent"));
    }


    [Theory]
    [InlineData("csharp")]
    [InlineData("Selenium")]
    [InlineData("Python")]
    public void Test_with_Theory_DataDriven(string value)
    {
        WebDriverWait wait = new WebDriverWait(webDriverFixture.ChromeDriver, TimeSpan.FromSeconds(10));
        webDriverFixture.ChromeDriver.Url = "https://www.google.com/";
        testOutputHelper.WriteLine("Opened Google Page");
        webDriverFixture.ChromeDriver.Manage().Window.Maximize();
        IWebElement agreebutton = webDriverFixture.ChromeDriver.FindElement(By.Id("L2AGLb"));
        //Utility.CaptureScreenshot(webDriverFixture.ChromeDriver);
        agreebutton.Click();
        testOutputHelper.WriteLine("Clicked agree button");

        webDriverFixture.ChromeDriver.FindElement(By.Name("q")).SendKeys(value + Keys.Enter);
        testOutputHelper.WriteLine("Entered search term" + value);
        wait.Until(webDriver => webDriver.FindElement(By.CssSelector("h3")).Displayed);
        IWebElement firstResult = webDriverFixture.ChromeDriver.FindElement(By.CssSelector("h3"));
        testOutputHelper.WriteLine(firstResult.GetAttribute("textContent"));
    }


}