using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class AdministratorsRetriever : IAdministratorsRetriever
    {
        public AdministratorsRetriever(IAdministratorRepository administratorRepository)
        {
            AdministratorRepository = administratorRepository;
        }

        public IAdministratorRepository AdministratorRepository { get; }

        public List<Administrator> GetAllAdministrators()
        {
            return AdministratorRepository.GetAllAdministrators();
        }
    }
}
