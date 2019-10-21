using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Logic
{
    public class PortersRetriever : IPortersRetriever
    {
        public PortersRetriever(IPorterRepository porterRepository)
        {
            PorterRepository = porterRepository;
        }

        public IPorterRepository PorterRepository { get; }

        public List<Porter> GetAllPorters()
        {
            return PorterRepository.GetAllPorters();
        }
    }
}
