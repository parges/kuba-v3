using System;
using System.Collections.Generic;
using System.Data.Entity;
using rl_bl.Context;
using rl_contract.Models;

namespace rl_bl
{
    public class PatientBL
    {
        public PatientBL()
        {

        }

        public void addRelevantPatientData(Patient patient, DBContext context)
        {
            // Reviews zufügen
            addReviews(patient);

            // Testung zufügen
            addTestung(patient, context);

        }

        private void addTestung(Patient patient, DBContext context)
        {
            Testung testung = new Testung
            {
                Date = DateTime.Now,
                Name = "Testung - " + patient.Firstname + " " + patient.Lastname,
                PatientId = patient.Id
            };
            context.Testungen.Add(testung);
            context.SaveChanges();


            // Add Chapters
            int testungId = testung.Id.Value;

            TestungChapter firstChapter = new TestungChapter
            {
                Name = "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS",
                TestungId = testungId
            };
            TestungChapter[] chapters = new TestungChapter[]
            {
                new TestungChapter { Name = "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG", TestungId = testungId, Score = -1},
                new TestungChapter { Name = "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "IV. TESTS ZUR DYSDIADOCHOKINESE", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "V. LINKS-RECHTS-DISKRIMINIERUNGSPROBLEME", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "VI. ORIENTIERUNGSPROBLEME", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "VII. RÄUMLICHE WAHRNEHMUNGSPROBLEME", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "VIII. TESTS ZU ABERRANTEN REFLEXEN", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "IX. TESTS ZUR SEITIGKEITSÜBERPRÜFUNG", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "X. ÜBERPRÜFUNG DER AUGENMUSKELMOTORIK", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "XI. VISUELLE WAHRNEHMUNGSÜBERPRÜFUNG", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "ZUSÄTZLICHE BEOBACHTUNGEN UND NOTIZEN", TestungId = testungId, Score = -1 },
                new TestungChapter { Name = "ERGEBNISZUSAMMENFASSUNG", TestungId = testungId, Score = -1 }
            };

            testung.Chapters = new List<TestungChapter>();
            testung.Chapters.Add(firstChapter);
            testung.Chapters.AddRange(chapters);
            context.SaveChanges();

            int firstChapterId = firstChapter.Id.Value;

            // Add Questions
            TestungQuestion[] listQuestions = new TestungQuestion[]
            {
                new TestungQuestion { Label = "Aufrichten aus Rückenlage in den Stand", Type = "radio", Value = "", TestungChapterId = firstChapterId  },
                new TestungQuestion { Label = "Aufrichten aus Bauchlage in den Stand", Type = "radio",  Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Romberg Test (Augen geöffnet)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Romberg Test (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Mann Test (Augen geöffnet)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Mann Test (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Einbeinstand", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Marschieren und Umdrehen", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Zehenspitzengang (vorwärts) 0 1", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Zehenspitzengang (rückwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Tandem Gang (vorwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Tandem Gang (rückwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Fog Walk (vorwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Fog Walk (rückwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Slalom Gang (vorwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Slalom Gang (rückwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Fersengang (nur vorwärts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Hüpfen auf einem Bein (links oder rechts)", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Hopserlauf", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Windmühle", Type = "radio", Value = "", TestungChapterId = firstChapterId },
                new TestungQuestion { Label = "Kriechen auf dem Bauch", Type = "radio2", Value = "", TestungChapterId = firstChapterId+1 },
                new TestungQuestion { Label = "Krabbeln auf Händen und Knien", Type = "radio3", Value = "", TestungChapterId = firstChapterId+1 },
                new TestungQuestion { Label = "Ferse auf Schienbein (linke Ferse auf rechtes Schienbein)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Ferse auf Schienbein (rechte Ferse auf linkes Schienbein)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Zeigefinger-Annäherung (Augen offen)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Zeigefinger-Annäherung (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Finger an die Nase (Augen offen)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Finger an die Nase (Augen geschlossen)", Type = "radio", Value = "", TestungChapterId = firstChapterId+2 },
                new TestungQuestion { Label = "Finger (linke Hand)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Finger (rechte Hand)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Hand (links)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Hand (rechts)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Fuß (links)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Fuß (rechts)", Type = "radio", Value = "", TestungChapterId = firstChapterId+3 },
                new TestungQuestion { Label = "Links-Rechts-Diskriminierungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = firstChapterId+4 },
                new TestungQuestion { Label = "Orientierungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = firstChapterId+5 },
                new TestungQuestion { Label = "Räumliche Wahrnehmungsprobleme", Type = "radioYesNo", Value = "", TestungChapterId = firstChapterId+6 },
                new TestungQuestion { Label = "Standard Test - linker Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Standard Test - linkes Bein", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Standard Test - rechter Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Standard Test - rechtes Bein", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Ayres Test Nr. 1 - linker Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Ayres Test Nr. 1 - rechter Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Ayres Test Nr. 2 - linker Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Ayres Test Nr. 2 - rechter Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Schilder Test - linker Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Schilder Test - rechter Arm", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "TTNR - von rechts nach links", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "TTNR - von links nach rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "STNR - Füße oder Rumpf", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "STNR - Arme", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "STNR - Krabbeltest", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Spinaler Galant-Reflex - linke Seite", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Spinaler Galant-Reflex - rechte Seite", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "TLR - Standard Test", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "TLR - Aufrechttest - Beugung", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "TLR - Aufrechttest – Streckung", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Moro Reflex / FPR - Standard Test", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Moro Reflex / FPR - Aufrecht: TT", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Moro Reflex / FPR - Aufrecht: ZT", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Moro Reflex / FPR - Aufrecht: FF", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Augenkopfstellreaktionen - nach links", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Augenkopfstellreaktionen - nach rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Augenkopfstellreaktionen - vorwärts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Augenkopfstellreaktionen - rückwärts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Labyrinthkopfstellreaktionen - nach links", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Labyrinthkopfstellreaktionen - nach rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Labyrinthkopfstellreaktionen - rückwärts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Labyrinthkopfstellreaktionen - vorwärts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Amphibien Reaktion - linke Seite (Rückenlage)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Amphibien Reaktion - rechte Seite (Rückenlage)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Amphibien Reaktion - linke Seite (Bauchlage)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Amphibien Reaktion - rechte Seite (Bauchlage)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Segmentäre Rollreaktion- von den Schultern (links)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Segmentäre Rollreaktion- von den Schultern (rechts)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Segmentäre Rollreaktion- von den Hüften (links)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Segmentäre Rollreaktion- von den Hüften (rechts)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Babinski Reflex - linker Fuß", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Babinski Reflex - rechter Fuß", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Abdominal Reflex (optional)", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Such-Reflex - links", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Such-Reflex - rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Saug-Reflex", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Erwachsener Saug-Reflex", Type = "radio4", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Palmar-Reflex - linke Hand", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Palmar-Reflex - rechte Hand", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Plantar-Reflex - linker Fuß", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Plantar-Reflex - rechter Fuß", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Landau-Reaktion", Type = "radio", Value = "", TestungChapterId = firstChapterId+7 },
                new TestungQuestion { Label = "Fußdominanz - Ball schießen", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Fußdominanz - Aufstampfen mit einem Fuß", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Fußdominanz - Auf einen Stuhl steigen", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Fußdominanz - Auf einem Bein hüpfen", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Handdominanz - Einen Ball fangen", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Handdominanz - Klatschen in eine Hand", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Handdominanz - Schreibhand", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Handdominanz - Teleskop", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Augendominanz (Entfernung) - Teleskop", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Augendominanz (Entfernung) - Ring", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Augendominanz (Nähe) - Lochkarte", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Augendominanz (Nähe) - Ring", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Ohrdominanz - Muschel", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Ohrdominanz - Lauschen", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Ohrdominanz - Rufen (Hinweis auf Hemisphärendominanz)", Type = "radioLeftRight", Value = "", TestungChapterId = firstChapterId+8 },
                new TestungQuestion { Label = "Fixierungsschwierigkeiten", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Beeinträchtigte Folgebewegungen (tracking- horizontal)", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Beeinträchtigte Folgebewegungen (tracking-vertikal)", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Verfolgen der Hand mit den Augen (eye-hand-tracking)", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Augenzittern (Nystagmus)", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Latente Konvergenz - links", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Latente Konvergenz - rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Latente Divergenz - links", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Latente Divergenz - rechts", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Konvergenzschwierigkeiten - linkes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Konvergenzschwierigkeiten - rechtes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Schwierigkeit, die Augen unabhängig voneinander zu schließen - linkes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Schwierigkeit, die Augen unabhängig voneinander zu schließen - rechtes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Beeinträchtigung synchroner Augenbewegungen - linkes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Beeinträchtigung synchroner Augenbewegungen - rechtes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Erweiterte periphere Sicht - linkes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Erweiterte periphere Sicht - rechtes Auge", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Akkommodationsfähigkeit", Type = "radio", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Pupillenreaktion auf Licht (optional) - linkes Auge", Type = "input", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Pupillenreaktion auf Licht (optional) - rechtes Auge", Type = "input", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Pupillenreaktion auf Licht (optional) - linkes Auge", Type = "input", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Pupillenreaktion auf Licht (optional) - rechtes Auge", Type = "input", Value = "", TestungChapterId = firstChapterId+9 },
                new TestungQuestion { Label = "Visuelle Unterscheidungsprobleme - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Visuelle Unterscheidungsprobleme - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Visuelle Unterscheidungsprobleme - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Räumliche Probleme - Tansley Standard Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Räumliche Probleme - Daniels und Diack Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Räumliche Probleme - Bender Visual Gestalt Figuren", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Hinweis auf ‘Stimulusgebundenheit’", Type = "radio", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Abschreiben eines kurzen Textes", Type = "input", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Mann-Zeichnen-Test Test (Aston Index) - Entwicklungsalter", Type = "input", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Mann-Zeichnen-Test Test (Aston Index) - Chronologisches Alter", Type = "input", Value = "", TestungChapterId = firstChapterId+10 },
                new TestungQuestion { Label = "Stiftgriff", Type = "textarea", Value = "", TestungChapterId = firstChapterId+11 },
                new TestungQuestion { Label = "Sitzposition", Type = "textarea", Value = "", TestungChapterId = firstChapterId+11 },
                new TestungQuestion { Label = "Schnelle Ermüdbarkeit", Type = "textarea", Value = "", TestungChapterId = firstChapterId+11 },
                new TestungQuestion { Label = "Kind ist ängstlich und besorgt und mit seinen Ergebnissen nicht zufrieden", Type = "textarea", Value = "", TestungChapterId = firstChapterId+11 },
                new TestungQuestion { Label = "Index der Dysfunktion", Type = "input", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Grobmotorische Koordination und Gleichgewicht", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Kleinhirnfunktionen", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Dysdiadochokinese", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Aberrante Reflexe", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Okulomotorische Funktionen", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 },
                new TestungQuestion { Label = "Visuelle Wahrnehmungsfunktionen", Type = "textarea", Value = "", TestungChapterId = firstChapterId+12 }
            };
            context.TestungQuestions.AddRange(listQuestions);
            patient.Testung = testung;
        }

        private void addReviews(Patient patient)
        {
            string[] list = new[] { "Befundgespräch", "1. Review", "2. Review", "3. Review", "4. Review", "5. Review", "6. Review", "7. Review", "8. Review", "9. Review" };
            patient.Reviews = new List<Review>();

            int i = 0;
            foreach (string entry in list)
            {
                var review = new Review
                {
                    Date = DateTime.Now.Date.AddMonths(i),
                    Name = entry,
                    Payed = false,
                    Exercises = "",
                    Reasons = "",
                    PatientId = patient.Id
                };
                patient.Reviews.Add(review);
                i++;
            }
        }
    }
}
