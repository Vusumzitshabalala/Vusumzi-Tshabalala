using HospitalManagementSystem.Repository;
using System;

namespace HospitalManagementSystem.Data.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialising Hospital Management System Data");

            HospitalManagementSystemContext hospitalManagementSystemContext = new HospitalManagementSystemContext();        
        }
    }
}
