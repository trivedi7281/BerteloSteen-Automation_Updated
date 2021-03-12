using DARS.Automation_.PageObjectsModels.Workshop_settings;
using DARS.Automation_.TestScripts.Base_Classes;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.TestScripts.Workshop_settings
{
    [TestFixture]
    class DealerService : OnetimeLogin
    {

        public DealerServiceObjects DSO;

        [Test, Order(1)]
        [Obsolete]
        public void TestingofDealerservices()
        {
            DSO = new DealerServiceObjects();
            DSO.ClickonDARS();
            DSO.GetPageTitle();
        }

    }
}
