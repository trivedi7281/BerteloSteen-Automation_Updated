using DARS.Automation_.PageObjectsModels;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.TestScripts
{/// <summary>
/// This class is for when you want to login only one time 
/// and check the whole Page without any TearDown
/// </summary>
    public class OnetimeSetup
    {

        [OneTimeSetUp]
        [Obsolete]
        public void Login()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            Drive.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(2));
            Drive.driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //naviate to Url
            Drive.driver.Manage().Window.Maximize();
            Drive.driver.Manage().Cookies.DeleteAllCookies();
            Drive.driver.Navigate().GoToUrl("https://waqbolp01.azurewebsites.net/");
            Console.WriteLine("Navigated to the 'demo Home Page' URL Sucessfully");
            //Intitialize the page by calling it reference
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            LoginPageObjects loginpage = new LoginPageObjects();
            loginpage.EnterUserName("zedbxacp@bosbil.no");
            Console.WriteLine("UserName Entered");
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loginpage.EnterPassword("6d96E333yjB88ut");
            Console.WriteLine("Password Entered");
            Console.WriteLine("Stay Logged In");
            loginpage.StaySignedIN();
            Console.WriteLine("Logged In Sucessfully");

        }


        //[OneTimeTearDown]
        //public void Close()
        //{
        //    (Drive.driver as IJavaScriptExecutor).ExecuteScript("sessionStorage.clear();");
        //    (Drive.driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
        //    Drive.driver.Manage().Cookies.DeleteAllCookies();
        //    Drive.driver.Close();
        //    Drive.driver.Quit();
        //    Console.WriteLine("Closed the Browser");
        //}
    }
}
