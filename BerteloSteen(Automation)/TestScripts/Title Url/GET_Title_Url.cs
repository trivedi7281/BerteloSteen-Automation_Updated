using DARS.Automation_;
using DARS.Automation_.GetSet;
using DARS.Automation_.PageObjectsModels;
using NUnit.Framework;
using System;


namespace DARS.Automation_.TestScripts
{
    [TestFixture]
    class GET_Title_Url : BaseClass
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
