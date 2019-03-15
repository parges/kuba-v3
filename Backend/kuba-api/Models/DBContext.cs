using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;

namespace kubaapi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Testung> Testungen { get; set; }
        public DbSet<TestungDetails> TestungDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            addTestungBaseData(modelBuilder);

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

            modelBuilder.Entity<Testung>(r =>
            {
                r.HasData(new
                    {
                        Id = 1,
                        Date = DateTime.Now,
                        Name = "Erste Testung",
                        PatientId = 1
                    }
                );
            });

            modelBuilder.Entity<TestungDetails>(r =>
            {
                r.HasData(new
                    {
                        Id = 1,
                        DataId = 1,
                        Value = "",
                        TestungId = 1
                        
                    },
                    new
                    {
                        Id = 2,
                        DataId = 2,
                        Value = "",
                        TestungId = 1
                        
                    },
                    new
                    {
                        Id = 3,
                        DataId = 3,
                        Value = "",
                        TestungId = 1

                    },
                    new
                    {
                        Id = 4,
                        DataId = 4,
                        Value = "",
                        TestungId = 1

                    },
                    new
                    {
                        Id = 5,
                        DataId = 5,
                        Value = "",
                        TestungId = 1

                    },
                    new
                    {
                        Id = 6,
                        DataId = 6,
                        Value = "",
                        TestungId = 1

                    },
                    new
                    {
                        Id = 7,
                        DataId = 7,
                        Value = "",
                        TestungId = 1

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

        private void addTestungBaseData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestungBaseChapter>().HasData(new TestungBaseChapter()
                {
                    Id = 1,
                    Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS"
                },
                new TestungBaseChapter()
                {
                    Id = 2,
                    Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG"
                },
                new TestungBaseChapter()
                {
                    Id = 3,
                    Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN"
                });
            modelBuilder.Entity<TestungBaseData>().HasData(new TestungBaseData()
                {
                    Id = 1,
                    Name = "Aufrichten aus Rückenlage in den Stand",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 2,
                    Name = "Aufrichten aus Bauchlage in den Stand",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 3,
                    Name = "Romberg Test (Augen geöffnet)",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 4,
                    Name = "Tandem Gang (rückwärts)",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 5,
                    Name = "Romberg Test (Augen geschlossen)",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 6,
                    Name = "Mann Test (Augen geöffnet)",
                    TestungChapterId = 1
                },
                new TestungBaseData()
                {
                    Id = 7,
                    Name = "Mann Test (Augen geschlossen)",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 8,
                    Name = "Einbeinstand",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 9,
                    Name = "Marschieren und Umdrehen",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 10,
                    Name = "Zehenspitzengang (vorwärts)",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 11,
                    Name = "Zehenspitzengang (rückwärts)",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 12,
                    Name = "Tandem Gang (vorwärts)",
                    TestungChapterId = 1
                }, new TestungBaseData()
                {
                    Id = 13,
                    Name = "Kriechen auf dem Bauch",
                    TestungChapterId = 2
                });
        }
    }
}
