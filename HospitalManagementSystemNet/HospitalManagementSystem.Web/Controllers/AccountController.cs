using HospitalManagementSystem.Models.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View(new LoginCredentials());
        }
        // GET: Account
        [HttpPost]
        public ActionResult Login(LoginCredentials login)
        {
            return View();
        }

        // GET: Account
        public ActionResult LoggedIn()
        {
            return View();
        }
    }
}