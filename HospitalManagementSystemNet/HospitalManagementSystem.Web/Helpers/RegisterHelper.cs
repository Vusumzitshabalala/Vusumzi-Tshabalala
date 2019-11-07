using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Multiplex.DomainServices.Security;
using System;

namespace HospitalManagementSystem.Web.Helpers
{
    public class RegisterHelper
    {
        public RegisterHelper(Guid userId, Person person, string[] roles)
        {
            UserId = userId;
            Person = person;
            Roles = roles;
        }

        private Guid UserId { get; set; }

        private Person Person { get; set; }

        public string[] Roles { get; }

        public Tuple<bool, string> Response { get; set; }

        public void Register()
        {
            Person.Error = string.Empty;
            Person.UserName = Person.Cellphone;

            var userManager = new UserManager();


            //((UserInfo)userInformation).Cellphone = userInformation.Cellphone;
            Response = userManager.Register<HospitalManagementSystemContext, Person>(Person, UserId, true, Roles);
        }
    }
}