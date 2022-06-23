using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium_poprawa.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Models
{
    public class KolokwiumDbContext : DbContext
    {
        public KolokwiumDbContext()
        {
        }
        public KolokwiumDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(e => 
            {
                e.HasKey(e => e.FileID);
                e.Property(e => e.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(e => e.FileName).HasMaxLength(100).IsRequired();
                e.Property(e => e.FileSize).IsRequired();

                e.HasOne(e => e.Team)
                    .WithMany(e => e.Files)
                    .HasForeignKey(e => e.TeamID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(e => e.MemberID);
                e.Property(e => e.MemberName).HasMaxLength(20).IsRequired();
                e.Property(e => e.MemberSurname).HasMaxLength(50).IsRequired();
                e.Property(e => e.MemberNickName).HasMaxLength(29);

                e.HasOne(e => e.Organization)
                    .WithMany(e => e.Members)
                    .HasForeignKey(e => e.OrganizationID)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(e => new {e.MemberID, e.TeamID});
                
                e.HasOne(e => e.Member)
                    .WithMany(e => e.Memberships)
                    .HasForeignKey(e => e.MemberID)
                    .OnDelete(DeleteBehavior.ClientCascade);

                e.HasOne(e => e.Team)
                    .WithMany(e => e.GetMemberships)
                    .HasForeignKey(e => e.TeamID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(e => e.TeamID);
                e.Property(e => e.TeamDescription).HasMaxLength(500);
                e.Property(e => e.TeamName).HasMaxLength(50).IsRequired();

                e.HasOne(e => e.Organization)
                    .WithMany(e => e.Teams)
                    .HasForeignKey(e => e.OrganizationID)
                    .OnDelete(DeleteBehavior.ClientCascade);
            });

            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(e => e.OrganizationID);
                e.Property(e => e.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();
            });

            var defaultOrganization = new List<Organization>
            {
                new Organization
                {
                    OrganizationID = 1,
                    OrganizationName = "PJATK",
                    OrganizationDomain = "PJATK"
                }
            };

            var defaultTeam = new List<Team>
            {
                new Team
                {
                    TeamID = 1,
                    TeamName = "APBD",
                    TeamDescription = "Cool przedmiot"
                },

                new Team
                {
                    TeamID = 2,
                    TeamName = "Wyklad",
                    TeamDescription = "Nie taki coll jak APBD"
                }
            };

            var defaultMember = new List<Member>
            {
                new Member
                {
                    MemberID = 1,
                    OrganizationID = 1,
                    MemberName = "Jan",
                    MemberSurname = "Kowalski",
                    MemberNickName = "Kowal"
                },
                new Member
                {
                    MemberID = 2,
                    OrganizationID = 1,
                    MemberName = "Monika",
                    MemberSurname = "Nowak",
                    MemberNickName = "Monoia"
                },
                new Member
                {
                    MemberID = 3,
                    OrganizationID = 1,
                    MemberName = "Mikołaj",
                    MemberSurname = "Gitara",
                    MemberNickName = "Cool gosciu"
                }
            };

            var defaultMembership = new List<Membership>
            {
                new Membership
                {
                    TeamID = 1,
                    MemberID = 1,
                    MembershipDate = new DateTime(2022, 7, 8)
                },
                new Membership
                {
                    TeamID = 1,
                    MemberID = 2,
                    MembershipDate = new DateTime(2022, 4, 5)
                }
            };

            modelBuilder.Entity<Member>().HasData(defaultMember);
            /*modelBuilder.Entity<Organization>().HasData(defaultOrganization);
            modelBuilder.Entity<Team>().HasData(defaultTeam);
            modelBuilder.Entity<Membership>().HasData(defaultMembership);*/
        }
    }
}