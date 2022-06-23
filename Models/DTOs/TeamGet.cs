using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium_poprawa.Models.DTOs
{
    public class TeamGet
    {
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public string NameOfOrganization { get; set; }

        public List<MemberGet>? Members { get; set; }

    }
}