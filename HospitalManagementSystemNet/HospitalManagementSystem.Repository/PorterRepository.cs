using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HospitalManagementSystem.Repository
{
    public class PorterRepository : IPorterRepository
    {
        public void SavePorter(Porter porter)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
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
            {
                result = context.Porter.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }
            return result;
        }

    }
}

