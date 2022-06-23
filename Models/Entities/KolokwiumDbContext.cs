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
                e.Property(e => e.OrganizationName).HasMaxLength(1000).IsRequired();
                e.Property(e => e.OrganizationDomain).HasMaxLength(50).IsRequired();
            });
        }
    }
}