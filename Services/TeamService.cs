using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_poprawa.Models;
using kolokwium_poprawa.Models.DTOs;
using kolokwium_poprawa.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Services
{
    public class TeamService : ITeamService
    {
        private readonly KolokwiumDbContext _context;
        public TeamService(KolokwiumDbContext context){
            _context = context;
        }

        public async Task<TeamGet> GetTeamById(int id)
        {
            var t = await _context.Teams.Where(e => e.TeamID == id).FirstOrDefaultAsync();
            if(t is null)
                return null;
            
            var mship = await _context.Memberships.Where(e => e.TeamID == id).OrderBy(e => e.MembershipDate).ToListAsync();
            
            List<MemberGet> members = new List<MemberGet>();
            if(!(mship is null))
            {
                foreach(Membership ms in mship)
                {
                    var m = await _context.Members.Where(e => e.MemberID == ms.MemberID).FirstOrDefaultAsync();
                    
                    if(!(m is null)){
                        members.Add(new MemberGet{
                            MemberName = m.MemberName,
                            MemberSurname = m.MemberSurname,
                            MembershipDate = await _context.Memberships
                                .Where(e => e.MemberID == m.MemberID)
                                .Select(e => e.MembershipDate).FirstOrDefaultAsync()
                        });
                    }
                }
            }
            var organization = await _context.Organizations.Where(e => e.OrganizationID == t.OrganizationID).FirstOrDefaultAsync();
            return new TeamGet
            {
                TeamName = t.TeamName,
                TeamDescription = t.TeamDescription,
                NameOfOrganization = organization.OrganizationName,
                Members = members
            };
        }

        public async Task<int> AddNewMemberToTheTeam(int teamID, int memberID)
        {
            var t = await _context.Teams.Where(e => e.TeamID == teamID).FirstOrDefaultAsync();
            var m = await _context.Members.Where(e => e.MemberID == memberID).FirstOrDefaultAsync();

            if(t is null)
                return 1;
            if(m is null)
                return 2;
            
            if(t.OrganizationID != m.OrganizationID)
                return 3;

            Membership membership = new Membership
            {
                MemberID = m.MemberID,
                TeamID = t.TeamID,
                MembershipDate = DateTime.Now
            };
            await _context.AddAsync(membership);
            await _context.SaveChangesAsync();
            return 0;
        }
    }
}