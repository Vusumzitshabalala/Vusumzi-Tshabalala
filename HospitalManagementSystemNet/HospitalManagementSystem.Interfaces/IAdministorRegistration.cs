using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Interfaces
{
    public interface IAdministratorRegistration
    {

        IDoctorRepository AdministratorRepository { get; }

        void Register(Administrator administrator);

    }
}