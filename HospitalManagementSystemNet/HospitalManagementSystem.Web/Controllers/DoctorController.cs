using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class DoctorController : Controller
    {
        public IDoctorRegistration DoctorRegistration { get; }
        public IDoctorsRetriever DoctorsRetriever { get; }

        public DoctorController(IDoctorRegistration doctorRegistration, IDoctorsRetriever doctorsRetriever)
        {
            DoctorRegistration = doctorRegistration;
            DoctorsRetriever = doctorsRetriever;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            return View(new Doctor());
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            try
            {
                DoctorRegistration.Register(doctor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewDoctors()
        {
            return View(DoctorsRetriever.GetAllDoctors());
        }


    }
}
