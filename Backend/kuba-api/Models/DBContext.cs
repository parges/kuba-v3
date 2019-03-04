using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace kubaapi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Reviews)
                .WithOne()
                .HasForeignKey(s => s.PatientId);

            /*
            modelBuilder.Entity<Review>()
                .HasOne<Patient>(s => s.Patient)
                .WithMany(g => g.Reviews)
                .HasForeignKey(s => s.PatientId);
*/

            addPatients(modelBuilder);
            /*addDocuments(modelBuilder);*/

        }

        private static void addPatients(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(p =>
            {
                p.HasData(new
                {
                    Id = 1,
                    Firstname = "Kleiner",
                    Lastname = "Hase",
                    Birthday = new DateTime(1988, 8, 10),
                    Tele = "0177123456"
                });
                p.HasData(new
                {
                    Id = 2,
                    Firstname = "Stefan",
                    Lastname = "Parge",
                    Birthday = new DateTime(1988, 8, 11),
                    Tele = "0177123457"
                });
            });

            modelBuilder.Entity<Review>(r =>
            {
                r.HasData(new
                    {
                        Id = 1,
                        Date = new DateTime(2019, 03, 04),
                        Name = "Befundgespräch",
                        Payed = true,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 1
                    },
                    new
                    {
                        Id = 2,
                        Date = new DateTime(2019, 03, 03),
                        Name = "1. Review",
                        Payed = true,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 1
                    },
                    new
                    {
                        Id = 3,
                        Date = new DateTime(2019, 03, 02),
                        Name = "2. Review",
                        Payed = false,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 1
                    }
                );

                r.HasData(new
                    {
                        Id = 4,
                        Date = new DateTime(2019, 03, 04),
                        Name = "Befundgespräch",
                        Payed = true,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 2
                    },
                    new
                    {
                        Id = 5,
                        Date = new DateTime(2019, 03, 03),
                        Name = "1. Review",
                        Payed = false,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 2
                    },
                    new
                    {
                        Id = 6,
                        Date = new DateTime(2019, 03, 02),
                        Name = "2. Review",
                        Payed = false,
                        Exercises = "Liegestütze und dann Kaffee trinken",
                        Reasons = "Das war dringend notwendig",
                        PatientId = 2
                    }
                );
            });

            
        }

        private void addDocuments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasData(new Document()
                {
                    Id = 1,
                    Name = "Anamnese",
                }, 
                new Document()
                {
                    Id = 2,
                    Name ="Testung"
                },
                new Document()
                {
                    Id = 3,
                    Name = "Report"
                });
        }
    }
}
