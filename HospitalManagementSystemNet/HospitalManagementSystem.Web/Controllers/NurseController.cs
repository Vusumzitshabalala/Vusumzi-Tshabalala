using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class NurseController : Controller
    {
        public INurseRegistration NurseRegistration { get; }
        public INursesRetriever NursesRetriever { get; }

        public NurseController(INurseRegistration nurseRegistration, INursesRetriever nursesRetriever)
        {
            NurseRegistration = nurseRegistration;
            NursesRetriever = nursesRetriever;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateNurse()
        {
            return View(new Nurse());
        }

        [HttpPost]
        public ActionResult CreateNurse(Nurse nurse)
        {
            try
            {
                NurseRegistration.Register(nurse);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewNurses()
        {
            return View(NursesRetriever.GetAllNurses());
        }


    }
}
