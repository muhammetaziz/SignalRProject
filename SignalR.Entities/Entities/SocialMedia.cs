using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string Title { get; set; }=string.Empty;
        public string URL { get; set; }=string.Empty;
        public string Icon { get; set; }=string.Empty;
    }
}
