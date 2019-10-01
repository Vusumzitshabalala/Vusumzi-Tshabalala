using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class NurseRegistration : INurseRegistration
    {
        public NurseRegistration(INurseRepository nurseRepository)
        {
            NurseRepository = nurseRepository;
        }

        public INurseRepository NurseRepository { get; }

        public void Register(Nurse nurse)
        {
            NurseRepository.SaveNurse(nurse);
        }
    }



}
