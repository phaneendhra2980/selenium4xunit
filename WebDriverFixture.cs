using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

/// <summary>
/// WebDriverFixture code for XUnit to handle
/// Selenium WebDriver
/// </summary>
public class WebDriverFixture : IDisposable
{
    public ChromeDriver ChromeDriver { get; private set; }
    public WebDriverFixture()
    {
        //WebDriverManager
        ChromeDriver = new ChromeDriver();
    }

    

    public void Dispose()
    {
        // Do "global" teardown here; Only called once.
        ChromeDriver.Quit();
        ChromeDriver.Dispose();
    }


}
