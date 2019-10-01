using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Console.DataSeed
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Initialising Hospital Management System Data");

            HospitalManagementSystemContext hospitalManagementSystemContext = new HospitalManagementSystemContext();

            hospitalManagementSystemContext.Gender.AddRange(new List<Gender>() {
                new Gender()
                {
                    Id = 1,
                    Name = "Male"
                },
                new Gender()
                {
                    Id = 2,
                    Name = "Female"
                }
            });

            hospitalManagementSystemContext.Nationality.AddRange(new List<Nationality>() {
                new Nationality()
                {
                    Id = 1,
                    Name = "South Africa"
                },
                new Nationality()
                {
                    Id = 2,
                    Name = "Lesotho"
                },
                new Nationality()
                {
                    Id = 3,
                    Name = "Zimbabwe"
                },
                new Nationality()
                {
                    Id = 4,
                    Name = "Angola"
                }
            });

            hospitalManagementSystemContext.DoctorType.AddRange(new List<DoctorType>() {
                new DoctorType
                {
                    Id = 1,
                    Name = "Anesthesiologist"
                },
                new DoctorType()
                {
                    Id = 2,
                    Name = "immunologist"
                },
                new DoctorType()
                {
                    Id = 3,
                    Name = "medicine specialist"
                },
                new DoctorType()
                {
                    Id = 4,
                    Name = "psychiatrist"
                },
                new DoctorType()
                {
                    Id = 5,
                    Name = "Cardiologist"
                },
                new DoctorType()

                {
                    Id = 6,
                    Name = "Cardiovascular surgeon"
                }
                
               
            });
            

            hospitalManagementSystemContext.SaveChanges();

            System.Console.WriteLine("Hospital Management System Data Inserted");
            System.Console.ReadKey();
        }
    }
}
