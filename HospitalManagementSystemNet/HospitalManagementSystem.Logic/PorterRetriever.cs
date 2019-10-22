using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Logic
{
    public class PorterRetriever : IPorterRetriever

    {
        public PorterRetriever(IPorterRepository porterRepository)
        {
            PorterRepository = porterRepository;
        }
        public Porter Porter { get; private set; }
        public IPorterRepository PorterRepository { get; }

        public void Retrieve(string identityNumber)
        {
            Porter = PorterRepository.Retrieve(identityNumber);
        }

    }

}
