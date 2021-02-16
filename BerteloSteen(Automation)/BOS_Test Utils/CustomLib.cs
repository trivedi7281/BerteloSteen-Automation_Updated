using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_Test_Utils
{
    class CustomLib
    {
        public void WaitFortheLoadingIconDisappear20000()
        {
            System.Threading.Thread.Sleep(20000);
        }

        public void WaitFortheLoadingIconDisappear15000()
        {
            System.Threading.Thread.Sleep(15000);
        }

        public void WaitFortheLoadingIconDisappear10000()
        {
            System.Threading.Thread.Sleep(10000);
        }

        public void WaitFortheLoadingIconDisappear5000()
        {
            System.Threading.Thread.Sleep(5000);
        }

        public void WaitFortheLoadingIconDisappear2000()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public void WaitFortheLoadingIconDisappear1000()
        {
            System.Threading.Thread.Sleep(1000);
        }


        //[FindsBy(How = How.XPath, Using = "//div[@class ='loading x32']")]
        //public IList<IWebElement> PageLoader;

        //public void waitFortheLoadingPage()
        //{
        //    int count = 1;
        //    while(PageLoader.Count()!= && count < 10)
        //    {
        //        System.Threading.Thread.Sleep(2000);
        //        count++;
        //    }
        //}


      
    }
}
