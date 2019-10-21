using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IAdministratorRepository
    {
        void SaveAdministrator(Administrator administrator);
        Administrator Retrieve(string identityNumber);
        List<Administrator> GetAllAdministrators();
    }
}
