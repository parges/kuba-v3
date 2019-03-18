using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Bson;

namespace kubaapi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Testung> Testungen { get; set; }
        public DbSet<TestungChapter> TestungChapters { get; set; }
        public DbSet<TestungQuestion> TestungQuestions { get; set; }
        


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

            modelBuilder.Entity<TestungChapter>(r =>
            {
                r.HasData(new
                    {
                        Id = 1,
                        Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS",
                        TestungId = 1
                    },
                    new
                    {
                        Id = 2,
                        Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG",
                        TestungId = 1
                    },
                    new
                    {
                        Id = 3,
                        Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN",
                        TestungId = 1
                    }
                );
            });

            modelBuilder.Entity<TestungQuestion>(r =>
            {
                r.HasData(new
                    {
                        Id = 1,
                        Label = "Aufrichten aus Rückenlage in den Stand",
                        Type = "radio",
                        Value = "",
                        TestungChapterId = 1
                    },
                    new
                    {
                        Id = 2,
                        Label = "Aufrichten aus Bauchlage in den Stand",
                        Type = "radio",
                        Value = "",
                        TestungChapterId = 1
                    },
                    new
                    {
                        Id = 3,
                        Label = "Romberg Test (Augen geöffnet)",
                        Type = "radio",
                        Value = "",
                        TestungChapterId = 1
                    },
                    new
                    {
                        Id = 4,
                        Label = "Tandem Gang (rückwärts)",
                        Type = "radio",
                        Value = "",
                        TestungChapterId = 1
                    }, new { Id = 5, Label = "Tandem Gang (vorwärts)", Type = "radio", Value = "", TestungChapterId = 1 }
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

        private void addTestungen(ModelBuilder modelBuilder)
        {
            /*List<TestungBaseChapter> chapters = new List<TestungBaseChapter>();
            chapters.Add(new TestungBaseChapter
                {
                    Id = 1,
                    Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS"
                }
            );
            chapters.Add(new TestungBaseChapter
                {
                    Id = 2,
                    Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG"
                }
            );
            chapters.Add(new TestungBaseChapter
                {
                     Id = 3,
                    Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN"
                 }
            );*/
            /*modelBuilder.Entity<TestungBaseChapter>().HasData(chapters);*/
            /*modelBuilder.Entity<TestungBaseChapter>().HasData(new TestungBaseChapter
                {
                    Id = 1,
                    Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS"
                },
                new TestungBaseChapter
                {
                    Id = 2,
                    Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG"
                },
                new TestungBaseChapter
                {
                    Id = 3,
                    Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN"
                }
            );

            modelBuilder.Entity<TestungBaseData>().HasData(new TestungBaseData()
                {
                    Id = 1,
                    Name = "Aufrichten aus Rückenlage in den Stand",
                    
                },
                new TestungBaseData()
                {
                    Id = 2,
                    Name = "Aufrichten aus Bauchlage in den Stand",
        
                },
                new TestungBaseData()
                {
                    Id = 3,
                    Name = "Romberg Test (Augen geöffnet)",
                  
                },
                new TestungBaseData()
                {
                    Id = 4,
                    Name = "Tandem Gang (rückwärts)",
                   
                },
                new TestungBaseData()
                {
                    Id = 5,
                    Name = "Romberg Test (Augen geschlossen)",
                   
                },
                new TestungBaseData()
                {
                    Id = 6,
                    Name = "Mann Test (Augen geöffnet)",
                    
                },
                new TestungBaseData()
                {
                    Id = 7,
                    Name = "Mann Test (Augen geschlossen)",
                   
                }, new TestungBaseData()
                {
                    Id = 8,
                    Name = "Einbeinstand",
                    
                }, new TestungBaseData()
                {
                    Id = 9,
                    Name = "Marschieren und Umdrehen",
                   
                }, new TestungBaseData()
                {
                    Id = 10,
                    Name = "Zehenspitzengang (vorwärts)",
                    
                }, new TestungBaseData()
                {
                    Id = 11,
                    Name = "Zehenspitzengang (rückwärts)",
                    
                }, new TestungBaseData()
                {
                    Id = 12,
                    Name = "Tandem Gang (vorwärts)",
                    
                }, new TestungBaseData()
                {
                    Id = 13,
                    Name = "Kriechen auf dem Bauch",
                    
                });*/
        }
    }
}
