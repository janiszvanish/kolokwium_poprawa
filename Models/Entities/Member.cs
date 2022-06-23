using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models.Entities
{
    public class Member
    {
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }

        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual IEnumerable<Membership> Memberships { get; set; }
    }
}