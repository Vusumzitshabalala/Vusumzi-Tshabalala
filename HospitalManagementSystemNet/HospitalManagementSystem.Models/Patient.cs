using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Models
{
    public class Patient      
    {
        public Patient()
        {
            Person = new Person();
        }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
       

    }
}
