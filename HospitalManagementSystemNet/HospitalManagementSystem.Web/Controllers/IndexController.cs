using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class IndexController : Controller
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
            return View(new Patient());
        }

        [HttpPost]
        public ActionResult CreatePatient(Patient patient)
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
