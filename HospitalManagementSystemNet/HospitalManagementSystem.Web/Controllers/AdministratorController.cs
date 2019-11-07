using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AdministratorController : BaseController
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
                var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
                var roles = new string[] { HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR };
                var registerHelper = new RegisterHelper(userId, administrator.Person, roles);
                registerHelper.Register();

                if (!registerHelper.Response.Item1)
                {
                    administrator.Person.Error = registerHelper.Response.Item2;
                    return View(administrator);
                }

                //AdministratorRegistration.Register(new Administrator() { PersonId = administrator.Person.Id });
                int personId = administrator.Person.Id;
                administrator.PersonId = personId;
                administrator.Person = null;
                AdministratorRegistration.Register(administrator);

                return RedirectToAction("RegisterSuccess", "Account", new { statusMessage = registerHelper.Response.Item2 });
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
