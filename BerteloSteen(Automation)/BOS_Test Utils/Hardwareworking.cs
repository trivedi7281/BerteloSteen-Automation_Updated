using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace BerteloSteen_Automation_.BOS_Test_Utils
{
    public static class Hardwareworking
    {

        public static void Hover(IWebElement element)
        {
            Actions action = new Actions(Drive.driver);
            System.Threading.Thread.Sleep(2000);
            action.MoveToElement(element).Click(element).Build().Perform();
            
        }
    }
}
