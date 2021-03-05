using DARS.Automation_.PageObjectsModels.Workshop_settings;
using DARS.Automation_.TestScripts.Base_Classes;
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
            AppObject.AppointmentSearchVehicle("AdvanceSearch" , "DN58600" , "License plate");
            AppObject.AppointmentCreateOrSelectBooking("Active", "DN58600");
            AppObject.AppointmentDetailscreen("Active");
            AppObject.CreateNewDemand("Active");
            //AppObject.ValidateSDCR("Active");
        }

     



    }
}
