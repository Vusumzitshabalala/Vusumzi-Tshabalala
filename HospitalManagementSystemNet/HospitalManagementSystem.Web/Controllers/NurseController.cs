using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class NurseController : Controller
    {
        public INurseRegistration NurseRegistration { get; }

        public NurseController(INurseRegistration nurseRegistration)
        {
            NurseRegistration = nurseRegistration;
        }
        public ActionResult NurseInfo()
        {
            return View(new Nurse());
        }
        [HttpPost]
        public ActionResult NurseInfo(Nurse nurse)
        {
            try
            {
                NurseRegistration.Register(nurse);
                return RedirectToAction("NurseInfo");
            }
            catch
            {
                return View();
            }
        }
    }
}