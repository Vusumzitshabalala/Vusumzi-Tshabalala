using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AdministratorController : Controller
    {
        public IAdministratorRegistration AdministratorRegistration { get; }
    

        public AdministratorController(IAdministratorRegistration administratorRegistration)
        {
            AdministratorRegistration = administratorRegistration;
        }
        public ActionResult AdministratorInfo()
        {
            return View(new Administrator());
        }
        [HttpPost]
        public ActionResult AdministratorInfo(Administrator administrator)
        {
            try
            {
                AdministratorRegistration.Register(administrator);
                return RedirectToAction("AdministratorInfo");
            }
            catch
            {
                return View();
            }
        }
    }
}