using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
