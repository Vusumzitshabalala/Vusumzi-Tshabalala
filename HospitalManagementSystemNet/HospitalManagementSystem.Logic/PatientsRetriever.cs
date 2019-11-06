using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class PatientsRetriever : IPatientsRetriever
    {
        public PatientsRetriever(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public IPatientRepository PatientRepository { get; }

        public List<Patient> GetAllPatients()
        {
            return PatientRepository.GetAllPatients();
        }

        public void DeletePatient(int id)
        {
            PatientRepository.DeletePatient(id);
        }
    }
}
