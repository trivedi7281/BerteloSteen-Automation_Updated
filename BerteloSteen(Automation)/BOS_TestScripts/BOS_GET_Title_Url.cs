using BerteloSteen_Automation_.BOS_PageObjects;
using NUnit.Framework;
using System;


namespace BerteloSteen_Automation_.BOS_TestScripts
{
    [TestFixture]
    class BOS_GET_Title_Url : BaseClass
    {

        [Test]
        [Obsolete]
        public void getUrlTitle()
        { 
            GetProperties prop = new GetProperties();
            prop.GetDetails();
        }

    }
}
