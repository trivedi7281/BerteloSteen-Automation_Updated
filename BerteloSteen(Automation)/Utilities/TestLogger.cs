using DARS.Automation_.Helper;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
   
    public class TestLogger
    {
        public void MechanicsTableAllDatafound()
        {

            string MechanicsTable1 = "//*[@id='mechanicLeaves']/div/div[2]/div[2]/table/tbody/tr[";
            string MechanicsTable2 = "]/td[";
            string MechanicsTable3 = "]";
            int RCount = Drive.driver.FindElements(By.XPath("//*[@id='mechanicLeaves']/div/div[2]/div[2]/table/tbody/tr")).Count();
            Console.WriteLine("Rcount is:" + RCount);
            int CCount = Drive.driver.FindElements(By.XPath("//*[@id='mechanicLeaves']/div/div[2]/div[2]/table/tbody/tr[1]/td")).Count();
            Console.WriteLine("Ccount is:" + CCount);
            for (int i = 1; i <= RCount; i++)
            {
                for (int j = 1; j <= CCount; j++)
                {
                    string finalPart = MechanicsTable1 + i + MechanicsTable2 + j + MechanicsTable3;
                    IWebElement RowDataofMechanicTable = Drive.driver.FindElement(By.XPath(finalPart));
                    Console.WriteLine("RowData: " + RowDataofMechanicTable.Text);
                }
            }




        }

    }
}
