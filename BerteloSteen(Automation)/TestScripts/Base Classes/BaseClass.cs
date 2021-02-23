
using DARS.Automation_.PageObjectsModels;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DARS.Automation_.TestScripts
{
    public class BaseClass
    {


        [SetUp]
        [Obsolete]
        public void Login()
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            Drive.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            Drive.driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
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


        [TearDown]
        public void Close()
        {
            (Drive.driver as IJavaScriptExecutor).ExecuteScript("sessionStorage.clear();");
            (Drive.driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
            Drive.driver.Manage().Cookies.DeleteAllCookies();
            Drive.driver.Close();
            Drive.driver.Quit();
            Console.WriteLine("Closed the Browser");
        }
    }
}
