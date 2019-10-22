using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Interfaces
{
    public interface IAdministratorsRetriever
    {
        List<Administrator> GetAllAdministrators();
    }
}
