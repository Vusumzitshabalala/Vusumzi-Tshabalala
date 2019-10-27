using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Multiplex.DomainServices.Security;
using System;

namespace HospitalManagementSystem.Web.Helpers
{
    public class RegisterHelper
    {
        public RegisterHelper(Guid userId, Person person)
        {
            UserId = userId;
            Person = person;
        }

        private Guid UserId { get; set; }

        private Person Person { get; set; }

        public Tuple<bool, string> Response { get; set; }

        public void Register()
        {
            Person.Error = string.Empty;
            Person.UserName = Person.Cellphone;

            var userManager = new UserManager();
            string[] roles = null;

            roles = new string[] { HospitalManagementSystem.Models.Constants.Roles.PATIENT };

            //((UserInfo)userInformation).Cellphone = userInformation.Cellphone;
            Response = userManager.Register<HospitalManagementSystemContext, Person>(Person, UserId, true, roles);
        }
    }
}