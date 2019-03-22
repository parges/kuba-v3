IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE TABLE [Patients] (
        [Id] int NOT NULL IDENTITY,
        [Firstname] nvarchar(max) NULL,
        [Lastname] nvarchar(max) NULL,
        [Tele] nvarchar(max) NULL,
        [Birthday] datetime2 NOT NULL,
        [Address] nvarchar(max) NULL,
        [Avatar] nvarchar(max) NULL,
        [AnamneseDate] datetime2 NULL,
        [AnamnesePayed] bit NULL,
        [DiagnostikDate] datetime2 NULL,
        [DiagnostikPayed] bit NULL,
        [ElternDate] datetime2 NULL,
        [ElternPayed] bit NULL,
        [ProblemHierarchy] nvarchar(max) NULL,
        CONSTRAINT [PK_Patients] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE TABLE [Reviews] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [Payed] bit NOT NULL,
        [Exercises] nvarchar(max) NULL,
        [Reasons] nvarchar(max) NULL,
        [PatientId] int NULL,
        CONSTRAINT [PK_Reviews] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Reviews_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE TABLE [Testungen] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Date] datetime2 NOT NULL,
        [PatientId] int NULL,
        CONSTRAINT [PK_Testungen] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Testungen_Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [Patients] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE TABLE [TestungChapters] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [TestungId] int NULL,
        CONSTRAINT [PK_TestungChapters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TestungChapters_Testungen_TestungId] FOREIGN KEY ([TestungId]) REFERENCES [Testungen] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE TABLE [TestungQuestions] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NULL,
        [Label] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        [ChapterId] int NULL,
        [TestungChapterId] int NULL,
        CONSTRAINT [PK_TestungQuestions] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TestungQuestions_TestungChapters_TestungChapterId] FOREIGN KEY ([TestungChapterId]) REFERENCES [TestungChapters] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'AnamneseDate', N'AnamnesePayed', N'Avatar', N'Birthday', N'DiagnostikDate', N'DiagnostikPayed', N'ElternDate', N'ElternPayed', N'Firstname', N'Lastname', N'ProblemHierarchy', N'Tele') AND [object_id] = OBJECT_ID(N'[Patients]'))
        SET IDENTITY_INSERT [Patients] ON;
    INSERT INTO [Patients] ([Id], [Address], [AnamneseDate], [AnamnesePayed], [Avatar], [Birthday], [DiagnostikDate], [DiagnostikPayed], [ElternDate], [ElternPayed], [Firstname], [Lastname], [ProblemHierarchy], [Tele])
    VALUES (1, NULL, NULL, NULL, NULL, '1988-08-10T00:00:00.0000000', NULL, NULL, NULL, NULL, N'Kleiner', N'Hase', NULL, N'0177123456');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'AnamneseDate', N'AnamnesePayed', N'Avatar', N'Birthday', N'DiagnostikDate', N'DiagnostikPayed', N'ElternDate', N'ElternPayed', N'Firstname', N'Lastname', N'ProblemHierarchy', N'Tele') AND [object_id] = OBJECT_ID(N'[Patients]'))
        SET IDENTITY_INSERT [Patients] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'AnamneseDate', N'AnamnesePayed', N'Avatar', N'Birthday', N'DiagnostikDate', N'DiagnostikPayed', N'ElternDate', N'ElternPayed', N'Firstname', N'Lastname', N'ProblemHierarchy', N'Tele') AND [object_id] = OBJECT_ID(N'[Patients]'))
        SET IDENTITY_INSERT [Patients] ON;
    INSERT INTO [Patients] ([Id], [Address], [AnamneseDate], [AnamnesePayed], [Avatar], [Birthday], [DiagnostikDate], [DiagnostikPayed], [ElternDate], [ElternPayed], [Firstname], [Lastname], [ProblemHierarchy], [Tele])
    VALUES (2, NULL, NULL, NULL, NULL, '1988-08-11T00:00:00.0000000', NULL, NULL, NULL, NULL, N'Stefan', N'Parge', NULL, N'0177123457');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Address', N'AnamneseDate', N'AnamnesePayed', N'Avatar', N'Birthday', N'DiagnostikDate', N'DiagnostikPayed', N'ElternDate', N'ElternPayed', N'Firstname', N'Lastname', N'ProblemHierarchy', N'Tele') AND [object_id] = OBJECT_ID(N'[Patients]'))
        SET IDENTITY_INSERT [Patients] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Exercises', N'Name', N'PatientId', N'Payed', N'Reasons') AND [object_id] = OBJECT_ID(N'[Reviews]'))
        SET IDENTITY_INSERT [Reviews] ON;
    INSERT INTO [Reviews] ([Id], [Date], [Exercises], [Name], [PatientId], [Payed], [Reasons])
    VALUES (1, '2019-03-04T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'Befundgespräch', 1, 1, N'Das war dringend notwendig'),
    (2, '2019-03-03T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'1. Review', 1, 1, N'Das war dringend notwendig'),
    (3, '2019-03-02T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'2. Review', 1, 0, N'Das war dringend notwendig'),
    (4, '2019-03-04T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'Befundgespräch', 2, 1, N'Das war dringend notwendig'),
    (5, '2019-03-03T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'1. Review', 2, 0, N'Das war dringend notwendig'),
    (6, '2019-03-02T00:00:00.0000000', N'Liegestütze und dann Kaffee trinken', N'2. Review', 2, 0, N'Das war dringend notwendig');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Exercises', N'Name', N'PatientId', N'Payed', N'Reasons') AND [object_id] = OBJECT_ID(N'[Reviews]'))
        SET IDENTITY_INSERT [Reviews] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'PatientId') AND [object_id] = OBJECT_ID(N'[Testungen]'))
        SET IDENTITY_INSERT [Testungen] ON;
    INSERT INTO [Testungen] ([Id], [Date], [Name], [PatientId])
    VALUES (1, '2019-03-18T20:33:12.7810000+01:00', N'Erste Testung', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'PatientId') AND [object_id] = OBJECT_ID(N'[Testungen]'))
        SET IDENTITY_INSERT [Testungen] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE INDEX [IX_Reviews_PatientId] ON [Reviews] ([PatientId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE INDEX [IX_TestungChapters_TestungId] ON [TestungChapters] ([TestungId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Testungen_PatientId] ON [Testungen] ([PatientId]) WHERE [PatientId] IS NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    CREATE INDEX [IX_TestungQuestions_TestungChapterId] ON [TestungQuestions] ([TestungChapterId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318193312_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318193312_Initial', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195552_addTestungData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TestungId') AND [object_id] = OBJECT_ID(N'[TestungChapters]'))
        SET IDENTITY_INSERT [TestungChapters] ON;
    INSERT INTO [TestungChapters] ([Id], [Name], [TestungId])
    VALUES (1, N'I. TESTS ZUR ÜBERPRÜFUNG DER GROBMOTORISCHEN KOORDINAION UND DES GLEICHGEWICHTS', 1),
    (2, N'II. TESTS ZUR MOTORISCHEN ENTWICKLUNG', 1),
    (3, N'III. TESTS ZUR ÜBERPRÜFUNG VON KLEINHIRNFUNKTIONEN', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TestungId') AND [object_id] = OBJECT_ID(N'[TestungChapters]'))
        SET IDENTITY_INSERT [TestungChapters] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195552_addTestungData')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-18T20:55:52.5680000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195552_addTestungData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318195552_addTestungData', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195711_addTestungData2')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChapterId', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] ON;
    INSERT INTO [TestungQuestions] ([Id], [ChapterId], [Label], [TestungChapterId], [Type], [Value])
    VALUES (1, 1, N'Aufrichten aus Rückenlage in den Stand', NULL, N'radio', N''),
    (2, 1, N'Aufrichten aus Bauchlage in den Stand', NULL, N'radio', N''),
    (3, 1, N'Romberg Test (Augen geöffnet)', NULL, N'radio', N''),
    (4, 1, N'Tandem Gang (rückwärts)', NULL, N'radio', N'');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ChapterId', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195711_addTestungData2')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-18T20:57:11.7830000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318195711_addTestungData2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318195711_addTestungData2', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[TestungQuestions]') AND [c].[name] = N'ChapterId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [TestungQuestions] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [TestungQuestions] DROP COLUMN [ChapterId];
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    UPDATE [TestungQuestions] SET [TestungChapterId] = 1
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    UPDATE [TestungQuestions] SET [TestungChapterId] = 1
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    UPDATE [TestungQuestions] SET [TestungChapterId] = 1
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    UPDATE [TestungQuestions] SET [TestungChapterId] = 1
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-18T21:02:30.4130000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190318200230_addTestungData3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190318200230_addTestungData3', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TestungId') AND [object_id] = OBJECT_ID(N'[TestungChapters]'))
        SET IDENTITY_INSERT [TestungChapters] ON;
    INSERT INTO [TestungChapters] ([Id], [Name], [TestungId])
    VALUES (4, N'IV. TESTS ZUR DYSDIADOCHOKINESE', 1),
    (5, N'V. LINKS-RECHTS-DISKRIMINIERUNGSPROBLEME', 1),
    (6, N'VI. ORIENTIERUNGSPROBLEME', 1),
    (7, N'VII. RÄUMLICHE WAHRNEHMUNGSPROBLEME', 1),
    (8, N'VIII. TESTS ZU ABERRANTEN REFLEXEN', 1),
    (9, N'IX. TESTS ZUR SEITIGKEITSÜBERPRÜFUNG', 1),
    (10, N'X. ÜBERPRÜFUNG DER AUGENMUSKELMOTORIK', 1),
    (11, N'XI. VISUELLE WAHRNEHMUNGSÜBERPRÜFUNG', 1),
    (12, N'ZUSÄTZLICHE BEOBACHTUNGEN UND NOTIZEN', 1),
    (13, N'ERGEBNISZUSAMMENFASSUNG', 1);
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TestungId') AND [object_id] = OBJECT_ID(N'[TestungChapters]'))
        SET IDENTITY_INSERT [TestungChapters] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    UPDATE [TestungQuestions] SET [Label] = N'Romberg Test (Augen geschlossen)'
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] ON;
    INSERT INTO [TestungQuestions] ([Id], [Label], [TestungChapterId], [Type], [Value])
    VALUES (18, N'Hüpfen auf einem Bein (links oder rechts)', 1, N'radio', N''),
    (19, N'Hopserlauf', 1, N'radio', N''),
    (20, N'Windmühle', 1, N'radio', N''),
    (21, N'Kriechen auf dem Bauch', 2, N'radio', N''),
    (22, N'Krabbeln auf Händen und Knien', 2, N'radio', N''),
    (10, N'Zehenspitzengang (rückwärts)', 1, N'radio', N''),
    (24, N'Ferse auf Schienbein (rechte Ferse auf linkes Schienbein)', 3, N'radio', N''),
    (25, N'Zeigefinger-Annäherung (Augen offen)', 3, N'radio', N''),
    (26, N'Zeigefinger-Annäherung (Augen geschlossen)', 3, N'radio', N''),
    (17, N'Fersengang (nur vorwärts)', 1, N'radio', N''),
    (23, N'Ferse auf Schienbein (linke Ferse auf rechtes Schienbein)', 3, N'radio', N''),
    (16, N'Slalom Gang (rückwärts)', 1, N'radio', N''),
    (28, N'Finger an die Nase (Augen geschlossen)', 3, N'radio', N''),
    (14, N'Fog Walk (rückwärts)', 1, N'radio', N''),
    (13, N'Fog Walk (vorwärts)', 1, N'radio', N''),
    (12, N'Tandem Gang (rückwärts)', 1, N'radio', N''),
    (11, N'Tandem Gang (vorwärts)', 1, N'radio', N''),
    (27, N'Finger an die Nase (Augen offen)', 3, N'radio', N''),
    (9, N'Zehenspitzengang (vorwärts) 0 1', 1, N'radio', N''),
    (8, N'Marschieren und Umdrehen', 1, N'radio', N''),
    (7, N'Einbeinstand', 1, N'radio', N''),
    (6, N'Mann Test (Augen geschlossen)', 1, N'radio', N''),
    (5, N'Mann Test (Augen geöffnet)', 1, N'radio', N''),
    (15, N'Slalom Gang (vorwärts)', 1, N'radio', N'');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-21T14:56:59.7340000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] ON;
    INSERT INTO [TestungQuestions] ([Id], [Label], [TestungChapterId], [Type], [Value])
    VALUES (29, N'Finger (linke Hand)', 4, N'radio', N''),
    (117, N'Schwierigkeit, die Augen unabhängig voneinander zu schließen - rechtes Auge', 10, N'radio', N''),
    (116, N'Schwierigkeit, die Augen unabhängig voneinander zu schließen - linkes Auge', 10, N'radio', N''),
    (115, N'Konvergenzschwierigkeiten - rechtes Auge', 10, N'radio', N''),
    (114, N'Konvergenzschwierigkeiten - linkes Auge', 10, N'radio', N''),
    (113, N'Latente Divergenz - rechts', 10, N'radio', N''),
    (112, N'Latente Divergenz - links', 10, N'radio', N''),
    (111, N'Latente Konvergenz - rechts', 10, N'radio', N''),
    (110, N'Latente Konvergenz - links', 10, N'radio', N''),
    (109, N'Augenzittern (Nystagmus)', 10, N'radio', N''),
    (108, N'Verfolgen der Hand mit den Augen (eye-hand-tracking)', 10, N'radio', N''),
    (107, N'Beeinträchtigte Folgebewegungen (tracking-vertikal)', 10, N'radio', N''),
    (106, N'Beeinträchtigte Folgebewegungen (tracking- horizontal)', 10, N'radio', N''),
    (118, N'Beeinträchtigung synchroner Augenbewegungen - linkes Auge', 10, N'radio', N''),
    (105, N'Fixierungsschwierigkeiten', 10, N'radio', N''),
    (103, N'Ohrdominanz - Lauschen', 9, N'radio', N''),
    (102, N'Ohrdominanz - Muschel', 9, N'radio', N''),
    (101, N'Augendominanz (Nähe) - Ring', 9, N'radio', N''),
    (100, N'Augendominanz (Nähe) - Lochkarte', 9, N'radio', N''),
    (99, N'Augendominanz (Entfernung) - Ring', 9, N'radio', N''),
    (98, N'Augendominanz (Entfernung) - Teleskop', 9, N'radio', N''),
    (97, N'Handdominanz - Teleskop', 9, N'radio', N''),
    (96, N'Handdominanz - Schreibhand', 9, N'radio', N''),
    (95, N'Handdominanz - Klatschen in eine Hand', 9, N'radio', N''),
    (94, N'Handdominanz - Einen Ball fangen', 9, N'radio', N''),
    (93, N'Fußdominanz - Auf einem Bein hüpfen', 9, N'radio', N''),
    (92, N'Fußdominanz - Auf einen Stuhl steigen', 9, N'radio', N''),
    (104, N'Ohrdominanz - Rufen (Hinweis auf Hemisphärendominanz)', 9, N'radio', N''),
    (119, N'Beeinträchtigung synchroner Augenbewegungen - rechtes Auge', 10, N'radio', N''),
    (120, N'Erweiterte periphere Sicht - linkes Auge', 10, N'radio', N''),
    (121, N'Erweiterte periphere Sicht - rechtes Auge', 10, N'radio', N''),
    (148, N'Aberrante Reflexe', 13, N'textarea', N''),
    (147, N'Dysdiadochokinese', 13, N'textarea', N''),
    (146, N'Kleinhirnfunktionen', 13, N'textarea', N''),
    (145, N'Grobmotorische Koordination und Gleichgewicht', 13, N'textarea', N''),
    (144, N'Index der Dysfunktion', 13, N'input', N''),
    (143, N'Kind ist ängstlich und besorgt und mit seinen Ergebnissen nicht zufrieden', 12, N'textarea', N''),
    (142, N'Schnelle Ermüdbarkeit', 12, N'textarea', N''),
    (141, N'Sitzposition', 12, N'textarea', N''),
    (140, N'Stiftgriff', 12, N'textarea', N''),
    (139, N'Mann-Zeichnen-Test Test (Aston Index) - Chronologisches Alter', 11, N'input', N''),
    (138, N'Mann-Zeichnen-Test Test (Aston Index) - Entwicklungsalter', 11, N'input', N''),
    (137, N'Abschreiben eines kurzen Textes', 11, N'input', N''),
    (136, N'Hinweis auf ‘Stimulusgebundenheit’', 11, N'radio', N''),
    (135, N'Räumliche Probleme - Bender Visual Gestalt Figuren', 11, N'radio', N''),
    (134, N'Räumliche Probleme - Daniels und Diack Figuren', 11, N'radio', N''),
    (133, N'Räumliche Probleme - Tansley Standard Figuren', 11, N'radio', N''),
    (132, N'Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Bender Visual Gestalt Figuren', 11, N'radio', N''),
    (131, N'Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Daniels und Diack Figuren', 11, N'radio', N''),
    (130, N'Visuo-motorische Integrationsschwierigkeit (Auge-Hand-Koordination) - Tansley Standard Figuren', 11, N'radio', N''),
    (129, N'Visuelle Unterscheidungsprobleme - Bender Visual Gestalt Figuren', 11, N'radio', N''),
    (128, N'Visuelle Unterscheidungsprobleme - Daniels und Diack Figuren', 11, N'radio', N''),
    (127, N'Visuelle Unterscheidungsprobleme - Tansley Standard Figuren', 11, N'radio', N''),
    (126, N'Pupillenreaktion auf Licht (optional) - rechtes Auge', 10, N'input', N''),
    (125, N'Pupillenreaktion auf Licht (optional) - linkes Auge', 10, N'input', N''),
    (124, N'Pupillenreaktion auf Licht (optional) - rechtes Auge', 10, N'input', N''),
    (123, N'Pupillenreaktion auf Licht (optional) - linkes Auge', 10, N'input', N''),
    (122, N'Akkommodationsfähigkeit', 10, N'radio', N''),
    (91, N'Fußdominanz - Aufstampfen mit einem Fuß', 9, N'radio', N''),
    (90, N'Fußdominanz - Ball schießen', 9, N'radio', N''),
    (89, N'Landau-Reaktion', 8, N'radio', N''),
    (88, N'Plantar-Reflex - rechter Fuß', 8, N'radio', N''),
    (56, N'TLR - Aufrechttest - Beugung', 8, N'radio', N''),
    (55, N'TLR - Standard Test', 8, N'radio', N''),
    (54, N'Spinaler Galant-Reflex - rechte Seite', 8, N'radio', N''),
    (53, N'Spinaler Galant-Reflex - linke Seite', 8, N'radio', N''),
    (52, N'STNR - Krabbeltest', 8, N'radio', N''),
    (51, N'STNR - Arme', 8, N'radio', N''),
    (50, N'STNR - Füße oder Rumpf', 8, N'radio', N''),
    (49, N'TTNR - von links nach rechts', 8, N'radio', N''),
    (48, N'TTNR - von rechts nach links', 8, N'radio', N''),
    (47, N'Schilder Test - rechter Arm', 8, N'radio', N''),
    (46, N'Schilder Test - linker Arm', 8, N'radio', N''),
    (45, N'Ayres Test Nr. 2 - rechter Arm', 8, N'radio', N''),
    (44, N'Ayres Test Nr. 2 - linker Arm', 8, N'radio', N''),
    (43, N'Ayres Test Nr. 1 - rechter Arm', 8, N'radio', N''),
    (42, N'Ayres Test Nr. 1 - linker Arm', 8, N'radio', N''),
    (41, N'Standard Test - rechtes Bein', 8, N'radio', N''),
    (40, N'Standard Test - rechter Arm', 8, N'radio', N''),
    (39, N'Standard Test - linkes Bein', 8, N'radio', N''),
    (38, N'Standard Test - linker Arm', 8, N'radio', N''),
    (37, N'Räumliche Wahrnehmungsprobleme', 7, N'radio', N''),
    (36, N'Orientierungsprobleme', 6, N'radio', N''),
    (35, N'Links-Rechts-Diskriminierungsprobleme', 5, N'radio', N''),
    (34, N'Fuß (rechts)', 4, N'radio', N''),
    (33, N'Fuß (links)', 4, N'radio', N''),
    (32, N'Hand (rechts)', 4, N'radio', N''),
    (31, N'Hand (links)', 4, N'radio', N''),
    (30, N'Finger (rechte Hand)', 4, N'radio', N''),
    (57, N'TLR - Aufrechttest – Streckung', 8, N'radio', N''),
    (149, N'Okulomotorische Funktionen', 13, N'textarea', N''),
    (58, N'Moro Reflex / FPR - Standard Test', 8, N'radio', N''),
    (60, N'Moro Reflex / FPR - Aufrecht: ZT', 8, N'radio', N''),
    (87, N'Plantar-Reflex - linker Fuß', 8, N'radio', N''),
    (86, N'Palmar-Reflex - rechte Hand', 8, N'radio', N''),
    (85, N'Palmar-Reflex - linke Hand', 8, N'radio', N''),
    (84, N'Erwachsener Saug-Reflex', 8, N'radio', N''),
    (83, N'Saug-Reflex', 8, N'radio', N''),
    (82, N'Such-Reflex - rechts', 8, N'radio', N''),
    (81, N'Such-Reflex - links', 8, N'radio', N''),
    (80, N'Abdominal Reflex (optional)', 8, N'radio', N''),
    (79, N'Babinski Reflex - rechter Fuß', 8, N'radio', N''),
    (78, N'Babinski Reflex - linker Fuß', 8, N'radio', N''),
    (77, N'Segmentäre Rollreaktion- von den Hüften (rechts)', 8, N'radio', N''),
    (76, N'Segmentäre Rollreaktion- von den Hüften (links)', 8, N'radio', N''),
    (75, N'Segmentäre Rollreaktion- von den Schultern (rechts)', 8, N'radio', N''),
    (74, N'Segmentäre Rollreaktion- von den Schultern (links)', 8, N'radio', N''),
    (73, N'Amphibien Reaktion - rechte Seite (Bauchlage)', 8, N'radio', N''),
    (72, N'Amphibien Reaktion - linke Seite (Bauchlage)', 8, N'radio', N''),
    (71, N'Amphibien Reaktion - rechte Seite (Rückenlage)', 8, N'radio', N''),
    (70, N'Amphibien Reaktion - linke Seite (Rückenlage)', 8, N'radio', N''),
    (69, N'Labyrinthkopfstellreaktionen - vorwärts', 8, N'radio', N''),
    (68, N'Labyrinthkopfstellreaktionen - rückwärts', 8, N'radio', N''),
    (67, N'Labyrinthkopfstellreaktionen - nach rechts', 8, N'radio', N''),
    (66, N'Labyrinthkopfstellreaktionen - nach links', 8, N'radio', N''),
    (65, N'Augenkopfstellreaktionen - rückwärts', 8, N'radio', N''),
    (64, N'Augenkopfstellreaktionen - vorwärts', 8, N'radio', N''),
    (63, N'Augenkopfstellreaktionen - nach rechts', 8, N'radio', N''),
    (62, N'Augenkopfstellreaktionen - nach links', 8, N'radio', N''),
    (61, N'Moro Reflex / FPR - Aufrecht: FF', 8, N'radio', N''),
    (59, N'Moro Reflex / FPR - Aufrecht: TT', 8, N'radio', N''),
    (150, N'Visuelle Wahrnehmungsfunktionen', 13, N'textarea', N'');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Label', N'TestungChapterId', N'Type', N'Value') AND [object_id] = OBJECT_ID(N'[TestungQuestions]'))
        SET IDENTITY_INSERT [TestungQuestions] OFF;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321135659_fullyData')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190321135659_fullyData', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radio2'
    WHERE [Id] = 21;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radio3'
    WHERE [Id] = 22;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioYesNo'
    WHERE [Id] = 35;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioYesNo'
    WHERE [Id] = 36;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioYesNo'
    WHERE [Id] = 37;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radio4'
    WHERE [Id] = 84;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 90;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 91;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 92;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 93;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 94;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 95;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 96;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 97;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 98;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 99;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 100;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 101;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 102;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 103;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [TestungQuestions] SET [Type] = N'radioLeftRight'
    WHERE [Id] = 104;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-21T15:28:31.7260000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190321142831_fullyData2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190321142831_fullyData2', N'2.1.4-rtm-31024');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190322075025_ScoreAdded')
BEGIN
    ALTER TABLE [TestungChapters] ADD [Score] int NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190322075025_ScoreAdded')
BEGIN
    UPDATE [Testungen] SET [Date] = '2019-03-22T08:50:25.0170000+01:00'
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT;

END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20190322075025_ScoreAdded')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20190322075025_ScoreAdded', N'2.1.4-rtm-31024');
END;

GO

