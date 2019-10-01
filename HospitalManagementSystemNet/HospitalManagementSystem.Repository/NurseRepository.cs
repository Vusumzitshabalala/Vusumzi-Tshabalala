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
    public class NurseRepository : INurseRepository
    {
        public void SaveNurse(Nurse nurse)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                {
                    context.Nurse.Add(nurse);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }


        }
        public Nurse Retrieve(string identityNumber)
        {
            Nurse result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            {
                result = context.Nurse.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }
            return result;
        }

    }
}

