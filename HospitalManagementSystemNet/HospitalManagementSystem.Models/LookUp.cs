using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HospitalManagementSystem.Models
{
    public class LookUp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
