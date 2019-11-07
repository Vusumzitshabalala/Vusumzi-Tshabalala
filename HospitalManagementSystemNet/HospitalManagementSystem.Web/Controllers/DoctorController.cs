using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class DoctorController : BaseController
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
                var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
                var roles = new string[] { HospitalManagementSystem.Models.Constants.Roles.DOCTOR };
                var registerHelper = new RegisterHelper(userId, doctor.Person, roles);
                registerHelper.Register();

                if (!registerHelper.Response.Item1)
                {
                    doctor.Person.Error = registerHelper.Response.Item2;
                    return View(doctor);
                }

                //DoctorRegistration.Register(new Doctor() { PersonId = doctor.Person.Id, PracticeNumber = doctor.PracticeNumber });
                int personId = doctor.Person.Id;
                doctor.PersonId = personId;
                doctor.Person = null;
                DoctorRegistration.Register(doctor);

                return RedirectToAction("RegisterSuccess", "Account", new { statusMessage = registerHelper.Response.Item2 });
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

        [HttpGet]
        public ActionResult DeleteDoctor(int id)
        {
            DoctorsRetriever.DeleteDoctor(id);

            return RedirectToAction("ViewDoctors", "Index");
        }


    }
}
