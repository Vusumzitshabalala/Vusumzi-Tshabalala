using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AdministratorController : Controller
    {
        public IAdministratorRegistration AdministratorRegistration { get; }
        public IAdministratorsRetriever AdministratorsRetriever { get; }

        public AdministratorController(IAdministratorRegistration administratorRegistration, IAdministratorsRetriever administratorsRetriever)
        {
            AdministratorRegistration = administratorRegistration;
            AdministratorsRetriever = administratorsRetriever;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateAdministrator()
        {
            return View(new Administrator());
        }

        [HttpPost]
        public ActionResult CreateAdministrator(Administrator administrator)
        {
            try
            {
                AdministratorRegistration.Register(administrator);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewAdministrators()
        {
            return View(AdministratorsRetriever.GetAllAdministrators());
        }


    }
}
