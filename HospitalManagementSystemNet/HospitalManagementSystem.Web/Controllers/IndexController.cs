using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class IndexController : BaseController
    {
        public IPatientRegistration PatientRegistration { get; }
        public IPatientsRetriever PatientsRetriever { get; }

        public IndexController(IPatientRegistration patientRegistration, IPatientsRetriever patientsRetriever)
        {
            PatientRegistration = patientRegistration;
            PatientsRetriever = patientsRetriever;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult CreatePatient()
        {
            ViewBag.Title = "Patient Management";
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
        {
            try
            {
                var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
                var registerHelper = new RegisterHelper(userId, patient.Person);
                registerHelper.Register();

                if (!registerHelper.Response.Item1)
                {
                    patient.Person.Error = registerHelper.Response.Item2;
                    return View(patient);
                }

                patient.PersonId = patient.Person.Id;
                PatientRegistration.Register(patient);

                return RedirectToAction("RegisterSuccess", "Account", new { statusMessage = registerHelper.Response.Item2 });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewPatients()
        {
            return View(PatientsRetriever.GetAllPatients());
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Title = "COntact Us";
            return View();
        }

    }
}
