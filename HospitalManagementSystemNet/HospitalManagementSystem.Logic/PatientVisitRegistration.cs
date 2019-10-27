using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class PatientVisitRegistration : IPatientVisitRegistration
    {
        public PatientVisitRegistration(IPatientVisitRepository patientVisitRepository)
        {
            PatientVisitRepository = patientVisitRepository;
        }

        public IPatientVisitRepository PatientVisitRepository { get; }

        public void Register(PatientVisit patientVisit)
        {
            PatientVisitRepository.SavePatientVisit(patientVisit);
        }
    }
}
