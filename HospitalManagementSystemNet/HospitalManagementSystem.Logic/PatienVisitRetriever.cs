using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class PatientVisitRetriever : IPatientVisitRetriever
    {
        public PatientVisitRetriever(IPatientVisitRepository patientVisitRepository)
        {
           PatientVisitRepository = patientVisitRepository;
        }
        public PatientVisit PatientVisit { get; private set; }
        public IPatientVisitRepository PatientVisitRepository { get; }

        public void Retrieve(string identityNumber)
        {
            PatientVisit = PatientVisitRepository.Retrieve(identityNumber);
        }
    }
}
