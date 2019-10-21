using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class NursesRetriever : INursesRetriever
    {
        public NursesRetriever(INurseRepository nurseRepository)
        {
            NurseRepository = nurseRepository;
        }

        public INurseRepository NurseRepository { get; }

        public List<Nurse> GetAllNurses()
        {
            return NurseRepository.GetAllNurses();
        }
    }
}
