using BerteloSteen_Automation_.BOS_PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerteloSteen_Automation_.BOS_TestScripts
{
    [TestFixture]
    class BOS_My_Dealer : OnetimeSetup
    {
        public My_Dealer Dealer;

        [Test, Order(1)]
        [Obsolete]
        public void CheckDealerDropdown()
        {
            Dealer = new My_Dealer();
            Dealer.ClickonDARS();
            Dealer.GetPageTitle();
            Dealer.SelectDealer("15");
        }
    }
}
