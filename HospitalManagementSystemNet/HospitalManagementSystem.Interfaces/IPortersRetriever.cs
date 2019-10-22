using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPortersRetriever
    {
        List<Porter> GetAllPorters();
    }
}
