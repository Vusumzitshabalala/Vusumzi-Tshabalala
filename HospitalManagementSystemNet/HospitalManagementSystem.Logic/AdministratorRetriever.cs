using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class AdministratorRetriever : IAdministratorRetriever
    {
        public AdministratorRetriever(IAdministratorRepository administratorRepository)
        {
            AdministratortRepository = administratorRepository;
        }
        public Administrator Administrator{ get; private set; }
        public IAdministratorRepository AdministratortRepository { get; }

        public void Retrieve(string identityNumber)
        {
            Administrator = AdministratortRepository.Retrieve(identityNumber);
        }
    }
}
