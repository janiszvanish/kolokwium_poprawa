using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models.Entities
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Team Team { get; set; }
    }
}