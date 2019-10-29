using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientVisitRetriever
    {
        void Retrieve(string IdentityNumber);

        PatientVisit PatientVisit { get; }
    }
}