using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class PorterController : Controller
    {
        public IPorterRegistration PorterRegistration { get; }
        public IPortersRetriever PortersRetriever { get; }

        public PorterController(IPorterRegistration porterRegistration, IPortersRetriever portersRetriever)
        {
            PorterRegistration = porterRegistration;
            PortersRetriever = portersRetriever;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreatePorter()
        {
            return View(new Porter());
        }

        [HttpPost]
        public ActionResult CreatePorter(Porter porter)
        {
            try
            {
                PorterRegistration.Register(porter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewPorters()
        {
            return View(PortersRetriever.GetAllPorters());
        }


    }
}
