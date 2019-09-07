using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class DoctorController: Controller
    {
        public IDoctorRegistration DoctorRegistration { get; }

        public DoctorController(IDoctorRegistration doctorRegistration)
        {
            DoctorRegistration = doctorRegistration;
        }
        public ActionResult DoctorInfo()
        {
            return View(new Doctor());
        }
        [HttpPost]
        public ActionResult DoctorInfo(Doctor doctor)
        {
            try
            {
                DoctorRegistration.Register(doctor);
                return RedirectToAction("DoctorInfo");
            }
            catch
            {
                return View();
            }
        }
    }
}