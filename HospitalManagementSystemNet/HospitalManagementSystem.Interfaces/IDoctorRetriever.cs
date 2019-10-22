using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IDoctorRetriever
    {
        void Retrieve(string IdentityNumber);

        Doctor Doctor { get; }
    }
}
