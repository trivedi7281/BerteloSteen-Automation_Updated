using BerteloSteen_Automation_.BOS_PageObjects;
using BerteloSteen_Automation_.BOS_Test_Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_TestScripts
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
            CustomLib Stop = new CustomLib();
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            Drive.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
            Drive.driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            //naviate to Url
            Drive.driver.Manage().Window.Maximize();
            Drive.driver.Manage().Cookies.DeleteAllCookies();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Drive.driver.Navigate().GoToUrl("https://waqbolp01.azurewebsites.net/");
            Console.WriteLine("Navigated to the 'demo Home Page' URL Sucessfully");
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Intitialize the page by calling it reference
            LoginPageObjects loginpage = new LoginPageObjects();
            loginpage.EnterUserName("zedbxacp@bosbil.no");
            Console.WriteLine("UserName Entered");
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            loginpage.EnterPassword("6d96E333yjB88ut");
            Console.WriteLine("Password Entered");
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Console.WriteLine("Stay Logged In");
            loginpage.StaySignedIN();
            Console.WriteLine("Logged In Sucessfully");

        }


        [OneTimeTearDown]
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
