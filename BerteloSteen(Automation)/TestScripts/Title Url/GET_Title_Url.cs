using DARS.Automation_.PageObjectsModels;
using DARS.Automation_.PageObjectsModels.Login;
using DARS.Automation_.TestScripts.Base_Classes;
using NUnit.Framework;
using System;


namespace DARS.Automation_.TestScripts.Title_Url
{
    [TestFixture]
    class GET_Title_Url : TestWiseLogin
    {

        [Test]
        [Obsolete]
        public void getUrlTitle()
        {
            GetPropertiesObjects prop = new GetPropertiesObjects();
            prop.GetDetails();


        }


    }
}
