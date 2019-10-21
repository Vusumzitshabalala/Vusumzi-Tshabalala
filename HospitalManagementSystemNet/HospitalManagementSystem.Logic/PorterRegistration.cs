using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class PorterRegistration : IPorterRegistration
    {
        public PorterRegistration(IPorterRepository porterRepository)
        {
            PorterRepository = porterRepository;
        }

        public IPorterRepository PorterRepository { get; }

        public void Register(Porter porter)
        {
            PorterRepository.SavePorter(porter);
        }
    }



}
