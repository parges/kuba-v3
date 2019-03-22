using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class fullyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TestungChapters",
                columns: new[] { "Id", "Name", "TestungId" },
                values: new object[,]
                {
                    { 4, "IV. TESTS ZUR DYSDIADOCHOKINESE", 1 },
                    { 5, "V. LINKS-RECHTS-DISKRIMINIERUNGSPROBLEME", 1 },
                    { 6, "VI. ORIENTIERUNGSPROBLEME", 1 },
                    { 7, "VII. RÄUMLICHE WAHRNEHMUNGSPROBLEME", 1 },
                    { 8, "VIII. TESTS ZU ABERRANTEN REFLEXEN", 1 },
                    { 9, "IX. TESTS ZUR SEITIGKEITSÜBERPRÜFUNG", 1 },
                    { 10, "X. ÜBERPRÜFUNG DER AUGENMUSKELMOTORIK", 1 },
                    { 11, "XI. VISUELLE WAHRNEHMUNGSÜBERPRÜFUNG", 1 },
                    { 12, "ZUSÄTZLICHE BEOBACHTUNGEN UND NOTIZEN", 1 },
                    { 13, "ERGEBNISZUSAMMENFASSUNG", 1 }
                });

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Label",
                value: "Romberg Test (Augen geschlossen)");

            migrationBuilder.InsertData(
                table: "TestungQuestions",
                columns: new[] { "Id", "Label", "TestungChapterId", "Type", "Value" },
                values: new object[,]
                {
                    { 18, "Hüpfen auf einem Bein (links oder rechts)", 1, "radio", "" },
                    { 19, "Hopserlauf", 1, "radio", "" },
                    { 20, "Windmühle", 1, "radio", "" },
                    { 21, "Kriechen auf dem Bauch", 2, "radio", "" },
                    { 22, "Krabbeln auf Händen und Knien", 2, "radio", "" },
                    { 10, "Zehenspitzengang (rückwärts)", 1, "radio", "" },
                    { 24, "Ferse auf Schienbein (rechte Ferse auf linkes Schienbein)", 3, "radio", "" },
                    { 25, "Zeigefinger-Annäherung (Augen offen)", 3, "radio", "" },
                    { 26, "Zeigefinger-Annäherung (Augen geschlossen)", 3, "radio", "" },
                    { 17, "Fersengang (nur vorwärts)", 1, "radio", "" },
                    { 23, "Ferse auf Schienbein (linke Ferse auf rechtes Schienbein)", 3, "radio", "" },
                    { 16, "Slalom Gang (rückwärts)", 1, "radio", "" },
                    { 28, "Finger an die Nase (Augen geschlossen)", 3, "radio", "" },
                    { 14, "Fog Walk (rückwärts)", 1, "radio", "" },
                    { 13, "Fog Walk (vorwärts)", 1, "radio", "" },
                    { 12, "Tandem Gang (rückwärts)", 1, "radio", "" },
                    { 11, "Tandem Gang (vorwärts)", 1, "radio", "" },
                    { 27, "Finger an die Nase (Augen offen)", 3, "radio", "" },
                    { 9, "Zehenspitzengang (vorwärts) 0 1", 1, "radio", "" },
                    { 8, "Marschieren und Umdrehen", 1, "radio", "" },
                    { 7, "Einbeinstand", 1, "radio", "" },
                    { 6, "Mann Test (Augen geschlossen)", 1, "radio", "" },
                    { 5, "Mann Test (Augen geöffnet)", 1, "radio", "" },
                    { 15, "Slalom Gang (vorwärts)", 1, "radio", "" }
                });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 21, 14, 56, 59, 734, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "TestungQuestions",
                columns: new[] { "Id", "Label", "TestungChapterId", "Type", "Value" },
                values: new object[,]
                {
                    { 29, "Finger (linke Hand)", 4, "radio", "" },
                    { 117, "Schwierigkeit, die Augen unabhängig voneinander zu schließen - rechtes Auge", 10, "radio", "" },
                    { 116, "Schwierigkeit, die Augen unabhängig voneinander zu schließen - linkes Auge", 10, "radio", "" },
                    { 115, "Konvergenzschwierigkeiten - rechtes Auge", 10, "radio", "" },
                    { 114, "Konvergenzschwierigkeiten - linkes Auge", 10, "radio", "" },
                    { 113, "Latente Divergenz - rechts", 10, "radio", "" },
                    { 112, "Latente Divergenz - links", 10, "radio", "" },
                    { 111, "Latente Konvergenz - rechts", 10, "radio", "" },
                    { 110, "Latente Konvergenz - links", 10, "radio", "" },
                    { 109, "Augenzittern (Nystagmus)", 10, "radio", "" },
                    { 108, "Verfolgen der Hand mit den Augen (eye-hand-tracking)", 10, "radio", "" },
                    { 107, "Beeinträchtigte Folgebewegungen (tracking-vertikal)", 10, "radio", "" },
                    { 106, "Beeinträchtigte Folgebewegungen (tracking- horizontal)", 10, "radio", "" },
                    { 118, "Beeinträchtigung synchroner Augenbewegungen - linkes Auge", 10, "radio", "" },
                    { 105, "Fixierungsschwierigkeiten", 10, "radio", "" },
                    { 103, "Ohrdominanz - Lauschen", 9, "radio", "" },
                    { 102, "Ohrdominanz - Muschel", 9, "radio", "" },
                    { 101, "Augendominanz (Nähe) - Ring", 9, "radio", "" },
                    { 100, "Augendominanz (Nähe) - Lochkarte", 9, "radio", "" },
                    { 99, "Augendominanz (Entfernung) - Ring", 9, "radio", "" },
                    { 98, "Augendominanz (Entfernung) - Teleskop", 9, "radio", "" },
                    { 97, "Handdominanz - Teleskop", 9, "radio", "" },
                    { 96, "Handdominanz - Schreibhand", 9, "radio", "" },
                    { 95, "Handdominanz - Klatschen in eine Hand", 9, "radio", "" },
                    { 94, "Handdominanz - Einen Ball fangen", 9, "radio", "" },
                    { 93, "Fußdominanz - Auf einem Bein hüpfen", 9, "radio", "" },
                    { 92, "Fußdominanz - Auf einen Stuhl steigen", 9, "radio", "" },
                    { 104, "Ohrdominanz - Rufen (Hinweis auf Hemisphärendominanz)", 9, "radio", "" },
                    { 119, "Beeinträchtigung synchroner Augenbewegungen - rechtes Auge", 10, "radio", "" },
                    { 120, "Erweiterte periphere Sicht - linkes Auge", 10, "radio", "" },
                    { 121, "Erweiterte periphere Sicht - rechtes Auge", 10, "radio", "" },
                    { 148, "Aberrante Reflexe", 13, "textarea", "" },
                    { 147, "Dysdiadochokinese", 13, "textarea", "" },
                    { 146, "Kleinhirnfunktionen", 13, "textarea", "" },
                    { 145, "Grobmotorische Koordination und Gleichgewicht", 13, "textarea", "" },
                    { 144, "Index der Dysfunktion", 13, "input", "" },
                    { 143, "Kind ist ängstlich und besorgt und mit seinen Ergebnissen nicht zufrieden", 12, "textarea", "" },
                    { 142, "Schnelle Ermüdbarkeit", 12, "textarea", "" },
                    { 141, "Sitzposition", 12, "textarea", "" },
                    { 140, "Stiftgriff", 12, "textarea", "" },
                    { 139, "Mann-Zeichnen-Test Test (Aston Index) - Chronologisches Alter", 11, "input", "" },
                    { 138, "Mann-Zeichnen-Test Test (Aston Index) - Entwicklungsalter", 11, "input", "" },
                    { 137, "Abschreiben eines kurzen Textes", 11, "input", "" },
                    { 136, "Hinweis auf ‘Stimulusgebundenheit’", 11, "radio", "" },
                    { 135, "Räumliche Probleme - Bender Visual Gestalt Figuren", 11, "radio", "" },
                    { 134, "Räumliche Probleme - Daniels und Diack Figuren", 11, "radio", "" },
                    { 133, "Räumliche Probleme - Tansley Standard Figuren", 11, "radio", "" },
                    { 132, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Bender Visual Gestalt Figuren", 11, "radio", "" },
                    { 131, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Daniels und Diack Figuren", 11, "radio", "" },
                    { 130, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Tansley Standard Figuren", 11, "radio", "" },
                    { 129, "Visuelle Unterscheidungsprobleme - Bender Visual Gestalt Figuren", 11, "radio", "" },
                    { 128, "Visuelle Unterscheidungsprobleme - Daniels und Diack Figuren", 11, "radio", "" },
                    { 127, "Visuelle Unterscheidungsprobleme - Tansley Standard Figuren", 11, "radio", "" },
                    { 126, "Pupillenreaktion auf Licht (optional) - rechtes Auge", 10, "input", "" },
                    { 125, "Pupillenreaktion auf Licht (optional) - linkes Auge", 10, "input", "" },
                    { 124, "Pupillenreaktion auf Licht (optional) - rechtes Auge", 10, "input", "" },
                    { 123, "Pupillenreaktion auf Licht (optional) - linkes Auge", 10, "input", "" },
                    { 122, "Akkommodationsfähigkeit", 10, "radio", "" },
                    { 91, "Fußdominanz - Aufstampfen mit einem Fuß", 9, "radio", "" },
                    { 90, "Fußdominanz - Ball schießen", 9, "radio", "" },
                    { 89, "Landau-Reaktion", 8, "radio", "" },
                    { 88, "Plantar-Reflex - rechter Fuß", 8, "radio", "" },
                    { 56, "TLR - Aufrechttest - Beugung", 8, "radio", "" },
                    { 55, "TLR - Standard Test", 8, "radio", "" },
                    { 54, "Spinaler Galant-Reflex - rechte Seite", 8, "radio", "" },
                    { 53, "Spinaler Galant-Reflex - linke Seite", 8, "radio", "" },
                    { 52, "STNR - Krabbeltest", 8, "radio", "" },
                    { 51, "STNR - Arme", 8, "radio", "" },
                    { 50, "STNR - Füße oder Rumpf", 8, "radio", "" },
                    { 49, "TTNR - von links nach rechts", 8, "radio", "" },
                    { 48, "TTNR - von rechts nach links", 8, "radio", "" },
                    { 47, "Schilder Test - rechter Arm", 8, "radio", "" },
                    { 46, "Schilder Test - linker Arm", 8, "radio", "" },
                    { 45, "Ayres Test Nr. 2 - rechter Arm", 8, "radio", "" },
                    { 44, "Ayres Test Nr. 2 - linker Arm", 8, "radio", "" },
                    { 43, "Ayres Test Nr. 1 - rechter Arm", 8, "radio", "" },
                    { 42, "Ayres Test Nr. 1 - linker Arm", 8, "radio", "" },
                    { 41, "Standard Test - rechtes Bein", 8, "radio", "" },
                    { 40, "Standard Test - rechter Arm", 8, "radio", "" },
                    { 39, "Standard Test - linkes Bein", 8, "radio", "" },
                    { 38, "Standard Test - linker Arm", 8, "radio", "" },
                    { 37, "Räumliche Wahrnehmungsprobleme", 7, "radio", "" },
                    { 36, "Orientierungsprobleme", 6, "radio", "" },
                    { 35, "Links-Rechts-Diskriminierungsprobleme", 5, "radio", "" },
                    { 34, "Fuß (rechts)", 4, "radio", "" },
                    { 33, "Fuß (links)", 4, "radio", "" },
                    { 32, "Hand (rechts)", 4, "radio", "" },
                    { 31, "Hand (links)", 4, "radio", "" },
                    { 30, "Finger (rechte Hand)", 4, "radio", "" },
                    { 57, "TLR - Aufrechttest – Streckung", 8, "radio", "" },
                    { 149, "Okulomotorische Funktionen", 13, "textarea", "" },
                    { 58, "Moro Reflex / FPR - Standard Test", 8, "radio", "" },
                    { 60, "Moro Reflex / FPR - Aufrecht: ZT", 8, "radio", "" },
                    { 87, "Plantar-Reflex - linker Fuß", 8, "radio", "" },
                    { 86, "Palmar-Reflex - rechte Hand", 8, "radio", "" },
                    { 85, "Palmar-Reflex - linke Hand", 8, "radio", "" },
                    { 84, "Erwachsener Saug-Reflex", 8, "radio", "" },
                    { 83, "Saug-Reflex", 8, "radio", "" },
                    { 82, "Such-Reflex - rechts", 8, "radio", "" },
                    { 81, "Such-Reflex - links", 8, "radio", "" },
                    { 80, "Abdominal Reflex (optional)", 8, "radio", "" },
                    { 79, "Babinski Reflex - rechter Fuß", 8, "radio", "" },
                    { 78, "Babinski Reflex - linker Fuß", 8, "radio", "" },
                    { 77, "Segmentäre Rollreaktion- von den Hüften (rechts)", 8, "radio", "" },
                    { 76, "Segmentäre Rollreaktion- von den Hüften (links)", 8, "radio", "" },
                    { 75, "Segmentäre Rollreaktion- von den Schultern (rechts)", 8, "radio", "" },
                    { 74, "Segmentäre Rollreaktion- von den Schultern (links)", 8, "radio", "" },
                    { 73, "Amphibien Reaktion - rechte Seite (Bauchlage)", 8, "radio", "" },
                    { 72, "Amphibien Reaktion - linke Seite (Bauchlage)", 8, "radio", "" },
                    { 71, "Amphibien Reaktion - rechte Seite (Rückenlage)", 8, "radio", "" },
                    { 70, "Amphibien Reaktion - linke Seite (Rückenlage)", 8, "radio", "" },
                    { 69, "Labyrinthkopfstellreaktionen - vorwärts", 8, "radio", "" },
                    { 68, "Labyrinthkopfstellreaktionen - rückwärts", 8, "radio", "" },
                    { 67, "Labyrinthkopfstellreaktionen - nach rechts", 8, "radio", "" },
                    { 66, "Labyrinthkopfstellreaktionen - nach links", 8, "radio", "" },
                    { 65, "Augenkopfstellreaktionen - rückwärts", 8, "radio", "" },
                    { 64, "Augenkopfstellreaktionen - vorwärts", 8, "radio", "" },
                    { 63, "Augenkopfstellreaktionen - nach rechts", 8, "radio", "" },
                    { 62, "Augenkopfstellreaktionen - nach links", 8, "radio", "" },
                    { 61, "Moro Reflex / FPR - Aufrecht: FF", 8, "radio", "" },
                    { 59, "Moro Reflex / FPR - Aufrecht: TT", 8, "radio", "" },
                    { 150, "Visuelle Wahrnehmungsfunktionen", 13, "textarea", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TestungChapters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "TestungQuestions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Label",
                value: "Tandem Gang (rückwärts)");

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 18, 21, 2, 30, 413, DateTimeKind.Local));
        }
    }
}
