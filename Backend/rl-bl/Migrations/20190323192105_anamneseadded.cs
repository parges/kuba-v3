using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kubaapi.Migrations
{
    public partial class anamneseadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamnesen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CountOfPositivAnswers = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamnesen_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnamneseChapters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AnamneseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamneseChapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnamneseChapters_Anamnesen_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamnesen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnamneseQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    MetaInfo = table.Column<string>(nullable: true),
                    TextPrefix = table.Column<string>(nullable: true),
                    AnamneseChapterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnamneseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnamneseQuestions_AnamneseChapters_AnamneseChapterId",
                        column: x => x.AnamneseChapterId,
                        principalTable: "AnamneseChapters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Anamnesen",
                columns: new[] { "Id", "CountOfPositivAnswers", "Date", "Name", "PatientId" },
                values: new object[] { 1, -1, new DateTime(2019, 3, 23, 20, 21, 5, 261, DateTimeKind.Local), "Anamnese (Fragebogen / Kinder)", 1 });

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 23, 20, 21, 5, 255, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "AnamneseChapters",
                columns: new[] { "Id", "AnamneseId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "0. Allgemeines" },
                    { 2, 1, "I. Schwangerschaft" },
                    { 3, 1, "II. Geburt" },
                    { 4, 1, "- ENDE 1 Teil(7 - 8 JA Antworten) + Frage 18./ 22.a) / 24. -> Bitte beantworten Sie die folgenden Fragen, bis sie altersgemäß nicht mehr zutreffen - " },
                    { 5, 1, "III. Schulzeit: 6. – 8. Lebensjahr" },
                    { 6, 1, "IV. 8. - 10. Lebensjahr" },
                    { 7, 1, "V. Zusätzliche Angaben" }
                });

            migrationBuilder.InsertData(
                table: "AnamneseQuestions",
                columns: new[] { "Id", "AnamneseChapterId", "Label", "MetaInfo", "TextPrefix", "Type", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Leidensdruck beim Kind?", null, null, "textarea", "" },
                    { 28, 3, "Hatte es während der ersten 18 Lebensmonate irgendwelche Krankheiten, die mit hohem Fieber und / oder Krämpfen verbunden waren ? ", "sehr schnell, sehr hoch gefiebert, Narkose", "Falls ja, bitte Einzelheiten angeben (konnte es nach der Krankheit etwas nicht mehr so gut wie vorher?)", "radioYesNo, textarea", "" },
                    { 29, 3, "Hatte es  auffällige Schwierigkeiten sich selber anziehen zu lernen?", "Reihenfolge, falsch herum, Schleife (>5 bis 5,6Jahre), Knöpfe, Reißverschluss, „bequem / faul“, Hose fällt schwer anzuziehen", "", "radioYesNo", "" },
                    { 30, 3, "Litt bzw. leidet Ihr Kind unter Hautproblemen (trockene Haut, Milchschorf,  Neurodermitis, Ekzeme) oder Asthma(Husten, Reizhusten)?", "", "", "radioYesNo", "" },
                    { 31, 3, "Zeigt es irgendwelche allergische Reaktionen? ", "Allergien in der Familie, Heuschnupfen, Auslöser: Milch/Eier/Weizen, ständig laufende Nase, Suchtmittel", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 32, 3, "Gab es irgendwelche auffälligen Reaktionen nach den  Impfungen?", "längeres schlafen, erhöhte Temperatur", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 33, 3, "Lutschte Ihr Kind bis etwa zum 5. Lebensjahr oder länger am Daumen? (Hatte es einen Schnuller (> 2 LJ?), Kuscheltier)", "", "Falls ja, an welchem (links, rechts):", "radioYesNo, input", "" },
                    { 34, 3, "Machte oder macht  Ihr Kind auch noch nach dem Alter von 5 Jahren gelegentlich ins Bett?", "Wann war es trocken? Toilettentraining, spinaler Galant, gehäufte Mittelohrentzündungen, Hypoglykämie, nächtlicher O² Mangel, viel Milch Trinker", "", "radioYesNo", "" },
                    { 35, 3, "Zusätzliche Angaben zum Vorschulalter (Auffälligkeiten in der Motorik, Sport, externe Betreuung, Trennungsangst, Schreckhaft, Ängstlich, viele Freunde, Einzelgänger, Streit, Reaktionen auf Veränderungen, emotionale Auffälligkeiten, was sagen die Erzieher über das Kind, schneiden, malen, puzzeln, Körperhaltung, Spielverhalten, zündeln, Beziehung zu Tieren, Verletzungen)", "", "", "radioYesNo, textarea", "" },
                    { 36, 5, "Leidet Ihr Kind unter Reiseübelkeit?", "> 8Jahre, Auto fahren und lesen, Schiffe, Trampolin, Schaukeln, Höhenangst, Karussell, Fahrstuhl, Klettern", "", "radioYesNo", "" },
                    { 37, 5, "Hatte Ihr Kind in den ersten zwei Grundschuljahren Schwierigkeiten, das Lesen zu lernen?", "Tempo, Betonung, Motivation, spezielle Bücher, Comics", "", "radioYesNo", "" },
                    { 27, 3, "Hat Ihr Kind spät sprechen gelernt (Zwei- und Dreiwortsätze) (> 2,5 Jahre)?", "eigene Sprache, gesabbert, Schwierigkeiten bei bestimmten Lauten, Gesungene Sprache", "", "radioYesNo", "" },
                    { 38, 5, "Hatte es Schwierigkeiten beim Schreiben lernen?", "Sitzhaltung, Stifthaltung, Rechtschreibung, Grammatik, Motorik beim Schreiben, schreiben anstrengend, kann es die Linien halten, drückt es stark auf, sehr kleine Schrift", "", "radioYesNo", "" },
                    { 40, 5, "Hatte Schwierigkeiten, die Uhrzeit ablesen zu lernen (nicht Digitaluhr) bzw. sich insgesamt in der Zeit(Wochentage, Monate etc.) zurecht zu finden ? > 8.LJ", "räumliche Wahrnehmung, Morgens/ Mittags/ Abends, Gestern/ Morgen, Jahreszeiten, Orientierungssinn, Orientierung im Raum, Geschwindigkeit beim Anziehen, Aufräumen", "", "radioYesNo", "" },
                    { 41, 5, "Hatte es Schwierigkeiten, Fahrradfahren (ohne Stützräder) zu lernen?", "kann es fahren, seit wann, langsam fahren möglich, wie fährt es", "", "radioYesNo", "" },
                    { 42, 5, "Hatte es Schwierigkeiten, Schwimmen zu lernen?", "Verhältnis zum Wasser", "", "radioYesNo", "" },
                    { 43, 5, "Konnte es besser unter als über Wasser schwimmen?", "", "", "radioYesNo", "" },
                    { 44, 5, "Hatte Ihr Kind im Verlauf der ersten 8 Lebensjahre (ausgenommen die ersten 18 Lebensmonate) Krankheiten mit sehr hohem Fieber, Bewusstlosigkeit oder Krämpfen ? ", "Vollnarkose, Infektanfälligkeit, Antibiotika, Meningitis, Tumore, Frakturen", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 45, 5, "War / ist Ihr Kind ein „Hals- Nasen- und Ohren“ Kind, d.h. litt / leidet es an häufigen Infektionen im Hals -, Nasen - und Ohrenbereich ? ", "Schnupfnase, Mittelohrentzündungen → Hörminderung → Ursache sind dann nicht die Reflexe", "", "radioYesNo", "" },
                    { 46, 5, "Hatte bzw. hat Ihr Kind Schwierigkeiten, einen (kleinen) Ball zu fangen oder andere Auge- / Hand - Koordinationsprobleme ? ", "Dyspraxie → kleckern beim Essen und Trinken, Fixierungsprobleme, Raum – Zeit – Gefühl gering, Schreckhaft, Verhältnis zu Bällen, Tollpatschig, zu langsam, zu schnell, greift gar nicht, beim hinfallen abgestützt", "", "radioYesNo", "" },
                    { 47, 6, "Hat Ihr Kind Schwierigkeiten still zu sitzen und wird es deswegen ständig vom Lehrer ermahnt ? Bevorzugt es auffällige Sitzpositionen?", "spinaler Galant (Stuhllehne/Gürtel), W – Sitz, Körperhaltung, Beinhaltung (um den Stuhl geschlungen/ hochgezogenes Bein),Sitzdauer, kippeln, liegend schreibend, Geräuscherzeugung", "", "radioYesNo", "" },
                    { 48, 6, "Macht Ihr Kind zahlreiche Fehler, wenn es aus einem Buch oder von der Tafel abschreibt?", "", "", "radioYesNo", "" },
                    { 49, 6, "Wenn Ihr Kind in Schule einen Aufsatz schreibt, verdreht es dabei gelegentlich Buchstaben oder lässt einzelne Buchstaben oder Wörter aus(auch evtl.Zahlendreher) ? ", "lesen von rechts nach links, häufige Dreher > 8LJ", "", "radioYesNo", "" },
                    { 39, 5, "Falls es zunächst Druckschrift erlernte, hatte es Probleme mit der Schreibschrift?", "", "", "radioYesNo", "" },
                    { 50, 6, "Reagiert Ihr Kind bei plötzlichen, unerwarteten Geräuschen oder Bewegungen auffallend stark?", "Silvester, Staubsauger, Gewitter, Luftballons, Sportarten, Hobby, bewegt es sich gern, Traumverhalten / Albträume, Schlafhaltung", "", "radioYesNo", "" },
                    { 26, 3, "Hat Ihr Kind auffallend spät (> 1,5 Jahre) oder früh (< 12 Monate) laufen gelernt?", "Lauflerngeräte, Babywippe, Maxi- Kosi, Hopser", "", "radioYesNo", "" },
                    { 24, 3, "Hat ihr Kind nicht ausreichend/ wenig Zeit in BL verbracht bis zum Krabbeln?", "mochte es die BL, Tagesablauf des Babys, Maxi-Kosi, Wippe, Spreizwindel", "", "radioYesNo", "" },
                    { 2, 1, "Was wurde/ wird unternommen um den Leidensdruck zu verbessern?", null, null, "textarea", "" },
                    { 3, 1, "Wie viele Kinder haben Sie entbunden?", null, null, "input", "" },
                    { 4, 1, "Welches Kind bei mehreren?", null, null, "input", "" },
                    { 5, 1, "Hatten Sie vorher Fehlgeburten? Warum?", null, null, "input", "" },
                    { 6, 1, "Wurden Sie mit ihrem Kind aufgrund von IVF (künstliche Befruchtung) schwanger?", null, null, "radioYesNo", "" },
                    { 7, 2, "Als Sie schwanger waren, hatten Sie irgendwelche medizinischen Probleme?", "hoher Blutdruck, Hyperemesis gravidarum, drohende Fehlgeburt, vorzeitige Wehen, verordnete Bettruhe, Zwischenblutungen, Eisenmangel, Erkrankungen / Infektionen, Alkohol, Drogen, Umweltgifte, Medikamente, Ernährung, Flugreise, Sauna", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo", "" },
                    { 8, 2, "Hatten Sie eine starke Virusinfektion in den ersten 13. Wochen Ihrer Schwangerschaft?", null, null, "radioYesNo, textarea", "" },
                    { 9, 2, "Standen Sie während Ihrer Schwangerschaft (besonders im 6. Monat) unter starkem emotionalen Stress?", null, null, "radioYesNo", "" },
                    { 10, 2, "Sind während der Schwangerschaft diagnostische Verfahren durchgeführt worden?", "Ultraschall, Sonografie, Röntgen, Fruchtwasseruntersuchung o.ä.", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 11, 2, "Erfolgte vor oder während der Schwangerschaft eine Hormonbehandlung", "z.B. Progesteron Gabe in der 6. Woche", "Falls ja, welche und wann:", "radioYesNo, textarea", "" },
                    { 25, 3, "Hat Ihr Kind, anstatt zunächst auf dem Bauch zu kriechen und dann auf den Händen und Knien zu krabbeln, sich auf andere Weise fortbewegt(z.B.rollend, auf dem Po rutschend, im „Bärengang“ auf Händen und Füßen)?", "(Kriechen = ab 7. - 8. Monat, homolateral die ersten 2 – 4 Wochen; Robben = ab 8. Monat, kontralateral; Krabbeln = ab 8. - 9.Monat, ab 11.Monat flüssig; Sitzen = ab 8.Monat; Stand = ab 8.Monat mit festhalten, ab 10.bis 11.Monat frei)", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 12, 2, "Wurde Ihr Kind früher (vor der 37. SSW) oder später (nach der 42. SSW) als zum errechneten Termin(+/ -2 Tage) geboren?", null, "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 14, 3, "War Ihr Kind klein bezogen auf den Geburtszeitpunkt?", "< 2500g oder > 4000 - 4300g", "Geben Sie bitte das Geburtsgewicht die Geburtslänge und den Kopfumfang an.", "radioYesNo, textarea", "" },
                    { 15, 3, "Gab es irgendwelche Besonderheiten an Ihrem Baby nach der Geburt? Brauchte es Intensivpflege? Kam es dadurch zu einer längeren Trennung? Wochenbettdepression?", "Schädelverformung, viele blaue Flecken, Nabelschnur um den Hals, deutlich blaue Verfärbung, schwere Neugeborenengelbsucht, Lanugo-Behaarung, stark mit Käseschmiere bedeckt, Gelbsucht, Fußdeformitäten, Hüftdysplasie", ":Falls ja, bitte Einzelheiten angeben: ", "radioYesNo", "" },
                    { 16, 3, "Wie waren die APGAR – Werte Ihres Kindes? (siehe Mutterpass ……/……/……) und der pH-Wert:", "", "Zusätzliche Angaben zur Schwangerschaft und Geburt (z.B. Einnahme der Pille ?) ", "textarea", "" },
                    { 17, 3, "Hatte Ihr Kind in den ersten 13 Lebenswochen Schwierigkeiten beim Saugen an der Brust, beim Trinken aus der Flasche ? Hat es viel gespuckt ? ", "Wie lange gestillt, Dauer einer Mahlzeit, Zeitabstände zwischen den Mahlzeiten, Saugbewegungen", "", "radioYesNo", "" },
                    { 18, 3, "Dauerte es auffallend lange, bis es seinen Kopf hochhalten konnte? Oder hat es den Kopf  sehr früh überstreckt gehalten?", "> 4 Monat", "", "radioYesNo", "" },
                    { 19, 3, "War Ihr Kind in den ersten 6 Lebensmonaten ein auffallend ruhiges Baby, so ruhig, dass Sie manchmal befürchteten,es sei in seinem Bettchen gestorben?", "", "", "radioYesNo", "" },
                    { 20, 3, "War Ihr Kind zwischen dem 6. und 18. Lebensmonat sehr aktiv und fordernd? Schlief es wenig und schrie es ständig?", "verstopfte Nase, Mundatmer, schnarchendes Baby, Schlafprobleme, mochte nicht liegen → Druck im Mittelohr (unreife Schluckmuster), ADHS", "", "radioYesNo", "" },
                    { 21, 3, "Als Ihr Kind alt genug war, in der Karre zu sitzen oder sich im Kinderbett zum Stand hochzuziehen, bewegte es sich dort heftig schaukelnd hin und her, so dass sich Karre oder Bett mitbewegten?", "Wie ließ es sich beruhigen? → heftiges Schaukeln, Autofahren; Stereotype Bewegungen wie im Liegen den Kopf hin und her bewegen; Schreien beim Hinlegen?", "", "radioYesNo", "" },
                    { 22, 3, "War Ihr Kind ein kleiner „Kopfstoßer“, d.h. stieß es absichtlich mit dem Kopf gegen feste Gegenstände ? Gibt es eine Vorgeschichte von Kopfverletzungen ? Wo waren die Kopfverletzungen?", "(präfrontaler Cortex – kein INPP Kind)", "", "radioYesNo", "" },
                    { 23, 3, "Hat Ihr Kind sich nicht zum richtigen Zeitpunkt (ca. ab 6. Monat) oder nur mit physiotherapeutischer Unterstützung vom Rücken auf den Bauch gedreht?", "vom Bauch auf den Rücken ab 8. Monat postnatal", "", "radioYesNo", "" },
                    { 13, 3, "War der Geburtsprozess ungewöhnlich oder besonders schwierig?", "Wehen, Geburtsdauer, Medikamente, Kaiserschnitt, Zange, Saugglocke, Sturzgeburt, Steißlage, Fruchtwasser, Kristellern, gerissen/ geschnitten", "Falls ja, bitte Einzelheiten angeben: ", "radioYesNo, textarea", "" },
                    { 51, 7, "Zusätzliche Angaben  (z.B. Ernährungsverhalten: Süßigkeiten, Fleisch, Gemüse, Milch; vorangegangene oder andauernde Behandlungen bzw.Therapien(Therapiemüdigkeit), besondere Familiensituationen, Belastungen für das Kind, Kopfschmerzen, Schlafhaltung, Erschöpfung, Hypersensitivität: Geruch / Sonne / Kuscheln / Material / Geschmack / vestibulär):", "", "", "textarea", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnamneseChapters_AnamneseId",
                table: "AnamneseChapters",
                column: "AnamneseId");

            migrationBuilder.CreateIndex(
                name: "IX_Anamnesen_PatientId",
                table: "Anamnesen",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnamneseQuestions_AnamneseChapterId",
                table: "AnamneseQuestions",
                column: "AnamneseChapterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnamneseQuestions");

            migrationBuilder.DropTable(
                name: "AnamneseChapters");

            migrationBuilder.DropTable(
                name: "Anamnesen");

            migrationBuilder.UpdateData(
                table: "Testungen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2019, 3, 22, 8, 50, 25, 17, DateTimeKind.Local));
        }
    }
}
