using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientRetriever
    {
        void Retrieve(string identityNumber);

        Patient Patient { get; }
    }
}
