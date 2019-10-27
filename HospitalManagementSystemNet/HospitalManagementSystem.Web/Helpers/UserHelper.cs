using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using System;

namespace HospitalManagementSystem.Web.Helpers
{
    public class UserHelper
    {
        public static string GetFullName(Guid userId)
        {
            var result = string.Empty;
            var securityService = new Multiplex.DomainServices.Security.DomainService();
            var user = securityService.GetEntity<HospitalManagementSystemContext, Person>(userId, null);

            if (user != null)
            {
                result = string.Format("{0} {1}",user.FirstName, user.Surname);
            }

            return result;
        }

        public static string GetFullName(string userName)
        {
            var result = string.Empty;
            var securityService = new Multiplex.DomainServices.Security.DomainService();
            var user = securityService.GetEntity<HospitalManagementSystemContext, Person>(userName, null);

            if (user != null)
            {
                result = string.Format("{0} {1}",user.FirstName, user.Surname);
            }

            return result;
        }
    }
}
