using HospitalManagementSystem.Models;
using System;
using System.Data.Entity;
using System.Configuration;


namespace HospitalManagementSystem.Repository
{
    public class HospitalManagementSystemContext: DbContext
    {
        internal object doctor;

        public HospitalManagementSystemContext(bool initialise = false)
        {
            if (initialise == true)
            {
                this.Database.CreateIfNotExists();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            //modelBuilder.Entity<Person>().HasKey(p => p.GenderId);
            //modelBuilder.Entity<Person>().HasKey(p => p.RaceId);
            //modelBuilder.Entity<Person>().HasKey(p => p.NationalityId);
            //modelBuilder.Entity<Person>().HasKey(p => p.DoctorTypeId);
            modelBuilder.Entity<Doctor>().HasKey(p => p.PersonId);
            modelBuilder.Entity<Nurse>().HasKey(p => p.PersonId);
            modelBuilder.Entity<Patient>().HasKey(p => p.PersonId);
            modelBuilder.Entity<Hospital>().HasKey(p => p.ProvinceId);
            modelBuilder.Entity<DoctorType>().HasKey(p => p.DoctorTypeId);
        }

        public DbSet<Person> Person { get; set; }

        public DbSet<Nurse> Nurse { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Nationality> Nationality { get; set; }

        public DbSet<Race> Race { get; set; }

        public DbSet<Gender> Gender { get; set; }

        public DbSet<Province> Province { get; set; }

        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<DoctorType> DoctorType { get; set; }
       
    }
}