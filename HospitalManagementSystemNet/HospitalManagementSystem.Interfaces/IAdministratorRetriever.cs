using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IAdministratorRetriever
    {
        void Retrieve(string IdentityNumber);

        Administrator Administrator { get; }
    }
}