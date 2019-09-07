using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Interfaces
{
    public interface IDoctorRegistration
    {
     
        IDoctorRepository DoctorRepository { get; }

        void Register(Doctor doctor);
    
    }
}
