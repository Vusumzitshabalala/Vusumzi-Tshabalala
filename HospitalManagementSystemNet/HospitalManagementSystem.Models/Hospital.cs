﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models
{
    public class Hospital
    {
        [Key]
        //public int Id { get; set; }

        public string Name { get; set; }

        public int ProvinceId { get; set; }

        public Province Province { get; set; }

        public string Address { get; set; }
    }
}
