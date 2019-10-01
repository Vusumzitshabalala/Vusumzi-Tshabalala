using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IAdministratorRepository
    {
        void SaveAdministrator(Administrator administrator);

        Administrator Retrieve(string IdentityNumber);
    }
}
