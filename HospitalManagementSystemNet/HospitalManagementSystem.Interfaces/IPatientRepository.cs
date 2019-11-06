using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientRepository
    {
        void SavePatient(Patient patient);
        Patient Retrieve(string identityNumber);
        List<Patient> GetAllPatients();
        void DeletePatient(int id);
    }
}
