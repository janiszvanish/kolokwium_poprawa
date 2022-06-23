﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.Migrations
{
    [DbContext(typeof(KolokwiumDbContext))]
    [Migration("20220623124812_dodanie zawartosci do tabel3")]
    partial class dodaniezawartoscidotabel3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("TeamID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(29)
                        .HasColumnType("nvarchar(29)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            MemberName = "Jan",
                            MemberNickName = "Kowal",
                            MemberSurname = "Kowalski",
                            OrganizationID = 1
                        },
                        new
                        {
                            MemberID = 2,
                            MemberName = "Monika",
                            MemberNickName = "Monoia",
                            MemberSurname = "Nowak",
                            OrganizationID = 1
                        },
                        new
                        {
                            MemberID = 3,
                            MemberName = "Mikołaj",
                            MemberNickName = "Cool gosciu",
                            MemberSurname = "Gitara",
                            OrganizationID = 1
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberID", "TeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            TeamID = 1,
                            MembershipDate = new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            MemberID = 2,
                            TeamID = 1,
                            MembershipDate = new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationDomain = "PJATK",
                            OrganizationName = "PJATK"
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            OrganizationID = 0,
                            TeamDescription = "Cool przedmiot",
                            TeamName = "APBD"
                        },
                        new
                        {
                            TeamID = 2,
                            OrganizationID = 0,
                            TeamDescription = "Nie taki coll jak APBD",
                            TeamName = "Wyklad"
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.File", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Entities.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Member", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Entities.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Membership", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Entities.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("kolokwium_poprawa.Models.Entities.Team", "Team")
                        .WithMany("GetMemberships")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Team", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Entities.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Entities.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("GetMemberships");
                });
#pragma warning restore 612, 618
        }
    }
}
