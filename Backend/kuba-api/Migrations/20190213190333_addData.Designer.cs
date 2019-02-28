﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kubaapi.Models;

namespace kubaapi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20190213190333_addData")]
    partial class addData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kubaapi.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Tele");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new { Id = 1, Birthday = new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kleiner", Lastname = "Hase", Tele = "0177123456" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
