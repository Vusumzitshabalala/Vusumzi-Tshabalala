using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class DoctorRetriever : IDoctorRetriever

    {
        public DoctorRetriever(IDoctorRepository doctorRepository)
        {
            DoctorRepository = doctorRepository;
        }
        public Doctor Doctor { get; private set; }
        public IDoctorRepository DoctorRepository { get; }


        public void Retrieve(string identityNumber)
        {
        Doctor = DoctorRepository.Retrieve(identityNumber);
        }

   
    }
           
    
    
}
