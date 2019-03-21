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
                r.HasData(
                    new { Id = 1, Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS", TestungId = 1},
                    new { Id = 2, Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG", TestungId = 1 },
                    new { Id = 3, Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN", TestungId = 1 },
                    new { Id = 4, Name = "IV. TESTS ZUR DYSDIADOCHOKINESE", TestungId = 1 },
                    new { Id = 5, Name = "V. LINKS-RECHTS-DISKRIMINIERUNGSPROBLEME", TestungId = 1 },
                    new { Id = 6, Name = "VI. ORIENTIERUNGSPROBLEME", TestungId = 1 },
                    new { Id = 7, Name = "VII. RÄUMLICHE WAHRNEHMUNGSPROBLEME", TestungId = 1 },
                    new { Id = 8, Name = "VIII. TESTS ZU ABERRANTEN REFLEXEN", TestungId = 1 },
                    new { Id = 9, Name = "IX. TESTS ZUR SEITIGKEITSÜBERPRÜFUNG", TestungId = 1 },
                    new { Id = 10, Name = "X. ÜBERPRÜFUNG DER AUGENMUSKELMOTORIK", TestungId = 1 },
                    new { Id = 11, Name = "XI. VISUELLE WAHRNEHMUNGSÜBERPRÜFUNG", TestungId = 1 },
                    new { Id = 12, Name = "ZUSÄTZLICHE BEOBACHTUNGEN UND NOTIZEN", TestungId = 1 },
                    new { Id = 13, Name = "ERGEBNISZUSAMMENFASSUNG", TestungId = 1 }
                );
            });

            modelBuilder.Entity<TestungQuestion>(r =>
            {
                r.HasData(
                    new { Id = 1, Label = "Aufrichten aus Rückenlage in den Stand", Type = "radio", Value = "", TestungChapterId = 1  },
                    new { Id = 2, Label = "Aufrichten aus Bauchlage in den Stand", Type = "radio",  Value = "", TestungChapterId = 1 },
                    new { Id = 3, Label = "Romberg Test (Augen geöffnet)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 4, Label = "Romberg Test (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 5, Label = "Mann Test (Augen geöffnet)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 6, Label = "Mann Test (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 7, Label = "Einbeinstand", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 8, Label = "Marschieren und Umdrehen", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 9, Label = "Zehenspitzengang (vorwärts) 0 1", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 10, Label = "Zehenspitzengang (rückwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 11, Label = "Tandem Gang (vorwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 12, Label = "Tandem Gang (rückwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 13, Label = "Fog Walk (vorwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 14, Label = "Fog Walk (rückwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 15, Label = "Slalom Gang (vorwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 16, Label = "Slalom Gang (rückwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 17, Label = "Fersengang (nur vorwärts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 18, Label = "Hüpfen auf einem Bein (links oder rechts)", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 19, Label = "Hopserlauf", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 20, Label = "Windmühle", Type = "radio", Value = "", TestungChapterId = 1 },
                    new { Id = 21, Label = "Kriechen auf dem Bauch", Type = "radio2", Value = "", TestungChapterId = 2 },
                    new { Id = 22, Label = "Krabbeln auf Händen und Knien", Type = "radio3", Value = "", TestungChapterId = 2 },
                    new { Id = 23, Label = "Ferse auf Schienbein (linke Ferse auf rechtes Schienbein)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 24, Label = "Ferse auf Schienbein (rechte Ferse auf linkes Schienbein)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 25, Label = "Zeigefinger-Annäherung (Augen offen)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 26, Label = "Zeigefinger-Annäherung (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 27, Label = "Finger an die Nase (Augen offen)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 28, Label = "Finger an die Nase (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = 3 },
                    new { Id = 29, Label = "Finger (linke Hand)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 30, Label = "Finger (rechte Hand)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 31, Label = "Hand (links)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 32, Label = "Hand (rechts)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 33, Label = "Fuß (links)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 34, Label = "Fuß (rechts)", Type = "radio", Value = "", TestungChapterId = 4 },
                    new { Id = 35, Label = "Links-Rechts-Diskriminierungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = 5 },
                    new { Id = 36, Label = "Orientierungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = 6 },
                    new { Id = 37, Label = "Räumliche Wahrnehmungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = 7 },
                    new { Id = 38, Label = "Standard Test - linker Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 39, Label = "Standard Test - linkes Bein", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 40, Label = "Standard Test - rechter Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 41, Label = "Standard Test - rechtes Bein", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 42, Label = "Ayres Test Nr. 1 - linker Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 43, Label = "Ayres Test Nr. 1 - rechter Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 44, Label = "Ayres Test Nr. 2 - linker Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 45, Label = "Ayres Test Nr. 2 - rechter Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 46, Label = "Schilder Test - linker Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 47, Label = "Schilder Test - rechter Arm", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 48, Label = "TTNR - von rechts nach links", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 49, Label = "TTNR - von links nach rechts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 50, Label = "STNR - Füße oder Rumpf", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 51, Label = "STNR - Arme", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 52, Label = "STNR - Krabbeltest", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 53, Label = "Spinaler Galant-Reflex - linke Seite", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 54, Label = "Spinaler Galant-Reflex - rechte Seite", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 55, Label = "TLR - Standard Test", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 56, Label = "TLR - Aufrechttest - Beugung", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 57, Label = "TLR - Aufrechttest – Streckung", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 58, Label = "Moro Reflex / FPR - Standard Test", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 59, Label = "Moro Reflex / FPR - Aufrecht: TT", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 60, Label = "Moro Reflex / FPR - Aufrecht: ZT", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 61, Label = "Moro Reflex / FPR - Aufrecht: FF", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 62, Label = "Augenkopfstellreaktionen - nach links", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 63, Label = "Augenkopfstellreaktionen - nach rechts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 64, Label = "Augenkopfstellreaktionen - vorwärts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 65, Label = "Augenkopfstellreaktionen - rückwärts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 66, Label = "Labyrinthkopfstellreaktionen - nach links", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 67, Label = "Labyrinthkopfstellreaktionen - nach rechts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 68, Label = "Labyrinthkopfstellreaktionen - rückwärts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 69, Label = "Labyrinthkopfstellreaktionen - vorwärts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 70, Label = "Amphibien Reaktion - linke Seite (Rückenlage)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 71, Label = "Amphibien Reaktion - rechte Seite (Rückenlage)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 72, Label = "Amphibien Reaktion - linke Seite (Bauchlage)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 73, Label = "Amphibien Reaktion - rechte Seite (Bauchlage)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 74, Label = "Segmentäre Rollreaktion- von den Schultern (links)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 75, Label = "Segmentäre Rollreaktion- von den Schultern (rechts)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 76, Label = "Segmentäre Rollreaktion- von den Hüften (links)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 77, Label = "Segmentäre Rollreaktion- von den Hüften (rechts)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 78, Label = "Babinski Reflex - linker Fuß", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 79, Label = "Babinski Reflex - rechter Fuß", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 80, Label = "Abdominal Reflex (optional)", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 81, Label = "Such-Reflex - links", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 82, Label = "Such-Reflex - rechts", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 83, Label = "Saug-Reflex", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 84, Label = "Erwachsener Saug-Reflex", Type = "radio4", Value = "", TestungChapterId = 8 },
                    new { Id = 85, Label = "Palmar-Reflex - linke Hand", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 86, Label = "Palmar-Reflex - rechte Hand", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 87, Label = "Plantar-Reflex - linker Fuß", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 88, Label = "Plantar-Reflex - rechter Fuß", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 89, Label = "Landau-Reaktion", Type = "radio", Value = "", TestungChapterId = 8 },
                    new { Id = 90, Label = "Fußdominanz - Ball schießen", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 91, Label = "Fußdominanz - Aufstampfen mit einem Fuß", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 92, Label = "Fußdominanz - Auf einen Stuhl steigen", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 93, Label = "Fußdominanz - Auf einem Bein hüpfen", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 94, Label = "Handdominanz - Einen Ball fangen", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 95, Label = "Handdominanz - Klatschen in eine Hand", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 96, Label = "Handdominanz - Schreibhand", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 97, Label = "Handdominanz - Teleskop", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 98, Label = "Augendominanz (Entfernung) - Teleskop", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 99, Label = "Augendominanz (Entfernung) - Ring", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 100, Label = "Augendominanz (Nähe) - Lochkarte", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 101, Label = "Augendominanz (Nähe) - Ring", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 102, Label = "Ohrdominanz - Muschel", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 103, Label = "Ohrdominanz - Lauschen", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 104, Label = "Ohrdominanz - Rufen (Hinweis auf Hemisphärendominanz)", Type = "radioLeftRight", Value = "", TestungChapterId = 9 },
                    new { Id = 105, Label = "Fixierungsschwierigkeiten", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 106, Label = "Beeinträchtigte Folgebewegungen (tracking- horizontal)", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 107, Label = "Beeinträchtigte Folgebewegungen (tracking-vertikal)", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 108, Label = "Verfolgen der Hand mit den Augen (eye-hand-tracking)", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 109, Label = "Augenzittern (Nystagmus)", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 110, Label = "Latente Konvergenz - links", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 111, Label = "Latente Konvergenz - rechts", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 112, Label = "Latente Divergenz - links", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 113, Label = "Latente Divergenz - rechts", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 114, Label = "Konvergenzschwierigkeiten - linkes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 115, Label = "Konvergenzschwierigkeiten - rechtes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 116, Label = "Schwierigkeit, die Augen unabhängig voneinander zu schließen - linkes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 117, Label = "Schwierigkeit, die Augen unabhängig voneinander zu schließen - rechtes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 118, Label = "Beeinträchtigung synchroner Augenbewegungen - linkes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 119, Label = "Beeinträchtigung synchroner Augenbewegungen - rechtes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 120, Label = "Erweiterte periphere Sicht - linkes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 121, Label = "Erweiterte periphere Sicht - rechtes Auge", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 122, Label = "Akkommodationsfähigkeit", Type = "radio", Value = "", TestungChapterId = 10 },
                    new { Id = 123, Label = "Pupillenreaktion auf Licht (optional) - linkes Auge", Type = "input", Value = "", TestungChapterId = 10 },
                    new { Id = 124, Label = "Pupillenreaktion auf Licht (optional) - rechtes Auge", Type = "input", Value = "", TestungChapterId = 10 },
                    new { Id = 125, Label = "Pupillenreaktion auf Licht (optional) - linkes Auge", Type = "input", Value = "", TestungChapterId = 10 },
                    new { Id = 126, Label = "Pupillenreaktion auf Licht (optional) - rechtes Auge", Type = "input", Value = "", TestungChapterId = 10 },
                    new { Id = 127, Label = "Visuelle Unterscheidungsprobleme - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 128, Label = "Visuelle Unterscheidungsprobleme - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 129, Label = "Visuelle Unterscheidungsprobleme - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 130, Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 131, Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 132, Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 133, Label = "Räumliche Probleme - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 134, Label = "Räumliche Probleme - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 135, Label = "Räumliche Probleme - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 136, Label = "Hinweis auf ‘Stimulusgebundenheit’", Type = "radio", Value = "", TestungChapterId = 11 },
                    new { Id = 137, Label = "Abschreiben eines kurzen Textes", Type = "input", Value = "", TestungChapterId = 11 },
                    new { Id = 138, Label = "Mann-Zeichnen-Test Test (Aston Index) - Entwicklungsalter", Type = "input", Value = "", TestungChapterId = 11 },
                    new { Id = 139, Label = "Mann-Zeichnen-Test Test (Aston Index) - Chronologisches Alter", Type = "input", Value = "", TestungChapterId = 11 },
                    new { Id = 140, Label = "Stiftgriff", Type = "textarea", Value = "", TestungChapterId = 12 },
                    new { Id = 141, Label = "Sitzposition", Type = "textarea", Value = "", TestungChapterId = 12 },
                    new { Id = 142, Label = "Schnelle Ermüdbarkeit", Type = "textarea", Value = "", TestungChapterId = 12 },
                    new { Id = 143, Label = "Kind ist ängstlich und besorgt und mit seinen Ergebnissen nicht zufrieden", Type = "textarea", Value = "", TestungChapterId = 12 },
                    new { Id = 144, Label = "Index der Dysfunktion", Type = "input", Value = "", TestungChapterId = 13 },
                    new { Id = 145, Label = "Grobmotorische Koordination und Gleichgewicht", Type = "textarea", Value = "", TestungChapterId = 13 },
                    new { Id = 146, Label = "Kleinhirnfunktionen", Type = "textarea", Value = "", TestungChapterId = 13 },
                    new { Id = 147, Label = "Dysdiadochokinese", Type = "textarea", Value = "", TestungChapterId = 13 },
                    new { Id = 148, Label = "Aberrante Reflexe", Type = "textarea", Value = "", TestungChapterId = 13 },
                    new { Id = 149, Label = "Okulomotorische Funktionen", Type = "textarea", Value = "", TestungChapterId = 13 },
                    new { Id = 150, Label = "Visuelle Wahrnehmungsfunktionen", Type = "textarea", Value = "", TestungChapterId = 13 }


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
