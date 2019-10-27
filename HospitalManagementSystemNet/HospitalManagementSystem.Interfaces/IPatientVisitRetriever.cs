using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientVistrRetriever
    {
        void Retrieve(string IdentityNumber);

        PatientVisit PatientVisit { get; }
    }
}