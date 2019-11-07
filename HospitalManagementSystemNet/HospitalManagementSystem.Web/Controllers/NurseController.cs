using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class NurseController : BaseController
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
                var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
                var roles = new string[] { HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR };
                var registerHelper = new RegisterHelper(userId, nurse.Person, roles);
                registerHelper.Register();

                if (!registerHelper.Response.Item1)
                {
                    nurse.Person.Error = registerHelper.Response.Item2;
                    return View(nurse);
                }

                //NurseRegistration.Register(new Nurse() { PersonId = nurse.Person.Id });
                int personId = nurse.Person.Id;
                nurse.PersonId = personId;
                nurse.Person = null;
                NurseRegistration.Register(nurse);

                return RedirectToAction("RegisterSuccess", "Account", new { statusMessage = registerHelper.Response.Item2 });
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
