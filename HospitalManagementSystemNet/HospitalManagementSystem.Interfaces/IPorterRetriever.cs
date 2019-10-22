using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPorterRetriever
    {
        void Retrieve(string IdentityNumber);

        Porter Porter { get; }
    }
}
