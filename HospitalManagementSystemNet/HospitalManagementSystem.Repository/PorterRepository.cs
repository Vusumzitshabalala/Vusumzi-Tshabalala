using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace HospitalManagementSystem.Repository
{
    public class PoterRepository : IPorterRepository
    {

        public void SavePorter(Porter porter)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                {
                    if (porter.Id > 0)
                    {
                        Porter savedPorter = context.Porter.FirstOrDefault(p => p.Id == porter.Id);

                        if(savedPorter != null)
                        {
                            savedPorter = porter;
                        }
                    }
                    else
                    {
                        context.Porter.Add(porter);
                    }
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
                result = context.Porter.FirstOrDefault(p => p.Person.IdNumber == identityNumber);
            }
            return result;
        }

        public List<Porter> GetAllPorters()
        {
            List<Porter> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Porter.Include(p => p.Person).Where(p => p.Person.Active).ToList();

                //Hack because inclusions are not working
                foreach (var porter in result)
                {
                    porter.Person = context.Person.FirstOrDefault(p => p.Id == porter.PersonId);
                }
            }

            return result;
        }


        public void DeletePorter(int id)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    Porter porter = context.Porter.Include(p => p.Person).FirstOrDefault(p => p.Id == id);

                    if (porter != null)
                    {
                        porter.Person = context.Person.FirstOrDefault(p => p.Id == porter.PersonId);

                        if (porter.Person != null)
                        {
                            //Bad code: place holder
                            porter.Person.Email = "a@a.com";
                            porter.Person.UserName = "a@a.com";
                            porter.Person.Active = false;
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
