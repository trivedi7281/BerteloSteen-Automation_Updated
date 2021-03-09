﻿using DARS.Automation_.PageObjectsModels.Workshop_settings;
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
            AppObject.AppointmentSearchVehicle("Search","DN58600");
            AppObject.AppointmentCreateOrSelectBooking("New","DN58600");
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
            AppObject.AddingPackage("Forrige søk");
            AppObject.AddModal("Add Package");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(9)]
        [Obsolete]
        public void AddService()
        {
            AppObject.AddActions("New", 1, 1, "Add Service");
            AppObject.ValidateAddPackageTitle("Add Service");
            AppObject.AddingService("Cool Season");
            AppObject.AddingService("Service");
            AppObject.AddModal("Add Service");
            AppObject.AddingService("Service");
            AppObject.AddModal("Add Service");
            CustomWait.WaitFortheLoadingIconDisappear3000();
        }

        [Test, Order(9)]
        [Obsolete]
        public void AddOperation()
        {
            AppObject.AddActions("New", 1, 1, "Add Operation");
            AppObject.ValidateAddPackageTitle("Add Operation");
            AppObject.AddingOperation("Testing Service" , "2");


        }







    }
}
