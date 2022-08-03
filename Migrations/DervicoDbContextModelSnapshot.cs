﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingDervico.Models;

#nullable disable

namespace OnboardingDervico.Migrations
{
    [DbContext(typeof(DervicoDbContext))]
    partial class DervicoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnboardingDervico.Models.role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"), 1L, 1);

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("rolePriority")
                        .HasColumnType("int");

                    b.HasKey("roleId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("OnboardingDervico.Models.useronboard", b =>
                {
                    b.Property<string>("empId")
                        .HasColumnType("varchar(7)");

                    b.Property<string>("businessUnit")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("costCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("derivcoManager")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("emailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("jobProfile")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("position")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.Property<string>("subTeam")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("team")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.HasKey("empId");

                    b.ToTable("useronboard");
                });

            modelBuilder.Entity("OnboardingDervico.Models.UserProfile", b =>
                {
                    b.Property<int>("profileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("profileId"), 1L, 1);

                    b.Property<string>("RecentActivity")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("staffId")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("date");

                    b.HasKey("profileId");

                    b.HasIndex("staffId");

                    b.ToTable("userProfile");
                });

            modelBuilder.Entity("OnboardingDervico.Models.users", b =>
                {
                    b.Property<string>("staffId")
                        .HasColumnType("varchar(7)");

                    b.Property<string>("authType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("emailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("joiningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<int>("lockcount")
                        .HasColumnType("int");

                    b.Property<string>("mobileNo")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("odcName")
                        .IsRequired()
                        .HasColumnType("varchar(45)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userId"), 1L, 1);

                    b.HasKey("staffId");

                    b.HasIndex("roleId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("OnboardingDervico.Models.UserProfile", b =>
                {
                    b.HasOne("OnboardingDervico.Models.users", "Users")
                        .WithMany()
                        .HasForeignKey("staffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("OnboardingDervico.Models.users", b =>
                {
                    b.HasOne("OnboardingDervico.Models.role", "role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });
#pragma warning restore 612, 618
        }
    }
}
