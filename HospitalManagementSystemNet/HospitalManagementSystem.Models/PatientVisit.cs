using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HospitalManagementSystem.Models
{
    public class PatientVisit
    {
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public string Diagonosis { get; set; }
        public string Prescription { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }
}
