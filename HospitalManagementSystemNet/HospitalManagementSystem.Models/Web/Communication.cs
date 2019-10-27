using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Models.Web
{
    public class Communication
    {
        public Communication()
        {

        }

        public CommunicationType CommunicationType { get; set; }
        public int CommunicationTypeId { get; set; }

        public string Name { get; set; }

        public string Description{ get; set; }
    }
}
