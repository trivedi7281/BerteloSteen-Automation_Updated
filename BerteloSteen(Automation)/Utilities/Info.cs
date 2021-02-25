using NPOI.Util;
using NPOI.Util.Collections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.Utilities
{
    public class Info
    {
        public string baseURL;
        public string username;
        public string password;
        public Info()
        {
            baseURL = ConfigurationManager.AppSettings["url"];
            username = ConfigurationManager.AppSettings["username"];
            password = ConfigurationManager.AppSettings["password"];


        }

    }
    
}
