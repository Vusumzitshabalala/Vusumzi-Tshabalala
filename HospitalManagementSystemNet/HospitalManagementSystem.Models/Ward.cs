using Multiplex.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Ward: BaseModel
    {
        public string Number { get; set; }

        public int WardTypeId { get; set; }

        [ForeignKey("WardTypeId")]
        public WardType WardType { get; set; }
    }
}
