using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface INurseRepository
    {
        void SaveNurse(Nurse nurse);

        Nurse Retrieve(string IdentityNumber);
    }
}
