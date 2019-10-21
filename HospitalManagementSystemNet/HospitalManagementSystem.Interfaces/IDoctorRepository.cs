using System.Collections.Generic;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IDoctorRepository
    {
        void SaveDoctor(Doctor doctor);

        Doctor Retrieve(string IdentityNumber);
        List<Doctor> GetAllDoctors();
    }
}
