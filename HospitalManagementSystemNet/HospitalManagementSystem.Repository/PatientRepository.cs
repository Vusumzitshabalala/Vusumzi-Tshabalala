using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Linq;

namespace HospitalManagementSystem.Repository
{
    public class PatientRepository : IPatientRepository
    {

        public void SavePatient(Patient patient)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    context.Patient.Add(patient);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
           
        }
        public Patient Retrieve(string identityNumber)
        {
            Patient result = null;


            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
               result = context.Patient.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }
            return result;
        }
    }
}
