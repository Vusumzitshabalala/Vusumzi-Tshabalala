using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace HospitalManagementSystem.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {

        public void SaveAdministrator(Administrator administrator)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    if (administrator.Id > 0)
                    {
                        Administrator savedAdministrator = context.Administrator.FirstOrDefault(p => p.Id == administrator.Id);

                        if (savedAdministrator != null)
                        {
                            savedAdministrator = administrator;
                        }
                    }
                    else
                    {
                        context.Administrator.Add(administrator);
                    }
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
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Administrator.FirstOrDefault(p => p.Person.IdNumber == identityNumber);
            }
            return result;
        }

        public List<Administrator> GetAllAdministrators()
        {
            List<Administrator> result = null;

            using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
            //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
            {
                result = context.Administrator.Include(p => p.Person).Where(p => p.Person.Active).ToList();

                //Hack because inclusions are not working
                foreach (var administrator in result)
                {
                    administrator.Person = context.Person.FirstOrDefault(p => p.Id == administrator.PersonId);
                }
            }

            return result;
        }

        public void DeleteAdministrator(int id)
        {
            try
            {
                using (HospitalManagementSystemContext context = TypeFactory.Resolve<HospitalManagementSystemContext>())
                //using (HospitalManagementSystemContext context = new HospitalManagementSystemContext())
                {
                    Administrator administrator = context.Administrator.Include(p => p.Person).FirstOrDefault(p => p.Id == id);

                    if (administrator != null)
                    {
                        administrator.Person = context.Person.FirstOrDefault(p => p.Id == administrator.PersonId);

                        if (administrator.Person != null)
                        {
                            //Bad code: place holder
                            administrator.Person.Email = "a@a.com";
                            administrator.Person.UserName = "a@a.com";
                            administrator.Person.Active = false;
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
