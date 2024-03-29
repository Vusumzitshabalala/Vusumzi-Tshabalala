﻿using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Ioc;
using HospitalManagementSystem.Logic;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using NUnit.Framework;
using Telerik.JustMock.EntityFramework;

namespace HospitalManagementSystem.Tests
{
    [TestFixture]
    public class PatientTests
    {
        [Test]
        public void GivenPatientWhenRegisteringThenPersistToDb()
        {


            HospitalManagementSystemContext HospitalManagementSystemContext = EntityFrameworkMock.Create<HospitalManagementSystemContext>();
            TypeFactory.RegisterInstance(HospitalManagementSystemContext);

            Patient patient = new Patient();

            patient.PersonId = 1;
            patient.Person.Id = 1;
            patient.Person.FirstName = "Vusi";
            patient.Person.Surname = "Khoza";
            patient.Person.IdNumber = "1234";

            IPatientRepository patientRepository = new PatientRepository();
            IPatientRegistration patientRegistration = new PatientRegistration(patientRepository);

            patientRegistration.Register(patient);

            IPatientRetriever patientRetriever = new PatientRetriever(patientRepository);
            patientRetriever.Retrieve(patient.Person.IdNumber);

            Assert.IsNotNull(patientRetriever.Patient);
            Assert.AreEqual(patient.Person.Id, patientRetriever.Patient.Person.Id);
            Assert.AreEqual(patient.Person.FirstName, patientRetriever.Patient.Person.FirstName);
            Assert.AreEqual(patient.Person.Surname, patientRetriever.Patient.Person.Surname);
        }
    }
}
