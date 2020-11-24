﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week_12b.Data;

namespace Week_12b.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Week_12b.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AchterNaam")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<double>("HoogsteCijfer")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Inschrijving")
                        .HasColumnType("TEXT");

                    b.Property<int>("LeerJaar")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Opleiding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VoorNaam")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Week_12b.Models.Student", b =>
                {
                    b.HasOne("Week_12b.Models.Student", null)
                        .WithMany("Vrienden")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Week_12b.Models.Student", b =>
                {
                    b.Navigation("Vrienden");
                });
#pragma warning restore 612, 618
        }
    }
}