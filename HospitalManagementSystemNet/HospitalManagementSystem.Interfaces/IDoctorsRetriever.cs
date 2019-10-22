using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Interfaces
{
    public interface IDoctorsRetriever
    {
        List<Doctor> GetAllDoctors();
    }
}
