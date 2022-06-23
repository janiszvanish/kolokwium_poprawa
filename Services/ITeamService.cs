using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_poprawa.Models.DTOs;

namespace kolokwium_poprawa.Services
{
    public interface ITeamService
    {
        public Task<TeamGet> GetTeamById(int id);
        public Task<int> AddNewMemberToTheTeam(int teamID, int memberID);
    }
}