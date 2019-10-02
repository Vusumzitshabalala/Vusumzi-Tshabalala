using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class PorterController : Controller
    {
        public IPorterRegistration PorterRegistration { get; }

        public PorterController(IPorterRegistration porterRegistration)
        {
            PorterRegistration = porterRegistration;
        }
        public ActionResult porterInfo()
        {
            return View(new Porter());
        }
        [HttpPost]
        public ActionResult PorterInfo(Porter porter)
        {
            try
            {
                PorterRegistration.Register(porter);
                return RedirectToAction("PorterInfo");
            }
            catch
            {
                return View();
            }
        }
    }
}