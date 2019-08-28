using System;
using System.ComponentModel;
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

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("ID Number")]
        public string IdentityNumber { get; set; }

        [DisplayName("Nationality")]
        public int NationalityId { get; set; }

        [ForeignKey("NationalityId")]
        public Nationality Nationality { get; set; }

        [ForeignKey("RaceId")]
        public Race Race { get; set; }

        [DisplayName("Race")]
        public int RaceId { get; set; }

        [ForeignKey("GenderId")]
        public  Gender Gender { get; set; }

        [DisplayName("Gender")]
        public int GenderId { get; set; }


        public string Address { get; set; }

        public int CellNumber { get; set; }

    }

}
