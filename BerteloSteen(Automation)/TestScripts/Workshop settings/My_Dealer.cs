using DARS.Automation_.PageObjectsModels;
using DARS.Automation_.PageObjectsModels.Workshop_settings;
using DARS.Automation_.TestScripts.Base_Classes;
using NUnit.Framework;
using System;


namespace DARS.Automation_.TestScripts.Workshop_settings
{
    [TestFixture]
    class My_Dealer : OnetimeLogin
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
            Dealer.SelectRentalCarComp_Dropdown("1" , "10" , "HDFC Argo");
        }

        //[Test, Order(3)]
        //[Obsolete]
        //public void ValidateCheckboxes()
        //{
        //    Dealer = new My_DealerObjects();
        //    Dealer.ValidateAllCheckBoxes();
        //}
    }
}
