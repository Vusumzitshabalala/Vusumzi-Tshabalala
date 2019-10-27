using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;

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

            hospitalManagementSystemContext.WardType.AddRange(new List<WardType>() {
                new WardType()
                {
                    Id = 1,
                    Name = "Maternity"                    
                },
                new WardType()
                {
                    Id = 2,
                    Name = "Pediatrics"
                },
                new WardType()
                {
                    Id = 3,
                    Name = "Psychiatric"
                },
                new WardType()
                {
                    Id = 4,
                    Name = "Intensive Care Unit"
                }
            });

            hospitalManagementSystemContext.Ward.AddRange(new List<Ward>() {
                new Ward()
                {
                    Id = 1,
                    Number = "WD001",
                    WardTypeId = 1,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Ward()
                {
                    Id = 2,
                    Number = "WD002",
                    WardTypeId = 4,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Ward()
                {
                    Id = 3,
                    Number = "WD003",
                    WardTypeId = 3,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Ward()
                {
                    Id = 4,
                    Number = "WD004",
                    WardTypeId = 2,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                }
            });

            hospitalManagementSystemContext.Bed.AddRange(new List<Bed>()
            {
                new Bed()
                {
                    Number = "BD001",
                    WardId = 1,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD002",
                    WardId = 1,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD003",
                    WardId = 2,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD004",
                    WardId = 2,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD005",
                    WardId = 3,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD006",
                    WardId = 3,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD007",
                    WardId = 4,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
                },
                new Bed()
                {
                    Number = "BD008",
                    WardId = 4,
                    CreatedById = Guid.NewGuid(),
                    DateCreated = DateTime.Now
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
                    Name = "Immunologist"
                },
                new DoctorType()
                {
                    Id = 3,
                    Name = "Medicine Specialist"
                },
                new DoctorType()
                {
                    Id = 4,
                    Name = "Psychiatrist"
                },
                new DoctorType()
                {
                    Id = 5,
                    Name = "Cardiologist"
                },
                new DoctorType()

                {
                    Id = 6,
                    Name = "Cardiovascular Surgeon"
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
