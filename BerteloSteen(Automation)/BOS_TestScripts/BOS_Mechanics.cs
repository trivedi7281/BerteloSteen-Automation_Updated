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
    class BOS_Mechanics : OnetimeSetup
    {
        
        public Mechanics Mech;
        
        [Test , Order(1)]
        [Obsolete]
        public void CheckDealerDropdown()
        {
            Mech = new Mechanics();
            Mech.ClickonDARS();
            Mech.GetPageTitle();
            //On Function it will click on the selected dealer and show the details.
            Mech.SelectDealer("015" , "97");
        }

        [Test, Order(2)]
        [Obsolete]
        public void CheckSearchBar()
        {
            Mech = new Mechanics();
            Mech.SearchBar("Alexander Almeland Jensen");
        }

        [Test, Order(3)]
        [Obsolete]
        public void CheckPDFFunctionality()
        {
            Mech = new Mechanics();
            Mech.clickToCreatePDF();
        }

        [Test, Order(4)]
        [Obsolete]
        public void CheckExcelFunctionality()
        {
            Mech = new Mechanics();
            Mech.clickToCreateExcel();
        }


    }
}
