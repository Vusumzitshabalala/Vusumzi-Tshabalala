using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Person

    {
        public Person()
        {
            DateOfBirth = new DateTime(1970, 05, 10);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public String Name{ get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public string IdentityNumber { get; set; }

        public int NationalityId { get; set; }

        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

        [ForeignKey("RaceId")]
        public Race Race { get; set; }
        public int RaceId { get; set; }

        [ForeignKey("GenderId")]
        public  Gender Gender { get; set; }
        public int GenderId { get; set; }


        public string Address { get; set; }

        public int CellNumber { get; set; }

    }

}
