using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class DoctorRegistration : IDoctorRegistration
    {
        public DoctorRegistration(IDoctorRepository doctorRepository)
        {
            DoctorRepository = doctorRepository;
        }

        public IDoctorRepository DoctorRepository { get; }

        public void Register(Doctor doctor)
        {
            DoctorRepository.SaveDoctor(doctor);
        }
    }


     
}
