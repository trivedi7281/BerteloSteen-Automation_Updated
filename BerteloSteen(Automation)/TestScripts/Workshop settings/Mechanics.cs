using DARS.Automation_.PageObjectsModels;
using NUnit.Framework;
using System;


namespace DARS.Automation_.TestScripts
{
    [TestFixture]
    class Mechanics : OnetimeSetup
    {
        
        public MechanicsObjects Mech;
        
        [Test , Order(1)]
        [Obsolete]
        public void CheckDealerDropdown()
        {
            Mech = new MechanicsObjects();
            Mech.ClickonDARS();
            Mech.GetPageTitle();
            Mech.SelectDealer("15");
        }

        [Test, Order(2)]
        [Obsolete]
        public void CheckSearchBar()
        {
            Mech = new MechanicsObjects();
            Mech.SearchBar("Alexander Almeland Jensen");
            Mech.CheckTablefoundtheSearchData();
        }

        //[Test, Order(3)]
        //[Obsolete]
        //public void CheckPDFFunctionality()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.clickToCreatePDF();
        //}

        //[Test, Order(4)]
        //[Obsolete]
        //public void CheckExcelFunctionality()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.clickToCreateExcel();
        //}


        [Test, Order(5)]
        [Obsolete]
        public void ClickPencilBtn()
        {
            Mech = new MechanicsObjects();
            Mech.clickintoActionBtn();
        }


        //[Test, Order(6)]
        //[Obsolete]
        //public void ClickGeneralInfoTab()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.GeneralInfoTab();
        //}

        //[Test, Order(7)]
        //[Obsolete]
        //public void ClickAssociateBrandTab()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.AssociateBrandsTab();
        //}


        [Test, Order(8)]
        [Obsolete]
        public void EnterIntoMechanicsLeaveTab()
        {
            Mech = new MechanicsObjects();
            Mech.MechanicLeavesTab();

        }


        [Test, Order(9)]
        [Obsolete]
        public void ClickintoAddMechanicLeavesTab()
        {
            Mech = new MechanicsObjects();
            Mech.AddMechanicLeavesTab();

        }

        //[Test, Order(10)]
        //[Obsolete]
        //public void CheckValidationsonMechanicLeavePage()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.CheckMechanicLeavePageValidations();

        //}

        [Test, Order(11)]
        [Obsolete]
        public void EnterMechanicLeaveDetails()
        {
            Mech = new MechanicsObjects();
            Mech.EnterMechanicLeaveDetails();

        }

        //[Test, Order(12)]
        //[Obsolete]
        //public void EnterIntoMechanicsAbsenceTab()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.mechanicBusinessAbsenceTab();

        //}

        //[Test, Order(13)]
        //[Obsolete]
        //public void ClickintoMechanicBusinessAbsenceTab()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.addMechanicBusinessAbsenceTab();
        //}


        //[Test, Order(14)]
        //[Obsolete]
        //public void CheckMechanicBusinessAbsenceValidations()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.CheckMechanicBusinessAbsencePageValidations();
        //}

        //[Test, Order(15)]
        //[Obsolete]
        //public void EnterMechanicBusinessAbsenceDetails()
        //{
        //    Mech = new Mechanics();
        //    Mech.EnterMechanicBusinessAbsenceDetails();

        //}


        //[Test, Order(16)]
        //[Obsolete]
        //public void ClickintoMechanicRecipientListTab()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.MechanicRecipientListTab();
        //}


        //[Test, Order(17)]
        //[Obsolete]
        //public void ExitMechanicDetailsPage()
        //{
        //    Mech = new MechanicsObjects();
        //    Mech.ExitFromMechanicDetailsPage();

        //}







    }
}
