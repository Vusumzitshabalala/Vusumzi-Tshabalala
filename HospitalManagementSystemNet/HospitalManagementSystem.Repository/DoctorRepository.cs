using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace HospitalManagementSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        public void SaveDoctor(Doctor doctor)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                {
                    if (doctor.Id > 0)
                    {
                        Doctor savedDoctor = context.Doctor.FirstOrDefault(p => p.Id == doctor.Id);

                        if (savedDoctor != null)
                        {
                            savedDoctor = doctor;
                        }
                    }
                    else
                    {
                        context.Doctor.Add(doctor);
                    }
                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }
        public Doctor Retrieve(string identityNumber)
        {
            Doctor result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            {
                result = context.Doctor.FirstOrDefault(p => p.Person.IdNumber == identityNumber);
            }
            return result;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            {
                result = context.Doctor.ToList();
            }

            return result;
        }

        public void DeleteDoctor(int id)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    Doctor doctor = context.Doctor.Include(p => p.Person).FirstOrDefault(p => p.Id == id);

                    if (doctor != null)
                    {
                        doctor.Person = context.Person.FirstOrDefault(p => p.Id == doctor.PersonId);

                        if (doctor.Person != null)
                        {
                            //Bad code: place holder
                            doctor.Person.Email = "a@a.com";
                            doctor.Person.UserName = "a@a.com";
                            doctor.Person.Active = false;
                        }
                    }

                    context.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                //throw ex;
            }
        }
    }
}
