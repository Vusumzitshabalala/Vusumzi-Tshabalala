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
    public class AdministratorRepository : IAdministratorRepository
    {
        public void SaveAdministrator(Administrator administrator)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                {
                    context.Administrator.Add(administrator);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }
        public Administrator Retrieve(string identityNumber)
        {
            Administrator result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            {
                result = context.Administrator.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }
            return result;
        }

    }
}

