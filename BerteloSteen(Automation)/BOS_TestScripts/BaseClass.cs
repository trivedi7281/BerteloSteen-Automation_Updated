using BerteloSteen_Automation_.BOS_PageObjects;
using BerteloSteen_Automation_.BOS_Test_Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Protractor;
using System;

namespace BerteloSteen_Automation_
{
    public class BaseClass
    {
        [SetUp]
        [Obsolete]
        public void Login()
        {
            Drive.driver = new ChromeDriver();
            Drive.ngdriver = new NgWebDriver(Drive.driver);
            //naviate to Url
            Drive.driver.Manage().Window.Maximize();
            Drive.driver.Manage().Cookies.DeleteAllCookies();
            Drive.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Drive.driver.Navigate().GoToUrl("https://login.microsoftonline.com/0abe8783-2c3e-4c42-9848-54e419bcdeb0/oauth2/v2.0/authorize?response_type=id_token&scope=user.read%20openid%20profile&client_id=08cad6e8-9985-4cad-810b-2dadf6fa42de&redirect_uri=https%3A%2F%2Fwaqbolp01.azurewebsites.net%2F&state=eyJpZCI6ImNkNzE0OTcxLWViY2EtNGJkYy04M2QyLTM3MWY2ODBiNmFhNiIsInRzIjoxNjEzMTM2Mzc4LCJtZXRob2QiOiJyZWRpcmVjdEludGVyYWN0aW9uIn0%3D&nonce=16236db8-94fc-40bf-8bae-94a1b2cb096a&client_info=1&x-client-SKU=MSAL.JS&x-client-Ver=1.3.2&client-request-id=d04395d1-bd00-43cb-8e3a-d0fdf865ba32&response_mode=fragment");
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


        [TearDown]
        public void Close()
        {
            Drive.driver.Close();
            Drive.driver.Quit();
            Console.WriteLine("Closed the Browser");
        }
    }
}
