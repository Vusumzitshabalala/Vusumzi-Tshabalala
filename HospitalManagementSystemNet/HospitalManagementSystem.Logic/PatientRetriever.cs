using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class PatientRetriever : IPatientRetriever
    {
        public PatientRetriever(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }
        public Patient Patient { get; private set; }
        public IPatientRepository PatientRepository { get; }

        public void Retrieve(string identityNumber)
        {
           Patient = PatientRepository.Retrieve(identityNumber);
        }
    }
}
