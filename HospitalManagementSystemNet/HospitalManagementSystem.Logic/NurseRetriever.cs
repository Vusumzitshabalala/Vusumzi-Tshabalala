using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class NurseRetriever : INurseRetriever
    {
        public NurseRetriever(INurseRepository nurseRepository)
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
