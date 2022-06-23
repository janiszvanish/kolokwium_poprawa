using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models.Entities
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; } 
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public virtual IEnumerable<File> Files { get; set; }
        public virtual IEnumerable<Membership> GetMemberships { get; set; }
        public virtual Organization Organization { get; set; }

    } 
}