using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

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
                result = context.Patient.FirstOrDefault(p => p.Person.IdNumber == identityNumber);
            }
            return result;
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Patient.Include(p => p.Person).Where(p => p.Person.Active).ToList();

                //Hack because inclusions are not working
                foreach (var patient in result)
                {
                    patient.Person = context.Person.FirstOrDefault(p => p.Id == patient.PersonId);
                }
            }

            return result;
        }

        public void DeletePatient(int id)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    Patient patient = context.Patient.Include(p => p.Person).FirstOrDefault(p => p.Id == id);

                    if (patient != null)
                    {
                        patient.Person = context.Person.FirstOrDefault(p => p.Id == patient.PersonId);

                        if (patient.Person != null)
                        {
                            //Bad code: place holder
                            patient.Person.Email = "a@a.com";
                            patient.Person.UserName = "a@a.com";
                            patient.Person.Active = false;
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
