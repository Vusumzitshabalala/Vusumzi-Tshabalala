using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace HospitalManagementSystem.Repository
{
    public class NurseRepository : INurseRepository
    {

        public void SaveNurse(Nurse nurse)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    if (nurse.Id > 0)
                    {
                        Nurse savedNurse = context.Nurse.FirstOrDefault(p => p.Id == nurse.Id);

                        if (savedNurse != null)
                        {
                            savedNurse = nurse;
                        }
                    }
                    else
                    {
                        context.Nurse.Add(nurse);
                    }
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
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Nurse.FirstOrDefault(p => p.Person.IdNumber == identityNumber);
            }
            return result;
        }

        public List<Nurse> GetAllNurses()
        {
            List<Nurse> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Nurse.Include(p => p.Person).Where(p => p.Person.Active).ToList();

                //Hack because inclusions are not working
                foreach (var nurse in result)
                {
                    nurse.Person = context.Person.FirstOrDefault(p => p.Id == nurse.PersonId);
                }
            }

            return result;
        }


        public void DeleteNurse(int id)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    Nurse nurse = context.Nurse.Include(p => p.Person).FirstOrDefault(p => p.Id == id);

                    if (nurse != null)
                    {
                        nurse.Person = context.Person.FirstOrDefault(p => p.Id == nurse.PersonId);

                        if (nurse.Person != null)
                        {
                            //Bad code: place holder
                            nurse.Person.Email = "a@a.com";
                            nurse.Person.UserName = "a@a.com";
                            nurse.Person.Active = false;
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
