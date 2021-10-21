using OpenQA.Selenium;


public static class Utility
{
    
    public static void CaptureScreenshot(WebDriverFixture webDriverFixture)
    {

        // Screenshot for the element
        var elementScreenshot = (webDriverFixture.ChromeDriver as ITakesScreenshot).GetScreenshot();
        elementScreenshot.SaveAsFile("C:\\Automation\\selenium4xunit\\Screenshots\\" + DateTime.Now.ToString("_yyyyMMdd") + "screen_shot.png");
    }
}