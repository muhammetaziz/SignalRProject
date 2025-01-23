using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Phone { get; set; }= string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string FooterDescription { get; set; } = string.Empty;
        //public DateTime OpeningTime { get; set; } 
        //public DateTime ClosingTime { get; set; } 
    }
}
