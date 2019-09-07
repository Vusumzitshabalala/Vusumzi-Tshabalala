using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        public Doctor Retrieve(string identityNumber)
        {
            Doctor result = null;


            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Doctor.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
            }

            return result;
        }

        public void SaveDoctor(Doctor doctor)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                {
                    context.Doctor.Add(doctor);
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
