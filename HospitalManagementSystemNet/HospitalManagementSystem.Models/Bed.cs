using Multiplex.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Models
{
    public class Bed: BaseModel
    {
        public string Number { get; set; }

        public int WardId { get; set; }

        [ForeignKey("WardId")]
        public Ward Ward { get; set; }
    }
}
