using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface INurseRetriever
    {
        void Retrieve(string IdentityNumber);

        Nurse Nurse { get; }
    }
}