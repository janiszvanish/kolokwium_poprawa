using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models.DTOs
{
    public class MemberGet
    {
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }

        public DateTime MembershipDate { get; set; }
    }
}