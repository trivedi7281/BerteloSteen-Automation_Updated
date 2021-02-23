using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Linq;


namespace BerteloSteen_Automation_.BOS_Test_Utils
{
    public class CommonHooks
    {
        private readonly IWebDriver _driver;

        
        public CommonHooks(IWebDriver driver) => _driver = driver;

        public List<IWebElement> loadingIcon => (List<IWebElement>)_driver.FindElement(By.XPath("//div[@class='loading x32']"));


        public void waitForLoadingIconToDiappear()
        {
            int count = 0;
            while(loadingIcon.Count()!=0 && count<10)
            {
                System.Threading.Thread.Sleep(2000);
                count++;
            }
        }

    }
    
}
