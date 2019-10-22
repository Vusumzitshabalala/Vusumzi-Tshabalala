using HospitalManagementSystem.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem.Interfaces
{
    public interface INursesRetriever
    {
        List<Nurse> GetAllNurses();
    }
}
