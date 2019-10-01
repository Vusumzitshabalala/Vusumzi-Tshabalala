using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class NurseRetriever : INurseRetriever

    {
        private INurseRepository nurseRepository;

        public NurseRetriever(INurseRepository NurseRepository)
        {
            NurseRepository = nurseRepository;
        }
        public Nurse Nurse { get; private set; }
        public INurseRepository NurseRepository { get; }


        public void Retrieve(string identityNumber)
        {
            Nurse = NurseRepository.Retrieve(identityNumber);
        }


    }



}
