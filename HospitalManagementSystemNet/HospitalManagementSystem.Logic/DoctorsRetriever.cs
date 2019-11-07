using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class DoctorsRetriever : IDoctorsRetriever
    {
        public DoctorsRetriever(IDoctorRepository doctorRepository)
        {
            DoctorRepository = doctorRepository;
        }

        public IDoctorRepository DoctorRepository { get; }

        public void DeleteDoctor(int id)
        {
            DoctorRepository.DeleteDoctor(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return DoctorRepository.GetAllDoctors();
        }
    }
}
