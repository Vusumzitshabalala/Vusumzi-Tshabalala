using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

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
