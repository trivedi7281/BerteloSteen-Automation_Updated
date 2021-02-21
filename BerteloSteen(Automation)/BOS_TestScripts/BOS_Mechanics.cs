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
            Mech.SelectDealer("15");
        }

        [Test, Order(2)]
        [Obsolete]
        public void CheckSearchBar()
        {
            Mech = new Mechanics();
            Mech.SearchBar("Alexander Almeland Jensen");
            Mech.CheckTablefoundtheSearchData();
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


        [Test, Order(5)]
        [Obsolete]
        public void ClickPencilBtn()
        {
            Mech = new Mechanics();
            Mech.clickintoActionBtn();
        }

        [Test, Order(6)]
        [Obsolete]
        public void EnterIntoMechanicsLeaveTab()
        {
            Mech = new Mechanics();
            Mech.MechanicLeavesTab();

        }


        [Test, Order(7)]
        [Obsolete]
        public void ClickintoAddMechanicLeavesTab()
        {
            Mech = new Mechanics();
            Mech.AddMechanicLeavesTab();

        }

        [Test, Order(8)]
        [Obsolete]
        public void CheckValidationsonMechanicLeavePage()
        {
            Mech = new Mechanics();
            Mech.CheckMechanicLeavePageValidations();

        }

        [Test, Order(9)]
        [Obsolete]
        public void EnterMechanicLeaveDetails()
        {
            Mech = new Mechanics();
            Mech.EnterMechanicLeaveDetails();

        }

        [Test, Order(10)]
        [Obsolete]
        public void EnterIntoMechanicsAbsenceTab()
        {
            Mech = new Mechanics();
            Mech.mechanicBusinessAbsenceTab();

        }

        [Test, Order(11)]
        [Obsolete]
        public void ClickintoMechanicBusinessAbsenceTab()
        {
            Mech = new Mechanics();
            Mech.addMechanicBusinessAbsenceTab();
        }


        [Test, Order(12)]
        [Obsolete]
        public void CheckMechanicBusinessAbsenceValidations()
        {
            Mech = new Mechanics();
            Mech.CheckMechanicBusinessAbsencePageValidations();
        }

        [Test, Order(13)]
        [Obsolete]
        public void EnterMechanicBusinessAbsenceDetails()
        {
            Mech = new Mechanics();
            Mech.EnterMechanicBusinessAbsenceDetails();

        }

        [Test, Order(14)]
        [Obsolete]
        public void ExitMechanicDetailsPage()
        {
            Mech = new Mechanics();
            Mech.ExitFromMechanicDetailsPage();

        }







    }
}
