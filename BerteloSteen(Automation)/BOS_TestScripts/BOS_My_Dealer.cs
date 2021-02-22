using BerteloSteen_Automation_.BOS_PageObjects;
using NUnit.Framework;
using System;


namespace BerteloSteen_Automation_.BOS_TestScripts
{
    [TestFixture]
    class BOS_My_Dealer : OnetimeSetup
    {
        public My_DealerObjects Dealer ;

        [Test, Order(1)]
        [Obsolete]
        public void CheckDealerDropdown()
        {
            Dealer = new My_DealerObjects();
            Dealer.ClickonDARS();
            Dealer.GetPageTitle();
            Dealer.SelectDealer("15");
        }

        [Test, Order(2)]
        [Obsolete]
        public void SelectRentalCarCompany()
        {
            Dealer = new My_DealerObjects();
            Dealer.SelectRentalCarComp_Dropdown();
        }
    }
}
