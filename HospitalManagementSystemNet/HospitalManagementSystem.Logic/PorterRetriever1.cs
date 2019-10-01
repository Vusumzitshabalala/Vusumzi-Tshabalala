using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
