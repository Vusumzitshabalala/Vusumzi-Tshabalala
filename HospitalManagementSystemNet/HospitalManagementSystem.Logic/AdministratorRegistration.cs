using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class AdministratorRegistration : IAdministratorRegistration
    {
        public AdministratorRegistration(IAdministratorRepository administratorRepository)
        {
            AdministratorRepository = administratorRepository;
        }

        public IAdministratorRepository AdministratorRepository { get; }

        public void Register(Administrator administrator)
        {
            AdministratorRepository.SaveAdministrator(administrator);
        }
    }



}
