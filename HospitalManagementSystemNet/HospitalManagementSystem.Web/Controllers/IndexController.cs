using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class IndexController : Controller
    {
        public IPatientRegistration PatientRegistration { get; }

        public IndexController(IPatientRegistration patientRegistration)
        {
            PatientRegistration = patientRegistration;
        }

        public ActionResult Index()
        {
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult Index(Patient patient)
        {
            try
            {
                PatientRegistration.Register(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
