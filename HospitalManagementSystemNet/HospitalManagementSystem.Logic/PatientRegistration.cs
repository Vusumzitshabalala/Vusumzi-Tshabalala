﻿using HospitalManagementSystem.Interfaces;
using HospitalManagementSystem.Models;
using System;

namespace HospitalManagementSystem.Logic
{
    public class PatientRegistration : IPatientRegistration
    {
        public PatientRegistration(IPatientRepository patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public IPatientRepository PatientRepository { get; }

        public void Register(Patient patient)
        {
            PatientRepository.SavePatient(patient);
        }
    }
}