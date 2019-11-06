using HospitalManagementSystem.Models;
using System;
using System.Data.Entity;
using System.Configuration;


namespace HospitalManagementSystem.Repository
{
    public class HospitalManagementSystemContext: DbContext
    {
        public HospitalManagementSystemContext()
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
        }

        public HospitalManagementSystemContext(bool initialise = false)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = true;
            if (initialise == true)
            {
                this.Database.CreateIfNotExists();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Person>().HasKey(p => p.Id);
            //modelBuilder.Entity<Person>().HasKey(p => p.GenderId);
            //modelBuilder.Entity<Person>().HasKey(p => p.RaceId);
            //modelBuilder.Entity<Person>().HasKey(p => p.NationalityId);
            //modelBuilder.Entity<Person>().HasKey(p => p.DoctorTypeId);
            //modelBuilder.Entity<Person>().HasKey(p => p.ProvinceId);
            //modelBuilder.Entity<Doctor>().HasOptional(p => p.Person);
            //modelBuilder.Entity<Nurse>().HasOptional(p => p.Person);
            modelBuilder.Entity<Patient>().HasRequired(p => p.Person);//.WithMany();
            //modelBuilder.Entity<Administrator>().HasOptional(p => p.Person);
            //modelBuilder.Entity<Porter>().HasOptional(p => p.Person);
            //modelBuilder.Entity<Hospital>().HasKey(p => p.ProvinceId);
            modelBuilder.Entity<DoctorAppointment>().HasRequired(da => da.Patient).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<DoctorAppointment>().HasRequired(da => da.Doctor).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientVisit>().HasRequired(da => da.Patient);
            modelBuilder.Entity<Patient>().HasMany(da => da.PatientVisits);
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

        public DbSet<Porter> Porter { get;  set; }

        public DbSet<Administrator> Administrator { get;  set; }

        public DbSet<WardType> WardType { get; set; }

        public DbSet<Ward> Ward { get; set; }

        public DbSet<Bed> Bed { get; set; }

        public DbSet<BedAllocation> BedAllocation { get; set; }

        public DbSet<DoctorAppointment> DoctorAppointment { get; set; }
    }
}