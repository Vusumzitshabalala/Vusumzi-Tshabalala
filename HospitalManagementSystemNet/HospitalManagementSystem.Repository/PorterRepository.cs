using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem.Repository
{
    public class PoterRepository : IPorterRepository
    {

        public void SavePorter(Porter porter)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    context.Porter.Add(porter);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        public Porter Retrieve(string identityNumber)
        {
            Porter result = null;


            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Porter.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }
            return result;
        }

        public List<Porter> GetAllPorters()
        {
            List<Porter> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Porter.ToList();
            }

            return result;
        }
    }
}
