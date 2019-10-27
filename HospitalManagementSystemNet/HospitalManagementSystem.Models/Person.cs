using Multiplex.Models.Security;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Person: UserInfo

    {
        public Person()
        {
            DateOfBirth = new DateTime(1970, 05, 10);
        }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

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
