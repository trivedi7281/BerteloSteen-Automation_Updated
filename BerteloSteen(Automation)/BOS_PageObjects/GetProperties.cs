using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_PageObjects
{
    class GetProperties
    {
        [Obsolete]
        public GetProperties()
        {
            PageFactory.InitElements(Drive.driver, this);
        }


        [Obsolete]
        public void GetDetails()
        {
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            String title = Drive.driver.Title;
            Console.WriteLine("Title is:" + title);
            Assert.AreEqual("BOS", title);
            String Url = Drive.driver.Url;
            Console.WriteLine("URL is:" + Url);
            //String pageSource = Drive.driver.PageSource;
            //Console.WriteLine("PageSource is:" + pageSource);

        }

    }
}
