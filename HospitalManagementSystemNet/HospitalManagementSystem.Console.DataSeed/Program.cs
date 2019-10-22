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
                new DoctorType()
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
            hospitalManagementSystemContext.Race.AddRange(new List<Race>() {
                new Race()
                {
                    Id = 1,
                    Name = "Black"
                },
                new Race()
                {
                    Id = 2,
                    Name = "White"
                },
                new Race()
                {
                    Id = 3,
                    Name = "Indian"
                },
                new Race()
                {
                    Id = 4,
                    Name = "Asian"
                },
                new Race()
                {
                    Id = 5,
                    Name = "hawaiian"
                },
                new Race()

                {
                    Id = 6,
                    Name = "Alaska Native"
                }


            });
            hospitalManagementSystemContext.Province.AddRange(new List<Province>() {
                new Province()
                {
                    Id = 1,
                    Name = "Western Cape"
                },
                new Province()
                {
                    Id = 2,
                    Name = "Eastern Cape"
                },
                new Province()
                {
                    Id = 3,
                    Name = "Northern Cape"
                },
                new Province()
                {
                    Id = 4,
                    Name = "North West"
                },
                new Province()
                {
                    Id = 5,
                    Name = "Free State"
                },
                new Province()

                {
                    Id = 6,
                    Name = "Kwazulu Natal"
                },
                new Province()
                {
                    Id = 7,
                    Name = "Gauten"
                },
                new Province()
                {
                    Id = 8,
                    Name = "Limpopo"
                },
                new Province()
                {
                    Id = 9,
                    Name = "Mpumalanga"
                }


            });


            hospitalManagementSystemContext.SaveChanges();

            System.Console.WriteLine("Hospital Management System Data Inserted");
            System.Console.ReadKey();
        }
    }
}
