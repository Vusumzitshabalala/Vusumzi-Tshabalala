using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models.Web
{
    public class LoginCredentials
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
