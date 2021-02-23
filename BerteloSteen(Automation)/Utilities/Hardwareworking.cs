using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace DARS.Automation_.Utilities
{
    public static class Hardwareworking
    {

        public static void Hover(IWebElement element)
        {
            Actions action = new Actions(Drive.driver);
            System.Threading.Thread.Sleep(1000);
            action.MoveToElement(element).Click(element).Build().Perform();
            
        }
    }
}
