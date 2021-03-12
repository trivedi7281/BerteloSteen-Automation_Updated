using DARS.Automation_.PageObjectsModels.Workshop_settings;
using DARS.Automation_.TestScripts.Base_Classes;
using DARS.Automation_.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DARS.Automation_.TestScripts.Workshop_settings
{
    class Appointment : OnetimeLogin
    {
        public AppointmentObjects AppObject;

        [Test, Order(1)]
        [Obsolete]
        public void SelectTheLanguage()
        {
            AppObject = new AppointmentObjects();
            AppObject.ClickonLanguage();
        }

        [Test, Order(2)]
        [Obsolete]
        public void GetSelectedPageTitle()
        {
            AppObject = new AppointmentObjects();
            AppObject.GetPageTitle();
        }

        [Test, Order(3)]
        [Obsolete]
        public void SelectAppointmentStatus()
        {
            AppObject = new AppointmentObjects();
            AppObject.AppointmentStatus("Pending");
        }

        [Test, Order(4)]
        [Obsolete]
        public void SelectAppointmentType()
        {
            AppObject = new AppointmentObjects();
            AppObject.AppointmentType("Body Repair");
        }

        [Test, Order(5)]
        [Obsolete]
        public void StatusBarDetails()
        {
            AppObject = new AppointmentObjects();
            AppObject.AppointmentStatus("All");
            AppObject.AppointmentType("All");
            AppObject.StatusBarDtl();
        }

        [Test, Order(6)]
        [Obsolete]
        public void ClickonCreateAppointment()
        {
            AppObject = new AppointmentObjects();
            AppObject.ClickCreateAppointment();
            AppObject.AppointmentSelectWorkOrder("Appointment");
            AppObject.AppointmentSelectDealer("0", "031");
            AppObject.AppointmentSearchVehicle("Search", "DN58600");
            AppObject.AppointmentCreateOrSelectBooking("New", "DN58600");
            AppObject.AppointmentDetailscreen("New");
        }

        [Test, Order(7)]
        [Obsolete]
        public void ClickonCreateDemand()
        {
            AppObject.CreateNewDemand("New");
            AppObject.ValidateSDCR("New");
            AppObject.EnterShortDescription("New", 1, "Test Appointment short Description");
            AppObject.EnterCustomerRequirement("New", 1, "Test Appointment Customer Requirement");
        }

        [Test, Order(8)]
        [Obsolete]
        public void AddPackage()
        {
            AppObject.AddActions("New", 1, 1, "Add Package");
            AppObject.ValidateAddPackageTitle("Add Package");
            AppObject.AddModal("Add Package");
            AppObject.AddingPackage("Forrige søk");
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AppObject.AddModal("Add Package");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(9)]
        [Obsolete]
        public void AddService()
        {
            AppObject.AddActions("New", 1, 2, "Add Service");
            AppObject.ValidateAddPackageTitle("Add Service");
            AppObject.AddingService("Cool Season");
            AppObject.AddingService("Service");
            AppObject.AddModal("Add Service");
            AppObject.AddingService("Service");
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AppObject.AddModal("Add Service");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(9)]
        [Obsolete]
        public void AddOperation()
        {
            AppObject.AddActions("New", 1, 2, "Add Operation");
            AppObject.ValidateAddPackageTitle("Add Operation");
            AppObject.AddingOperation("Testing Service", "2");
            AppObject.AddModal("Add Operation");
            AppObject.AgainAddingOperation("2");
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AppObject.AddModal("Add Operation");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }


        [Test, Order(10)]
        [Obsolete]
        public void AddMaterial()
        {
            AppObject.AddActions("New", 1, 2, "Add Material");
            AppObject.ValidateAddPackageTitle("Add Material");
            AppObject.AddModal("Add Material");
            AppObject.AddingMaterial("2", "2");
            AppObject.AddModal("Add Material");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(11)]
        [Obsolete]
        public void AddAOP()
        {
            AppObject.AddActions("New", 1, 2, "Add AOP");
            AppObject.ValidateAddPackageTitle("Add AOP");
            AppObject.AddModal("Add AOP");
            CustomWait.WaitFortheLoadingIconDisappear5000();
            AppObject.selectOperationGroup("Forrige søk");
            CustomWait.WaitFortheLoadingIconDisappear10000();
            CustomWait.WaitFortheLoadingIconDisappear3000();
            AppObject.AddingAOP("007941");
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AppObject.DeletingAOP("007941");
            CustomWait.WaitFortheLoadingIconDisappear2000();
            AppObject.AddingAOP("007941");
            AppObject.AddModal("Add AOP");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(12)]
        [Obsolete]
        public void ChangeFixedPrice()
        {
            AppObject.ChangingFixedPrice("1000", "Other reason", "Testing by changing the Fixed Price");
            AppObject.ValidateInHistory("Testing by changing the Fixed Price");
        }

        [Test, Order(13)]
        [Obsolete]
        public void CustomerApproval()
        {
            AppObject.GiveCustomerApproval("Approve on behalf of customer", "Testing Comment");
        }

        [Test, Order(14)]
        [Obsolete]
        public void Warranty()
        {
            AppObject.GiveWarranty();
        }


        [Test, Order(15)]
        [Obsolete]
        public void SaveAppointment()
        {
            AppObject.AppointmentButtons("Save");
        }












    }
}
