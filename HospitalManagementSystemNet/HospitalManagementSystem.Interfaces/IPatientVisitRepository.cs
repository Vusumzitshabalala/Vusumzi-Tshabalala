using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientVisitRepository
    {
        void SavePatientVisit(PatientVisit patientVisit);
        PatientVisit Retrieve(string identityNumber);
        List<PatientVisit> GetAllPatientVisits();
    }
}
