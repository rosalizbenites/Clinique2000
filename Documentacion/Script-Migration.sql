USE [E03]

GO
IF OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [dbo].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [Nom] nvarchar(100) NOT NULL,
    [Prenom] nvarchar(100) NOT NULL,
    [NumeroAssuranceMaladie] nvarchar(12) NULL,
    [Telephone] nvarchar(max) NOT NULL,
    [DateDeNaissance] datetime2 NULL,
    [CodePostal] nvarchar(7) NULL,
    [Adresse] nvarchar(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [dbo].[AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[Cliniques] (
    [Id] int NOT NULL IDENTITY,
    [Nom] nvarchar(max) NOT NULL,
    [Adresse] nvarchar(max) NOT NULL,
    [CodePostal] nvarchar(7) NOT NULL,
    [Telephone] nvarchar(max) NOT NULL,
    [Courriel] nvarchar(max) NOT NULL,
    [HeureOuverture] datetime2 NULL,
    [NombreMaximumPatients] int NOT NULL,
    [DureeParConsultation] int NOT NULL,
    [Latitude] float NOT NULL,
    [Longitude] float NOT NULL,
    [CliniqueAdminId] nvarchar(450) NULL,
    CONSTRAINT [PK_Cliniques] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliniques_AspNetUsers_CliniqueAdminId] FOREIGN KEY ([CliniqueAdminId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);
GO

CREATE TABLE [dbo].[FilesDAttente] (
    [Id] int NOT NULL IDENTITY,
    [EstFermeeManuellement] bit NOT NULL,
    [DateHeureInscriptions] datetime2 NOT NULL,
    [DateHeureOuverture] datetime2 NOT NULL,
    [DateHeureFermeture] datetime2 NOT NULL,
    [NombreMedecins] int NOT NULL,
    [CliniqueId] int NOT NULL,
    CONSTRAINT [PK_FilesDAttente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_FilesDAttente_Cliniques_CliniqueId] FOREIGN KEY ([CliniqueId]) REFERENCES [dbo].[Cliniques] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [dbo].[PlagesHoraires] (
    [Id] int NOT NULL IDENTITY,
    [EstReservee] bit NOT NULL,
    [NumeroMedecin] int NOT NULL,
    [Debut] time NOT NULL,
    [DebutReel] time NULL,
    [FinReelle] time NULL,
    [FileDAttenteId] int NOT NULL,
    [PatientId] nvarchar(450) NULL,
    [MedecinId] nvarchar(450) NULL,
    CONSTRAINT [PK_PlagesHoraires] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PlagesHoraires_AspNetUsers_MedecinId] FOREIGN KEY ([MedecinId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_PlagesHoraires_AspNetUsers_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_PlagesHoraires_FilesDAttente_FileDAttenteId] FOREIGN KEY ([FileDAttenteId]) REFERENCES [dbo].[FilesDAttente] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adresse', N'CliniqueAdminId', N'CodePostal', N'Courriel', N'DureeParConsultation', N'HeureOuverture', N'Latitude', N'Longitude', N'Nom', N'NombreMaximumPatients', N'Telephone') AND [object_id] = OBJECT_ID(N'[dbo].[Cliniques]'))
    SET IDENTITY_INSERT [dbo].[Cliniques] ON;
INSERT INTO [dbo].[Cliniques] ([Id], [Adresse], [CliniqueAdminId], [CodePostal], [Courriel], [DureeParConsultation], [HeureOuverture], [Latitude], [Longitude], [Nom], [NombreMaximumPatients], [Telephone])
VALUES (1, N'945 Chemin de Chambly, Longueuil, QC J4H 3M6', NULL, N'J4H 3M6', N'clinique@clinique2000.com', 30, NULL, 45.535578999999998E0, -73.495116999999993E0, N'Clinique de la Santé', 30, N'1234567890'),
(2, N'1101 Boulevard Brassard #205, Chambly, QC J3L 5R4', NULL, N'J3L 5R4', N'clinique@clinique2000.com', 20, NULL, 45.44332E0, -73.302384500000002E0, N'Clinique du Fort Chambly', 30, N'1234567890'),
(3, N'6800 Boulevard Cousineau, Saint-Hubert, QC J3Y 8Z4', NULL, N'J3Y 8Z4', N'clinique@clinique2000.com', 20, NULL, 45.492618999999998E0, -73.403113000000005E0, N'CLSC Saint-Hubert', 30, N'1234567890'),
(4, N'2984 Boulevard Taschereau #103, Greenfield Park, QC J4V 2G9', NULL, N'J4V 2G9', N'clinique@clinique2000.com', 20, NULL, 45.497723000000001E0, -73.483849000000006E0, N'Clinique Azur', 30, N'1234567890'),
(5, N'299 Boulevard Sir-Wilfrid-Laurier #100A, Saint-Lambert, QC J4R 2L1', NULL, N'J4R 2L1', N'clinique@clinique2000.com', 20, NULL, 45.494031999999997E0, -73.505786999999998E0, N'Clinique médicale Carré Saint-Lambert', 30, N'1234567890'),
(6, N'5645 Grande Allée #50, Brossard, QC J4Z 3G3', NULL, N'J4Z 3G3', N'clinique@clinique2000.com', 20, NULL, 45.474260000000001E0, -73.443476000000004E0, N'Centre Medical Bethanie', 30, N'1234567890');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adresse', N'CliniqueAdminId', N'CodePostal', N'Courriel', N'DureeParConsultation', N'HeureOuverture', N'Latitude', N'Longitude', N'Nom', N'NombreMaximumPatients', N'Telephone') AND [object_id] = OBJECT_ID(N'[dbo].[Cliniques]'))
    SET IDENTITY_INSERT [dbo].[Cliniques] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (1, 1, '2024-01-31T23:00:00.0000000', '2024-01-30T20:00:00.0000000', '2024-01-31T08:00:00.0000000', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (2, 1, '2024-02-02T02:11:33.0902094-05:00', '2024-02-01T18:11:33.0902051-05:00', '2024-02-01T21:11:33.0902092-05:00', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (3, 1, '2024-02-02T21:11:33.0902099-05:00', '2024-02-02T18:11:33.0902096-05:00', '2024-02-02T21:11:33.0902098-05:00', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Debut', N'DebutReel', N'EstReservee', N'FileDAttenteId', N'FinReelle', N'MedecinId', N'NumeroMedecin', N'PatientId') AND [object_id] = OBJECT_ID(N'[PlagesHoraires]'))
    SET IDENTITY_INSERT [dbo].[PlagesHoraires] ON;
INSERT INTO [dbo].[PlagesHoraires] ([Id], [Debut], [DebutReel], [EstReservee], [FileDAttenteId], [FinReelle], [MedecinId], [NumeroMedecin], [PatientId])
VALUES (1, '09:00:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(2, '09:30:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(3, '10:00:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(4, '10:30:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(5, '11:00:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(6, '11:30:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(7, '12:00:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL),
(8, '12:30:00', NULL, CAST(1 AS bit), 1, NULL, NULL, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Debut', N'DebutReel', N'EstReservee', N'FileDAttenteId', N'FinReelle', N'MedecinId', N'NumeroMedecin', N'PatientId') AND [object_id] = OBJECT_ID(N'[PlagesHoraires]'))
    SET IDENTITY_INSERT [dbo].[PlagesHoraires] OFF;
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [dbo].[AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [dbo].[AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [dbo].[AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Cliniques_CliniqueAdminId] ON [dbo].[Cliniques] ([CliniqueAdminId]);
GO

CREATE INDEX [IX_FilesDAttente_CliniqueId] ON [dbo].[FilesDAttente] ([CliniqueId]);
GO

CREATE INDEX [IX_PlagesHoraires_FileDAttenteId] ON [dbo].[PlagesHoraires] ([FileDAttenteId]);
GO

CREATE INDEX [IX_PlagesHoraires_MedecinId] ON [dbo].[PlagesHoraires] ([MedecinId]);
GO

CREATE INDEX [IX_PlagesHoraires_PatientId] ON [dbo].[PlagesHoraires] ([PatientId]);
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240202021133_Reinitialisation', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T02:48:48.2354434-05:00', [DateHeureInscriptions] = '2024-02-01T18:48:48.2354390-05:00', [DateHeureOuverture] = '2024-02-01T21:48:48.2354432-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T21:48:48.2354439-05:00', [DateHeureInscriptions] = '2024-02-02T18:48:48.2354436-05:00', [DateHeureOuverture] = '2024-02-02T21:48:48.2354437-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [EstReservee] = CAST(0 AS bit)
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240202024848_ModPlageHoraireEstReserveeFalse', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T02:59:58.8829562-05:00', [DateHeureInscriptions] = '2024-02-01T18:59:58.8829526-05:00', [DateHeureOuverture] = '2024-02-01T21:59:58.8829561-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T21:59:58.8829568-05:00', [DateHeureInscriptions] = '2024-02-02T18:59:58.8829565-05:00', [DateHeureOuverture] = '2024-02-02T21:59:58.8829567-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240202025959_ModPlageHorairesFileDAttenteId', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [dbo].[Cliniques] ADD [HeureFermeture] datetime2 NULL;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T03:44:03.2020296-05:00', [DateHeureInscriptions] = '2024-02-01T19:44:03.2020259-05:00', [DateHeureOuverture] = '2024-02-01T22:44:03.2020294-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T22:44:03.2020303-05:00', [DateHeureInscriptions] = '2024-02-02T19:44:03.2020300-05:00', [DateHeureOuverture] = '2024-02-02T22:44:03.2020301-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240202034403_HeureFermeture', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T03:45:25.4207903-05:00', [DateHeureInscriptions] = '2024-02-01T19:45:25.4207861-05:00', [DateHeureOuverture] = '2024-02-01T22:45:25.4207901-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-02T22:45:25.4207909-05:00', [DateHeureInscriptions] = '2024-02-02T19:45:25.4207905-05:00', [DateHeureOuverture] = '2024-02-02T22:45:25.4207907-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240202034525_roleMedecin', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-05T23:43:42.9965412-05:00', [DateHeureInscriptions] = '2024-02-05T15:43:42.9965376-05:00', [DateHeureOuverture] = '2024-02-05T18:43:42.9965411-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T18:43:42.9965417-05:00', [DateHeureInscriptions] = '2024-02-06T15:43:42.9965414-05:00', [DateHeureOuverture] = '2024-02-06T18:43:42.9965416-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240205234343_MAJFileDattenteDateTime', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [Telephone] = N'(123) 456-7890'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T00:22:55.9468932-05:00', [DateHeureInscriptions] = '2024-02-05T16:22:55.9468895-05:00', [DateHeureOuverture] = '2024-02-05T19:22:55.9468930-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T19:22:55.9468936-05:00', [DateHeureInscriptions] = '2024-02-06T16:22:55.9468934-05:00', [DateHeureOuverture] = '2024-02-06T19:22:55.9468935-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206002256_TelephonesCliniques', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Cliniques]') AND [c].[name] = N'HeureFermeture');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Cliniques] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [dbo].[Cliniques] DROP COLUMN [HeureFermeture];
GO

ALTER TABLE [dbo].[AspNetUsers] ADD [CliniqueId] int NULL;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T00:24:58.9183833-05:00', [DateHeureInscriptions] = '2024-02-05T16:24:58.9183798-05:00', [DateHeureOuverture] = '2024-02-05T19:24:58.9183831-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T19:24:58.9183837-05:00', [DateHeureInscriptions] = '2024-02-06T16:24:58.9183834-05:00', [DateHeureOuverture] = '2024-02-06T19:24:58.9183836-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[PlagesHoraires] SET [FileDAttenteId] = 2
WHERE [Id] = 8;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206002459_ModificationUser', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T00:58:54.8157808-05:00', [DateHeureInscriptions] = '2024-02-05T16:58:54.8157771-05:00', [DateHeureOuverture] = '2024-02-05T19:58:54.8157806-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T19:58:54.8157813-05:00', [DateHeureInscriptions] = '2024-02-06T16:58:54.8157810-05:00', [DateHeureOuverture] = '2024-02-06T19:58:54.8157811-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206005855_ModDatesFilesDAttente', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-06T23:41:50.9671678-05:00', [DateHeureInscriptions] = '2024-02-06T15:41:50.9671640-05:00', [DateHeureOuverture] = '2024-02-06T18:41:50.9671676-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T18:41:50.9671683-05:00', [DateHeureInscriptions] = '2024-02-07T15:41:50.9671680-05:00', [DateHeureOuverture] = '2024-02-07T18:41:50.9671681-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240206234151_MAJ2FilesDattenteDateTime', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T01:18:50.4757519-05:00', [DateHeureInscriptions] = '2024-02-06T17:18:50.4757478-05:00', [DateHeureOuverture] = '2024-02-06T20:18:50.4757517-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T20:18:50.4757524-05:00', [DateHeureInscriptions] = '2024-02-07T17:18:50.4757521-05:00', [DateHeureOuverture] = '2024-02-07T20:18:50.4757523-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240207011850_ModDatesFiles', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adresse', N'CliniqueAdminId', N'CodePostal', N'Courriel', N'DureeParConsultation', N'HeureOuverture', N'Latitude', N'Longitude', N'Nom', N'NombreMaximumPatients', N'Telephone') AND [object_id] = OBJECT_ID(N'[dbo].[Cliniques]'))
    SET IDENTITY_INSERT [dbo].[Cliniques] ON;
INSERT INTO [dbo].[Cliniques] ([Id], [Adresse], [CliniqueAdminId], [CodePostal], [Courriel], [DureeParConsultation], [HeureOuverture], [Latitude], [Longitude], [Nom], [NombreMaximumPatients], [Telephone])
VALUES (7, N'945 Chemin de Chambly, Longueuil, QC J4H 3M7', NULL, N'J4H 3M7', N'clinique2@clinique2000.com', 30, NULL, 45.535578999999998E0, -73.495116999999993E0, N'Clinique de la Santé 2', 30, N'1234567891');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Adresse', N'CliniqueAdminId', N'CodePostal', N'Courriel', N'DureeParConsultation', N'HeureOuverture', N'Latitude', N'Longitude', N'Nom', N'NombreMaximumPatients', N'Telephone') AND [object_id] = OBJECT_ID(N'[dbo].[Cliniques]'))
    SET IDENTITY_INSERT [dbo].[Cliniques] OFF;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T02:44:57.9305001-05:00', [DateHeureInscriptions] = '2024-02-06T18:44:57.9304958-05:00', [DateHeureOuverture] = '2024-02-06T21:44:57.9304999-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T21:44:57.9305006-05:00', [DateHeureInscriptions] = '2024-02-07T18:44:57.9305002-05:00', [DateHeureOuverture] = '2024-02-07T21:44:57.9305004-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (4, 7, '2024-01-31T23:00:00.0000000', '2024-01-30T20:00:00.0000000', '2024-01-31T08:00:00.0000000', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (5, 7, '2024-02-07T02:44:57.9305014-05:00', '2024-02-06T18:44:57.9305011-05:00', '2024-02-06T21:44:57.9305013-05:00', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] ON;
INSERT INTO [dbo].[FilesDAttente] ([Id], [CliniqueId], [DateHeureFermeture], [DateHeureInscriptions], [DateHeureOuverture], [EstFermeeManuellement], [NombreMedecins])
VALUES (6, 7, '2024-02-07T21:44:57.9305018-05:00', '2024-02-07T18:44:57.9305015-05:00', '2024-02-07T21:44:57.9305017-05:00', CAST(0 AS bit), 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CliniqueId', N'DateHeureFermeture', N'DateHeureInscriptions', N'DateHeureOuverture', N'EstFermeeManuellement', N'NombreMedecins') AND [object_id] = OBJECT_ID(N'[dbo].[FilesDAttente]'))
    SET IDENTITY_INSERT [dbo].[FilesDAttente] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Debut', N'DebutReel', N'EstReservee', N'FileDAttenteId', N'FinReelle', N'MedecinId', N'NumeroMedecin', N'PatientId') AND [object_id] = OBJECT_ID(N'[PlagesHoraires]'))
    SET IDENTITY_INSERT [dbo].[PlagesHoraires] ON;
INSERT INTO [dbo].[PlagesHoraires] ([Id], [Debut], [DebutReel], [EstReservee], [FileDAttenteId], [FinReelle], [MedecinId], [NumeroMedecin], [PatientId])
VALUES (9, '09:00:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(10, '09:30:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(11, '10:00:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(12, '10:30:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(13, '11:00:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(14, '11:30:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL),
(15, '12:00:00', NULL, CAST(0 AS bit), 5, NULL, NULL, 0, NULL),
(16, '12:30:00', NULL, CAST(1 AS bit), 5, NULL, NULL, 0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Debut', N'DebutReel', N'EstReservee', N'FileDAttenteId', N'FinReelle', N'MedecinId', N'NumeroMedecin', N'PatientId') AND [object_id] = OBJECT_ID(N'[PlagesHoraires]'))
    SET IDENTITY_INSERT [dbo].[PlagesHoraires] OFF;
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240207024458_AjoutCliniqueFilesPlages', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T22:15:04.8887690-05:00', [DateHeureInscriptions] = '2024-02-07T14:15:04.8887641-05:00', [DateHeureOuverture] = '2024-02-07T17:15:04.8887688-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-08T17:15:04.8887696-05:00', [DateHeureInscriptions] = '2024-02-08T14:15:04.8887692-05:00', [DateHeureOuverture] = '2024-02-08T17:15:04.8887694-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-07T22:15:04.8887703-05:00', [DateHeureInscriptions] = '2024-02-07T14:15:04.8887699-05:00', [DateHeureOuverture] = '2024-02-07T17:15:04.8887701-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-08T17:15:04.8887708-05:00', [DateHeureInscriptions] = '2024-02-08T14:15:04.8887705-05:00', [DateHeureOuverture] = '2024-02-08T17:15:04.8887707-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240207221505_ModDatesFiles2', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[Cliniques] SET [Adresse] = N'217 Rue Saint-Charles O, Longueuil, QC J4H 1E1', [CodePostal] = N'J4H 1E1', [Latitude] = 45.538029000000002E0, [Longitude] = -73.510469000000001E0, [Nom] = N'Clinique médicale L''Gros Luxe'
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-08T20:41:26.4703981-05:00', [DateHeureInscriptions] = '2024-02-08T12:41:26.4703944-05:00', [DateHeureOuverture] = '2024-02-08T15:41:26.4703979-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T15:41:26.4703987-05:00', [DateHeureInscriptions] = '2024-02-09T12:41:26.4703983-05:00', [DateHeureOuverture] = '2024-02-09T15:41:26.4703985-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-08T20:41:26.4703993-05:00', [DateHeureInscriptions] = '2024-02-08T12:41:26.4703990-05:00', [DateHeureOuverture] = '2024-02-08T15:41:26.4703992-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T15:41:26.4703999-05:00', [DateHeureInscriptions] = '2024-02-09T12:41:26.4703996-05:00', [DateHeureOuverture] = '2024-02-09T15:41:26.4703997-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240208204126_ModSeedCliniques', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [dbo].[Cliniques] ADD [HeureFermeture] datetime2 NULL;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T01:02:08.2977125-05:00', [DateHeureInscriptions] = '2024-02-08T17:02:08.2977079-05:00', [DateHeureOuverture] = '2024-02-08T20:02:08.2977123-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T20:02:08.2977130-05:00', [DateHeureInscriptions] = '2024-02-09T17:02:08.2977127-05:00', [DateHeureOuverture] = '2024-02-09T20:02:08.2977129-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240209010208_bugHeureFernmeture', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T01:52:06.1474322-05:00', [DateHeureInscriptions] = '2024-02-08T17:52:06.1474286-05:00', [DateHeureOuverture] = '2024-02-08T20:52:06.1474320-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T20:52:06.1474327-05:00', [DateHeureInscriptions] = '2024-02-09T17:52:06.1474324-05:00', [DateHeureOuverture] = '2024-02-09T20:52:06.1474326-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T01:52:06.1474332-05:00', [DateHeureInscriptions] = '2024-02-08T17:52:06.1474329-05:00', [DateHeureOuverture] = '2024-02-08T20:52:06.1474331-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T20:52:06.1474336-05:00', [DateHeureInscriptions] = '2024-02-09T17:52:06.1474334-05:00', [DateHeureOuverture] = '2024-02-09T20:52:06.1474335-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240209015206_MAJHeureClinique1', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T03:06:29.9713831-05:00', [DateHeureInscriptions] = '2024-02-08T19:06:29.9713788-05:00', [DateHeureOuverture] = '2024-02-08T22:06:29.9713829-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T22:06:29.9713836-05:00', [DateHeureInscriptions] = '2024-02-09T19:06:29.9713833-05:00', [DateHeureOuverture] = '2024-02-09T22:06:29.9713834-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T03:06:29.9713841-05:00', [DateHeureInscriptions] = '2024-02-08T19:06:29.9713839-05:00', [DateHeureOuverture] = '2024-02-08T22:06:29.9713840-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T22:06:29.9713848-05:00', [DateHeureInscriptions] = '2024-02-09T19:06:29.9713845-05:00', [DateHeureOuverture] = '2024-02-09T22:06:29.9713847-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240209030630_DateTimeNow', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T18:39:11.2936810-05:00', [DateHeureInscriptions] = '2024-02-09T10:39:11.2936774-05:00', [DateHeureOuverture] = '2024-02-09T13:39:11.2936808-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T13:39:11.2936816-05:00', [DateHeureInscriptions] = '2024-02-10T10:39:11.2936813-05:00', [DateHeureOuverture] = '2024-02-10T13:39:11.2936814-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T18:39:11.2936822-05:00', [DateHeureInscriptions] = '2024-02-09T10:39:11.2936819-05:00', [DateHeureOuverture] = '2024-02-09T13:39:11.2936821-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T13:39:11.2936827-05:00', [DateHeureInscriptions] = '2024-02-10T10:39:11.2936824-05:00', [DateHeureOuverture] = '2024-02-10T13:39:11.2936826-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240209183911_DerniereMAJDatetimeNow', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T21:43:20.0302630-05:00', [DateHeureInscriptions] = '2024-02-09T13:43:20.0302591-05:00', [DateHeureOuverture] = '2024-02-09T16:43:20.0302628-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T16:43:20.0302637-05:00', [DateHeureInscriptions] = '2024-02-10T13:43:20.0302634-05:00', [DateHeureOuverture] = '2024-02-10T16:43:20.0302635-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-09T21:43:20.0302643-05:00', [DateHeureInscriptions] = '2024-02-09T13:43:20.0302641-05:00', [DateHeureOuverture] = '2024-02-09T16:43:20.0302642-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T16:43:20.0302647-05:00', [DateHeureInscriptions] = '2024-02-10T13:43:20.0302645-05:00', [DateHeureOuverture] = '2024-02-10T16:43:20.0302646-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240209214320_finale', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T01:44:21.2347379-05:00', [DateHeureInscriptions] = '2024-02-09T17:44:21.2347338-05:00', [DateHeureOuverture] = '2024-02-09T20:44:21.2347377-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T20:44:21.2347385-05:00', [DateHeureInscriptions] = '2024-02-10T17:44:21.2347381-05:00', [DateHeureOuverture] = '2024-02-10T20:44:21.2347383-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T01:44:21.2347391-05:00', [DateHeureInscriptions] = '2024-02-09T17:44:21.2347388-05:00', [DateHeureOuverture] = '2024-02-09T20:44:21.2347390-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-02-10T20:44:21.2347395-05:00', [DateHeureInscriptions] = '2024-02-10T17:44:21.2347393-05:00', [DateHeureOuverture] = '2024-02-10T20:44:21.2347394-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240210014421_UpdateFinale', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-13T16:13:07.5390261-04:00', [DateHeureInscriptions] = '2024-03-13T08:13:07.5390288-04:00', [DateHeureOuverture] = '2024-03-13T11:13:07.5390291-04:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-14T16:13:07.5390335-04:00', [DateHeureInscriptions] = '2024-03-14T08:13:07.5390337-04:00', [DateHeureOuverture] = '2024-03-14T11:13:07.5390339-04:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-13T16:13:07.5390346-04:00', [DateHeureInscriptions] = '2024-03-13T08:13:07.5390348-04:00', [DateHeureOuverture] = '2024-03-13T11:13:07.5390349-04:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-14T16:13:07.5390355-04:00', [DateHeureInscriptions] = '2024-03-14T08:13:07.5390357-04:00', [DateHeureOuverture] = '2024-03-14T11:13:07.5390358-04:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240304201017_MAJDATETIME', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-05T19:42:03.5570464-05:00', [DateHeureInscriptions] = '2024-03-05T11:42:03.5570424-05:00', [DateHeureOuverture] = '2024-03-05T14:42:03.5570462-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-06T14:42:03.5570469-05:00', [DateHeureInscriptions] = '2024-03-06T11:42:03.5570466-05:00', [DateHeureOuverture] = '2024-03-06T14:42:03.5570467-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-05T19:42:03.5570474-05:00', [DateHeureInscriptions] = '2024-03-05T11:42:03.5570472-05:00', [DateHeureOuverture] = '2024-03-05T14:42:03.5570473-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-06T14:42:03.5570479-05:00', [DateHeureInscriptions] = '2024-03-06T11:42:03.5570476-05:00', [DateHeureOuverture] = '2024-03-06T14:42:03.5570477-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240305194203_MAJHeures01', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[PlagesHoraires]') AND [c].[name] = N'NumeroMedecin');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[PlagesHoraires] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [PlagesHoraires] DROP COLUMN [NumeroMedecin];
GO

ALTER TABLE [dbo].[Cliniques] ADD [TempsAvantAnnulation] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [dbo].[PlagesHorairesAnnules] (
    [Id] int NOT NULL IDENTITY,
    [Debut] time NOT NULL,
    [FileDAttenteId] int NOT NULL,
    [PatientId] nvarchar(max) NULL,
    [MedecinId] nvarchar(max) NULL,
    [raisonAnnulation] nvarchar(max) NOT NULL,
    [PlageHoraireId] int NOT NULL,
    CONSTRAINT [PK_PlagesHorairesAnnules] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PlagesHorairesAnnules_PlagesHoraires_PlageHoraireId] FOREIGN KEY ([PlageHoraireId]) REFERENCES [dbo].[PlagesHoraires] ([Id]) ON DELETE CASCADE
);
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-06T15:34:52.7417775-05:00', [DateHeureInscriptions] = '2024-03-06T07:34:52.7417737-05:00', [DateHeureOuverture] = '2024-03-06T10:34:52.7417774-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-07T15:34:52.7417780-05:00', [DateHeureInscriptions] = '2024-03-07T07:34:52.7417777-05:00', [DateHeureOuverture] = '2024-03-07T10:34:52.7417778-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-06T15:34:52.7417785-05:00', [DateHeureInscriptions] = '2024-03-06T07:34:52.7417783-05:00', [DateHeureOuverture] = '2024-03-06T10:34:52.7417784-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-07T15:34:52.7417789-05:00', [DateHeureInscriptions] = '2024-03-07T07:34:52.7417787-05:00', [DateHeureOuverture] = '2024-03-07T10:34:52.7417788-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_PlagesHorairesAnnules_PlageHoraireId] ON [dbo].[PlagesHorairesAnnules] ([PlageHoraireId]);
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240306153453_PlageHoraireAnnule', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[dbo].[PlagesHorairesAnnules].[raisonAnnulation]', N'RaisonAnnulation', N'COLUMN';
GO

ALTER TABLE [dbo].[PlagesHorairesAnnules] ADD [DescriptionRaison] nvarchar(200) NULL;
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-07T15:17:10.4985816-05:00', [DateHeureInscriptions] = '2024-03-07T07:17:10.4985774-05:00', [DateHeureOuverture] = '2024-03-07T10:17:10.4985815-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-08T15:17:10.4985822-05:00', [DateHeureInscriptions] = '2024-03-08T07:17:10.4985819-05:00', [DateHeureOuverture] = '2024-03-08T10:17:10.4985820-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-07T15:17:10.4985828-05:00', [DateHeureInscriptions] = '2024-03-07T07:17:10.4985825-05:00', [DateHeureOuverture] = '2024-03-07T10:17:10.4985826-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-08T15:17:10.4985832-05:00', [DateHeureInscriptions] = '2024-03-08T07:17:10.4985829-05:00', [DateHeureOuverture] = '2024-03-08T10:17:10.4985831-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240307151710_AddDescriptionPlageHoraireAnnule', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 30
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 90
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 120
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 60
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 150
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 180
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[Cliniques] SET [TempsAvantAnnulation] = 120
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-08T21:16:28.7993329-05:00', [DateHeureInscriptions] = '2024-03-08T13:16:28.7993287-05:00', [DateHeureOuverture] = '2024-03-08T16:16:28.7993327-05:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-09T21:16:28.7993334-05:00', [DateHeureInscriptions] = '2024-03-09T13:16:28.7993331-05:00', [DateHeureOuverture] = '2024-03-09T16:16:28.7993333-05:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-08T21:16:28.7993339-05:00', [DateHeureInscriptions] = '2024-03-08T13:16:28.7993337-05:00', [DateHeureOuverture] = '2024-03-08T16:16:28.7993338-05:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-09T21:16:28.7993345-05:00', [DateHeureInscriptions] = '2024-03-09T13:16:28.7993342-05:00', [DateHeureOuverture] = '2024-03-09T16:16:28.7993344-05:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240308211629_AjoutTempsAvantAnnulationSeedClinique', N'6.0.25');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP INDEX [IX_PlagesHorairesAnnules_PlageHoraireId] ON [dbo].[PlagesHorairesAnnules];
GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-11T14:53:13.7635684-04:00', [DateHeureInscriptions] = '2024-03-11T06:53:13.7635650-04:00', [DateHeureOuverture] = '2024-03-11T09:53:13.7635683-04:00'
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-12T14:53:13.7635690-04:00', [DateHeureInscriptions] = '2024-03-12T06:53:13.7635686-04:00', [DateHeureOuverture] = '2024-03-12T09:53:13.7635688-04:00'
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-11T14:53:13.7635696-04:00', [DateHeureInscriptions] = '2024-03-11T06:53:13.7635693-04:00', [DateHeureOuverture] = '2024-03-11T09:53:13.7635695-04:00'
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [dbo].[FilesDAttente] SET [DateHeureFermeture] = '2024-03-12T14:53:13.7635701-04:00', [DateHeureInscriptions] = '2024-03-12T06:53:13.7635698-04:00', [DateHeureOuverture] = '2024-03-12T09:53:13.7635699-04:00'
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_PlagesHorairesAnnules_PlageHoraireId] ON [dbo].[PlagesHorairesAnnules] ([PlageHoraireId]);
GO

INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311135314_OnetoManyPlageHoraireAnnule', N'6.0.25');
GO

COMMIT;
GO

