using HospitalManagementSystem.Models;
using HospitalManagementSystem.Models.Web;
using HospitalManagementSystem.Repository;
using Multiplex.DomainServices.Security;
using HospitalManagementSystem.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalManagementSystem.Web.Controllers
{
    //[Authorize]
    public class AccountController : BaseController
    {
        #region Login

        //[HttpPost]
        //    public ActionResult Login(LoginCredentials login)
        //    {
        //        return RedirectToAction("LoggedIn", "Account");
        //    }

        //    // GET: Account
        //    public ActionResult LoggedIn()
        //    {
        //        return View();
        //    }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Request.IsAuthenticated)
            {
                return View("Unauthorised");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Person person, string returnUrl)
        {
            person.Error = string.Empty;
            var userManager = new UserManager();
            var login = userManager.Login<HospitalManagementSystemContext, Person>(person);

            if (login.Item1 && login.Item2 != null)
            {
                if (login.Item2.PasswordChanged)
                {
                    FormsAuthentication.SetAuthCookie(person.UserName, false);

                    //if (person.DateOfBirth.AddYears(13) > DateTime.Now && !User.IsInRole(HospitalManagementSystem.Models.Constants.CLIENT))
                    //{
                    //    var roleAssignment = new RoleAssignment();
                    //    roleAssignment.AssignUserRole(person.UserName, HospitalManagementSystem.Models.Constants.CLIENT);
                    //}

                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    //return RedirectToAction("Index", "Browse");
                    return RedirectToAction("Profile", "Account");
                }
                else
                {
                    return View("ChangeGeneratedPassword", person);
                }
            }
            person.Error = login.Item3;
            return View(person);
        }

        #endregion Login

        #region Reset Password

        [AllowAnonymous]
        public ActionResult ResetPassword(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Title = "Reset Password";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ResetPassword(Person person, string returnUrl)
        {
            person.Error = string.Empty;
            person.UserName = person.Cellphone;
            ((Person)person).Cellphone = person.Cellphone;

            var securityService = new PasswordManager();
            var resetPassword = securityService.ResetPassword<HospitalManagementSystemContext, Person>(person);

            if (resetPassword.Item1)
            {
                return RedirectToAction("ResetPasswordSuccess", new { statusMessage = resetPassword.Item2 });
            }

            person.Error = resetPassword.Item2;
            ViewBag.Title = "Reset Password";
            return View(person);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ResetPasswordModal(string cellphone)
        {
            var person = new Person();
            person.Cellphone = cellphone;
            person.Error = string.Empty;
            person.UserName = person.Cellphone;
            ((Person)person).Cellphone = person.Cellphone;

            var securityService = new PasswordManager();
            var resetPassword = securityService.ResetPassword<HospitalManagementSystemContext, Person>(person);

            return Json(resetPassword.Item2, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordSuccess(string statusMessage)
        {
            ViewBag.Title = "Reset Password Successful";
            return View((object)statusMessage);
        }

        #endregion Reset Password

        #region Profile

        public ActionResult Profile()
        {
            var securityService = new DomainService();
            var person = securityService.GetEntity<HospitalManagementSystemContext, Person>(User.Identity.Name, null);

            if (person == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Title = "My Profile";
            return View(person);
        }

        public ActionResult ProfileByUsername(string username)
        {
            var securityService = new DomainService();
            var person = securityService.GetEntity<HospitalManagementSystemContext, Person>(username, null);

            if (person == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Profile", person);
        }

        [HttpPost]
        public ActionResult Profile(Person person)
        {
            person.Error = string.Empty;
            var securityService = new DomainService();

            person = securityService.SaveEntity<HospitalManagementSystemContext, Person>(person, UserId, null);

            if (person == null)
            {
                return RedirectToAction("Index", "Home");
            }
            person.Error = Multiplex.Models.Security.Constants.PROFILE_UPDATED;
            return View(person);
        }

        #endregion Profile

        #region Change Password

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewBag.Title = "Change Password";
            return View(Person);
        }

        [AllowAnonymous]
        public ActionResult ChangeGeneratedPassword(Person person)
        {
            ViewBag.Title = "Change Password";
            return View(person);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ChangeGeneratedPassword(Person person, string returnUrl)
        {
            person.Error = string.Empty;

            var passwordManager = new PasswordManager();
            var changePassword = passwordManager.ChangePassword(person);

            if (changePassword.Item1)
            {
                var service = new DomainService();

                person = service.GetEntity<HospitalManagementSystemContext, Person>(person.UserName, null);
                person.PasswordChanged = true;
                service.SaveEntity<HospitalManagementSystemContext, Person>(person, UserId, null);

                FormsAuthentication.SetAuthCookie(person.UserName, false);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Profile", "Account");
            }

            person.Error = changePassword.Item2;
            return View(person);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(Person person)
        {
            person.Error = string.Empty;
            person.SetMembership(Membership.GetUser());

            var passwordManager = new PasswordManager();
            var changePassword = passwordManager.ChangePassword(person);

            if (changePassword.Item1)
            {
                return RedirectToAction("Profile", "Account");
            }

            person.Error = changePassword.Item2;
            return View(person);
        }

        #endregion Change Password

        #region Log Off

        [Authorize]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        #endregion Log Off

        #region Register

        [AllowAnonymous]
        public ActionResult Register(int clientId = 0)
        {
            var person = new Person();

            return View(person);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(Person person)
        {
            var userId = Request.IsAuthenticated ? UserId : Guid.Empty;
            //person.Error = string.Empty;
            //person.UserName = person.Cellphone;

            //var userManager = new UserManager();
            //string[] roles = null;

            //if (person.DateOfBirth.AddYears(13) < DateTime.Now)
            //{
            //    roles = new string[] { HospitalManagementSystem.Models.Constants.CLIENT };
            //}
            //else
            //{
            //    roles = new string[] { HospitalManagementSystem.Models.Constants.USER };
            //}

            ////((UserInfo)person).Cellphone = person.Cellphone;
            //var register = userManager.Register<HospitalManagementSystemContext, Person>(person, userId, true, roles);
            var registerHelper = new RegisterHelper(userId, person, null);
            registerHelper.Register();

            if (!registerHelper.Response.Item1)
            {
                person.Error = registerHelper.Response.Item2;
                return View(person);
            }

            return RedirectToAction("RegisterSuccess", new { statusMessage = registerHelper.Response.Item2 });
        }


        //[Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        [AllowAnonymous]
        public ActionResult RegisterSuccess(string statusMessage)
        {
            ViewBag.Title = "Successfully Registered";
            return View((object)statusMessage);
        }

        #endregion Register

        #region Lock / Unlock User

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        public ActionResult LockUnlockUser(string username, bool isLocked)
        {
            var securityService = new UserManager();
            securityService.LockUnclockUser<HospitalManagementSystemContext>(username, isLocked);

            return RedirectToAction("Users","Account");
        }

        #endregion Lock / Unlock User

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR + ", " + HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR)]
        public ActionResult Users()
        {
            var securityService = new DomainService();
            var usersInformation = securityService.GetEntities<HospitalManagementSystemContext, Person>(null, null, null);

            if (!User.IsInRole(HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR))
            {
                usersInformation = usersInformation.Where(ui => !Roles.IsUserInRole(ui.UserName, HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR)).ToList();
            }

            ViewBag.Title = "Users";

            return View(new Tuple<List<Person>, bool>(usersInformation, false));
        }

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        [HttpPost]
        public ActionResult Users(FormCollection formCollection)
        {
            var securityService = new DomainService();
            var usersInformation = securityService.GetEntities<HospitalManagementSystemContext, Person>(formCollection["usernameSearch"], formCollection["emailSearch"], null);

            return View(new Tuple<List<Person>, bool>(usersInformation, true));
        }

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR + ", " + HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR)]
        public ActionResult UserRoles(string username)
        {
            var userRoleRetrieval = new UserRoleRetrieval();
            var userInRoles = userRoleRetrieval.GetUserRoles(username);

            if (!User.IsInRole(HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR))
            {
                userInRoles.UserRoles = userInRoles.UserRoles.Where(ur => ur.RoleName != HospitalManagementSystem.Models.Constants.Roles.SUPERADMINISTRATOR).ToList();
            }

            ViewBag.Title = "User Roles";

            return View(userInRoles);
        }

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        [HttpPost]
        public ActionResult UserRoles(FormCollection formCollection)
        {
            var username = formCollection["Username"];
            var formUserInRoles = ConvertFormCollection();

            if (!string.IsNullOrWhiteSpace(username) && formUserInRoles != null)
            {
                var userRoleUpdate = new UserRoleUpdate();

                userRoleUpdate.UpdateUserRoles(username, formUserInRoles);
            }

            ViewBag.Title = "User Roles";

            return RedirectToAction("UserRoles", new { username = username });
        }

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        [HttpPost]
        public ActionResult GetRoles(FormCollection formCollection)
        {
            var roleName = formCollection["roleName"];
            var statusMessage = string.Format(Multiplex.Models.Security.Constants.ROLECREATION_FAILED, roleName);

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                Roles.CreateRole(roleName);
                statusMessage = string.Format(Multiplex.Models.Security.Constants.ROLECREATION_PASSED, roleName);
            }
            else
            {
                statusMessage = "Role required.";
            }

            return RedirectToAction("GetRoles", new { createRole = roleName, statusMessage = statusMessage });
        }

        [Authorize(Roles = HospitalManagementSystem.Models.Constants.Roles.ADMINISTRATOR)]
        public ActionResult DeleteRole(string rolename)
        {
            Roles.DeleteRole(rolename);

            return RedirectToAction("GetRoles");
        }
    }
    //public class AccountController : BaseController
    //{
    //    // GET: Account
    //    public ActionResult Login()
    //    {
    //        return View(new LoginCredentials());
    //    }
    //    // GET: Account
    //   
    //}
}