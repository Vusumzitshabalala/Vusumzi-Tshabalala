using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class PorterController : BaseController
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
                var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
                var roles = new string[] { HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR };
                var registerHelper = new RegisterHelper(userId, porter.Person, roles);
                registerHelper.Register();

                if (!registerHelper.Response.Item1)
                {
                    porter.Person.Error = registerHelper.Response.Item2;
                    return View(porter);
                }

                //PorterRegistration.Register(new Porter() { PersonId = porter.Person.Id });
                int personId = porter.Person.Id;
                porter.PersonId = personId;
                porter.Person = null;
                PorterRegistration.Register(porter);

                return RedirectToAction("RegisterSuccess", "Account", new { statusMessage = registerHelper.Response.Item2 });
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
