using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

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
