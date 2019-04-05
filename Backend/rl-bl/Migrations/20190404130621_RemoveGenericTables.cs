using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class RemoveGenericTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericQuestions");

            migrationBuilder.DropTable(
                name: "GenericChapters");

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 15, 6, 20, 780, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 4, 15, 6, 20, 773, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenericChapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericChapters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenericChapterId = table.Column<int>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericQuestions_GenericChapters_GenericChapterId",
                        column: x => x.GenericChapterId,
                        principalTable: "GenericChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Anamnesen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 44, 21, 546, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "GenericChapters",
                columns: new[] { "Id", "Name", "Score" },
                values: new object[,]
                {
                    { 1, "I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS", null },
                    { 2, "II. TESTS ZUR MOTORISCHEN ENTWICKLUNG", null },
                    { 3, "III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN", null },
                    { 4, "IV. TESTS ZUR DYSDIADOCHOKINESE", null },
                    { 5, "V. LINKS-RECHTS-DISKRIMINIERUNGSPROBLEME", null },
                    { 6, "VI. ORIENTIERUNGSPROBLEME", null },
                    { 7, "VII. RÄUMLICHE WAHRNEHMUNGSPROBLEME", null },
                    { 8, "VIII. TESTS ZU ABERRANTEN REFLEXEN", null },
                    { 9, "IX. TESTS ZUR SEITIGKEITSÜBERPRÜFUNG", null },
                    { 10, "X. ÜBERPRÜFUNG DER AUGENMUSKELMOTORIK", null },
                    { 11, "XI. VISUELLE WAHRNEHMUNGSÜBERPRÜFUNG", null },
                    { 12, "ZUSÄTZLICHE BEOBACHTUNGEN UND NOTIZEN", null },
                    { 13, "ERGEBNISZUSAMMENFASSUNG", null }
                });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 4, 3, 13, 44, 21, 540, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "GenericQuestions",
                columns: new[] { "Id", "GenericChapterId", "Label", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Aufrichten aus Rückenlage in den Stand", "radio", "" },
                    { 97, 9, "Handdominanz - Teleskop", "radioLeftRight", "" },
                    { 98, 9, "Augendominanz (Entfernung) - Teleskop", "radioLeftRight", "" },
                    { 99, 9, "Augendominanz (Entfernung) - Ring", "radioLeftRight", "" },
                    { 100, 9, "Augendominanz (Nähe) - Lochkarte", "radioLeftRight", "" },
                    { 101, 9, "Augendominanz (Nähe) - Ring", "radioLeftRight", "" },
                    { 102, 9, "Ohrdominanz - Muschel", "radioLeftRight", "" },
                    { 96, 9, "Handdominanz - Schreibhand", "radioLeftRight", "" },
                    { 103, 9, "Ohrdominanz - Lauschen", "radioLeftRight", "" },
                    { 105, 10, "Fixierungsschwierigkeiten", "radio", "" },
                    { 106, 10, "Beeinträchtigte Folgebewegungen (tracking- horizontal)", "radio", "" },
                    { 107, 10, "Beeinträchtigte Folgebewegungen (tracking-vertikal)", "radio", "" },
                    { 108, 10, "Verfolgen der Hand mit den Augen (eye-hand-tracking)", "radio", "" },
                    { 109, 10, "Augenzittern (Nystagmus)", "radio", "" },
                    { 110, 10, "Latente Konvergenz - links", "radio", "" },
                    { 104, 9, "Ohrdominanz - Rufen (Hinweis auf Hemisphärendominanz)", "radioLeftRight", "" },
                    { 95, 9, "Handdominanz - Klatschen in eine Hand", "radioLeftRight", "" },
                    { 94, 9, "Handdominanz - Einen Ball fangen", "radioLeftRight", "" },
                    { 93, 9, "Fußdominanz - Auf einem Bein hüpfen", "radioLeftRight", "" },
                    { 78, 8, "Babinski Reflex - linker Fuß", "radio", "" },
                    { 79, 8, "Babinski Reflex - rechter Fuß", "radio", "" },
                    { 80, 8, "Abdominal Reflex (optional)", "radio", "" },
                    { 81, 8, "Such-Reflex - links", "radio", "" },
                    { 82, 8, "Such-Reflex - rechts", "radio", "" },
                    { 83, 8, "Saug-Reflex", "radio", "" },
                    { 84, 8, "Erwachsener Saug-Reflex", "radio4", "" },
                    { 85, 8, "Palmar-Reflex - linke Hand", "radio", "" },
                    { 86, 8, "Palmar-Reflex - rechte Hand", "radio", "" },
                    { 87, 8, "Plantar-Reflex - linker Fuß", "radio", "" },
                    { 88, 8, "Plantar-Reflex - rechter Fuß", "radio", "" },
                    { 89, 8, "Landau-Reaktion", "radio", "" },
                    { 90, 9, "Fußdominanz - Ball schießen", "radioLeftRight", "" },
                    { 91, 9, "Fußdominanz - Aufstampfen mit einem Fuß", "radioLeftRight", "" },
                    { 92, 9, "Fußdominanz - Auf einen Stuhl steigen", "radioLeftRight", "" },
                    { 111, 10, "Latente Konvergenz - rechts", "radio", "" },
                    { 112, 10, "Latente Divergenz - links", "radio", "" },
                    { 113, 10, "Latente Divergenz - rechts", "radio", "" },
                    { 114, 10, "Konvergenzschwierigkeiten - linkes Auge", "radio", "" },
                    { 134, 11, "Räumliche Probleme - Daniels und Diack Figuren", "radio", "" },
                    { 135, 11, "Räumliche Probleme - Bender Visual Gestalt Figuren", "radio", "" },
                    { 136, 11, "Hinweis auf ‘Stimulusgebundenheit’", "radio", "" },
                    { 137, 11, "Abschreiben eines kurzen Textes", "input", "" },
                    { 138, 11, "Mann-Zeichnen-Test Test (Aston Index) - Entwicklungsalter", "input", "" },
                    { 139, 11, "Mann-Zeichnen-Test Test (Aston Index) - Chronologisches Alter", "input", "" },
                    { 140, 12, "Stiftgriff", "textarea", "" },
                    { 141, 12, "Sitzposition", "textarea", "" },
                    { 142, 12, "Schnelle Ermüdbarkeit", "textarea", "" },
                    { 143, 12, "Kind ist ängstlich und besorgt und mit seinen Ergebnissen nicht zufrieden", "textarea", "" },
                    { 144, 13, "Index der Dysfunktion", "input", "" },
                    { 145, 13, "Grobmotorische Koordination und Gleichgewicht", "textarea", "" },
                    { 146, 13, "Kleinhirnfunktionen", "textarea", "" },
                    { 147, 13, "Dysdiadochokinese", "textarea", "" },
                    { 148, 13, "Aberrante Reflexe", "textarea", "" },
                    { 133, 11, "Räumliche Probleme - Tansley Standard Figuren", "radio", "" },
                    { 77, 8, "Segmentäre Rollreaktion- von den Hüften (rechts)", "radio", "" },
                    { 132, 11, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Bender Visual Gestalt Figuren", "radio", "" },
                    { 130, 11, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Tansley Standard Figuren", "radio", "" },
                    { 115, 10, "Konvergenzschwierigkeiten - rechtes Auge", "radio", "" },
                    { 116, 10, "Schwierigkeit, die Augen unabhängig voneinander zu schließen - linkes Auge", "radio", "" },
                    { 117, 10, "Schwierigkeit, die Augen unabhängig voneinander zu schließen - rechtes Auge", "radio", "" },
                    { 118, 10, "Beeinträchtigung synchroner Augenbewegungen - linkes Auge", "radio", "" },
                    { 119, 10, "Beeinträchtigung synchroner Augenbewegungen - rechtes Auge", "radio", "" },
                    { 120, 10, "Erweiterte periphere Sicht - linkes Auge", "radio", "" },
                    { 121, 10, "Erweiterte periphere Sicht - rechtes Auge", "radio", "" },
                    { 122, 10, "Akkommodationsfähigkeit", "radio", "" },
                    { 123, 10, "Pupillenreaktion auf Licht (optional) - linkes Auge", "input", "" },
                    { 124, 10, "Pupillenreaktion auf Licht (optional) - rechtes Auge", "input", "" },
                    { 125, 10, "Pupillenreaktion auf Licht (optional) - linkes Auge", "input", "" },
                    { 126, 10, "Pupillenreaktion auf Licht (optional) - rechtes Auge", "input", "" },
                    { 127, 11, "Visuelle Unterscheidungsprobleme - Tansley Standard Figuren", "radio", "" },
                    { 128, 11, "Visuelle Unterscheidungsprobleme - Daniels und Diack Figuren", "radio", "" },
                    { 129, 11, "Visuelle Unterscheidungsprobleme - Bender Visual Gestalt Figuren", "radio", "" },
                    { 131, 11, "Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Daniels und Diack Figuren", "radio", "" },
                    { 76, 8, "Segmentäre Rollreaktion- von den Hüften (links)", "radio", "" },
                    { 75, 8, "Segmentäre Rollreaktion- von den Schultern (rechts)", "radio", "" },
                    { 74, 8, "Segmentäre Rollreaktion- von den Schultern (links)", "radio", "" },
                    { 21, 2, "Kriechen auf dem Bauch", "radio2", "" },
                    { 22, 2, "Krabbeln auf Händen und Knien", "radio3", "" },
                    { 23, 3, "Ferse auf Schienbein (linke Ferse auf rechtes Schienbein)", "radio", "" },
                    { 24, 3, "Ferse auf Schienbein (rechte Ferse auf linkes Schienbein)", "radio", "" },
                    { 25, 3, "Zeigefinger-Annäherung (Augen offen)", "radio", "" },
                    { 26, 3, "Zeigefinger-Annäherung (Augen geschlossen)", "radio", "" },
                    { 27, 3, "Finger an die Nase (Augen offen)", "radio", "" },
                    { 28, 3, "Finger an die Nase (Augen geschlossen)", "radio", "" },
                    { 29, 4, "Finger (linke Hand)", "radio", "" },
                    { 30, 4, "Finger (rechte Hand)", "radio", "" },
                    { 31, 4, "Hand (links)", "radio", "" },
                    { 32, 4, "Hand (rechts)", "radio", "" },
                    { 33, 4, "Fuß (links)", "radio", "" },
                    { 34, 4, "Fuß (rechts)", "radio", "" },
                    { 35, 5, "Links-Rechts-Diskriminierungsprobleme", "radioYesNo", "" },
                    { 20, 1, "Windmühle", "radio", "" },
                    { 36, 6, "Orientierungsprobleme", "radioYesNo", "" },
                    { 19, 1, "Hopserlauf", "radio", "" },
                    { 17, 1, "Fersengang (nur vorwärts)", "radio", "" },
                    { 2, 1, "Aufrichten aus Bauchlage in den Stand", "radio", "" },
                    { 3, 1, "Romberg Test (Augen geöffnet)", "radio", "" },
                    { 4, 1, "Romberg Test (Augen geschlossen)", "radio", "" },
                    { 5, 1, "Mann Test (Augen geöffnet)", "radio", "" },
                    { 6, 1, "Mann Test (Augen geschlossen)", "radio", "" },
                    { 7, 1, "Einbeinstand", "radio", "" },
                    { 8, 1, "Marschieren und Umdrehen", "radio", "" },
                    { 9, 1, "Zehenspitzengang (vorwärts) 0 1", "radio", "" },
                    { 10, 1, "Zehenspitzengang (rückwärts)", "radio", "" },
                    { 11, 1, "Tandem Gang (vorwärts)", "radio", "" },
                    { 12, 1, "Tandem Gang (rückwärts)", "radio", "" },
                    { 13, 1, "Fog Walk (vorwärts)", "radio", "" },
                    { 14, 1, "Fog Walk (rückwärts)", "radio", "" },
                    { 15, 1, "Slalom Gang (vorwärts)", "radio", "" },
                    { 16, 1, "Slalom Gang (rückwärts)", "radio", "" },
                    { 18, 1, "Hüpfen auf einem Bein (links oder rechts)", "radio", "" },
                    { 149, 13, "Okulomotorische Funktionen", "textarea", "" },
                    { 37, 7, "Räumliche Wahrnehmungsprobleme", "radioYesNo", "" },
                    { 39, 8, "Standard Test - linkes Bein", "radio", "" },
                    { 59, 8, "Moro Reflex / FPR - Aufrecht: TT", "radio", "" },
                    { 60, 8, "Moro Reflex / FPR - Aufrecht: ZT", "radio", "" },
                    { 61, 8, "Moro Reflex / FPR - Aufrecht: FF", "radio", "" },
                    { 62, 8, "Augenkopfstellreaktionen - nach links", "radio", "" },
                    { 63, 8, "Augenkopfstellreaktionen - nach rechts", "radio", "" },
                    { 64, 8, "Augenkopfstellreaktionen - vorwärts", "radio", "" },
                    { 65, 8, "Augenkopfstellreaktionen - rückwärts", "radio", "" },
                    { 66, 8, "Labyrinthkopfstellreaktionen - nach links", "radio", "" },
                    { 67, 8, "Labyrinthkopfstellreaktionen - nach rechts", "radio", "" },
                    { 68, 8, "Labyrinthkopfstellreaktionen - rückwärts", "radio", "" },
                    { 69, 8, "Labyrinthkopfstellreaktionen - vorwärts", "radio", "" },
                    { 70, 8, "Amphibien Reaktion - linke Seite (Rückenlage)", "radio", "" },
                    { 71, 8, "Amphibien Reaktion - rechte Seite (Rückenlage)", "radio", "" },
                    { 72, 8, "Amphibien Reaktion - linke Seite (Bauchlage)", "radio", "" },
                    { 73, 8, "Amphibien Reaktion - rechte Seite (Bauchlage)", "radio", "" },
                    { 58, 8, "Moro Reflex / FPR - Standard Test", "radio", "" },
                    { 38, 8, "Standard Test - linker Arm", "radio", "" },
                    { 57, 8, "TLR - Aufrechttest – Streckung", "radio", "" },
                    { 55, 8, "TLR - Standard Test", "radio", "" },
                    { 40, 8, "Standard Test - rechter Arm", "radio", "" },
                    { 41, 8, "Standard Test - rechtes Bein", "radio", "" },
                    { 42, 8, "Ayres Test Nr. 1 - linker Arm", "radio", "" },
                    { 43, 8, "Ayres Test Nr. 1 - rechter Arm", "radio", "" },
                    { 44, 8, "Ayres Test Nr. 2 - linker Arm", "radio", "" },
                    { 45, 8, "Ayres Test Nr. 2 - rechter Arm", "radio", "" },
                    { 46, 8, "Schilder Test - linker Arm", "radio", "" },
                    { 47, 8, "Schilder Test - rechter Arm", "radio", "" },
                    { 48, 8, "TTNR - von rechts nach links", "radio", "" },
                    { 49, 8, "TTNR - von links nach rechts", "radio", "" },
                    { 50, 8, "STNR - Füße oder Rumpf", "radio", "" },
                    { 51, 8, "STNR - Arme", "radio", "" },
                    { 52, 8, "STNR - Krabbeltest", "radio", "" },
                    { 53, 8, "Spinaler Galant-Reflex - linke Seite", "radio", "" },
                    { 54, 8, "Spinaler Galant-Reflex - rechte Seite", "radio", "" },
                    { 56, 8, "TLR - Aufrechttest - Beugung", "radio", "" },
                    { 150, 13, "Visuelle Wahrnehmungsfunktionen", "textarea", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenericQuestions_GenericChapterId",
                table: "GenericQuestions",
                column: "GenericChapterId");
        }
    }
}
