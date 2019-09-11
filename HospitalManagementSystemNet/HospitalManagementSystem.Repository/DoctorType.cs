using HospitalManagementSystem.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    class DoctorType
    {
        public object DoctorTypeId { get; internal set; }

        public class DoctorRepository : IDoctorTypeRepository
        {
            public DoctorType Retrieve(string identityNumber)
            {
                DoctorType result = null;


                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    result = context.DoctorType.FirstOrDefault(p => p.Person.IdentityNumber == identityNumber);
                }

                return result;
            }

            public void SaveDoctorType(DoctorType doctorType)
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
}
