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
    [Migration("20190310125538_baseDataAdded2")]
    partial class baseDataAdded2
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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime?>("AnamneseDate");

                    b.Property<bool?>("AnamnesePayed");

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime?>("DiagnostikDate");

                    b.Property<bool?>("DiagnostikPayed");

                    b.Property<DateTime?>("ElternDate");

                    b.Property<bool?>("ElternPayed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("ProblemHierarchy");

                    b.Property<string>("Tele");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new { Id = 1, Birthday = new DateTime(1988, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Kleiner", Lastname = "Hase", Tele = "0177123456" },
                        new { Id = 2, Birthday = new DateTime(1988, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), Firstname = "Stefan", Lastname = "Parge", Tele = "0177123457" }
                    );
                });

            modelBuilder.Entity("kubaapi.Models.Review", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Exercises");

                    b.Property<string>("Name");

                    b.Property<int?>("PatientId");

                    b.Property<bool>("Payed");

                    b.Property<string>("Reasons");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new { Id = 1, Date = new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "Befundgespräch", PatientId = 1, Payed = true, Reasons = "Das war dringend notwendig" },
                        new { Id = 2, Date = new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "1. Review", PatientId = 1, Payed = true, Reasons = "Das war dringend notwendig" },
                        new { Id = 3, Date = new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "2. Review", PatientId = 1, Payed = false, Reasons = "Das war dringend notwendig" },
                        new { Id = 4, Date = new DateTime(2019, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "Befundgespräch", PatientId = 2, Payed = true, Reasons = "Das war dringend notwendig" },
                        new { Id = 5, Date = new DateTime(2019, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "1. Review", PatientId = 2, Payed = false, Reasons = "Das war dringend notwendig" },
                        new { Id = 6, Date = new DateTime(2019, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), Exercises = "Liegestütze und dann Kaffee trinken", Name = "2. Review", PatientId = 2, Payed = false, Reasons = "Das war dringend notwendig" }
                    );
                });

            modelBuilder.Entity("kubaapi.Models.Testung", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<int?>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique()
                        .HasFilter("[PatientId] IS NOT NULL");

                    b.ToTable("Testungen");

                    b.HasData(
                        new { Id = 1, Date = new DateTime(2019, 3, 10, 13, 55, 37, 912, DateTimeKind.Local), Name = "Erste Testung", PatientId = 1 }
                    );
                });

            modelBuilder.Entity("kubaapi.Models.TestungBaseChapter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TestungBaseChapter");

                    b.HasData(
                        new { Id = 1, Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS" },
                        new { Id = 2, Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG" },
                        new { Id = 3, Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN" }
                    );
                });

            modelBuilder.Entity("kubaapi.Models.TestungBaseData", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("TestungChapterId");

                    b.HasKey("Id");

                    b.ToTable("TestungBaseData");

                    b.HasData(
                        new { Id = 1, Name = "Aufrichten aus Rückenlage in den Stand", TestungChapterId = 1 },
                        new { Id = 2, Name = "Aufrichten aus Bauchlage in den Stand", TestungChapterId = 1 },
                        new { Id = 3, Name = "Romberg Test (Augen geöffnet)", TestungChapterId = 1 },
                        new { Id = 4, Name = "Tandem Gang (rückwärts)", TestungChapterId = 1 },
                        new { Id = 5, Name = "Romberg Test (Augen geschlossen)", TestungChapterId = 1 },
                        new { Id = 6, Name = "Mann Test (Augen geöffnet)", TestungChapterId = 1 },
                        new { Id = 7, Name = "Mann Test (Augen geschlossen)", TestungChapterId = 1 },
                        new { Id = 8, Name = "Einbeinstand", TestungChapterId = 1 },
                        new { Id = 9, Name = "Marschieren und Umdrehen", TestungChapterId = 1 },
                        new { Id = 10, Name = "Zehenspitzengang (vorwärts)", TestungChapterId = 1 },
                        new { Id = 11, Name = "Zehenspitzengang (rückwärts)", TestungChapterId = 1 },
                        new { Id = 12, Name = "Tandem Gang (vorwärts)", TestungChapterId = 1 },
                        new { Id = 13, Name = "Kriechen auf dem Bauch", TestungChapterId = 2 }
                    );
                });

            modelBuilder.Entity("kubaapi.Models.TestungDetails", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DataId");

                    b.Property<int?>("TestungId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.HasIndex("TestungId");

                    b.ToTable("TestungDetails");
                });

            modelBuilder.Entity("kubaapi.Models.Review", b =>
                {
                    b.HasOne("kubaapi.Models.Patient")
                        .WithMany("Reviews")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("kubaapi.Models.Testung", b =>
                {
                    b.HasOne("kubaapi.Models.Patient")
                        .WithOne("Testung")
                        .HasForeignKey("kubaapi.Models.Testung", "PatientId");
                });

            modelBuilder.Entity("kubaapi.Models.TestungDetails", b =>
                {
                    b.HasOne("kubaapi.Models.TestungBaseData", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.HasOne("kubaapi.Models.Testung")
                        .WithMany("Questions")
                        .HasForeignKey("TestungId");
                });
#pragma warning restore 612, 618
        }
    }
}
