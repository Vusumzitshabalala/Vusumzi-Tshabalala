﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Department

    {
        public Department()
        {
            Person = new Person();
        }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public string PracticeNumber { get; set; }
    }
}
