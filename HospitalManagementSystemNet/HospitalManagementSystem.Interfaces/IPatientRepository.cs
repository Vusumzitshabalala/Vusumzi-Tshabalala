﻿using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interfaces
{
    public interface IPatientRepository
    {
        void SavePatient(Patient patient);
        Patient Retrieve(string identityNumber);
    }
}