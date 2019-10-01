using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPorterRepository
    {
        void SavePorter(Porter porter);

        Porter Retrieve(string IdentityNumber);
      
    }
}
