using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientsRetriever
    {
        List<Patient> GetAllPatients();
        void DeletePatient(int id);
    }
}
