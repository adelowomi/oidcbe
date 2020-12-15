IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AppUserTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_AppUserTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Genders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Identification] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Identification] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [OfferStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_OfferStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [OrganizationTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_OrganizationTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PaymentMethods] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PaymentProviders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentProviders] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PaymentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PaymentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PlotTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] int NOT NULL IDENTITY,
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
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [MiddleName] nvarchar(max) NULL,
    [ProfilePhoto] nvarchar(max) NULL,
    [IdentityDocument] nvarchar(max) NULL,
    [Token] nvarchar(max) NULL,
    [OTP] nvarchar(max) NULL,
    [ResidentialAddress] nvarchar(max) NULL,
    [MailingAddress] nvarchar(max) NULL,
    [StateOfOriginId] int NULL,
    [GenderId] int NULL,
    [IdentificationId] int NULL,
    [StateId] int NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] int NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [NextOfKins] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [GenderId] int NULL,
    CONSTRAINT [PK_NextOfKins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NextOfKins_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_NextOfKins_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [OTPs] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Code] nvarchar(max) NULL,
    CONSTRAINT [PK_OTPs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Plots] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [PlotTypeId] int NOT NULL,
    [AppUserId] int NULL,
    [Name] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [KilometerSquare] float NOT NULL,
    [Acres] float NOT NULL,
    [Longitude] float NOT NULL,
    [Lattitude] float NOT NULL,
    [IsAvailable] bit NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Offers] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [PlotId] int NOT NULL,
    [OfferStatusId] int NULL,
    [DocumentPath] nvarchar(max) NULL,
    CONSTRAINT [PK_Offers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Offers_OfferStatuses_OfferStatusId] FOREIGN KEY ([OfferStatusId]) REFERENCES [OfferStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Offers_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Payments] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Amount] float NOT NULL,
    [PaymentTypeId] int NOT NULL,
    [Balance] float NOT NULL,
    [PaymentMethodId] int NOT NULL,
    [PaymentReceiptPath] nvarchar(max) NULL,
    [PaymentProviderId] int NOT NULL,
    [PaymentStatusId] int NOT NULL,
    [OfferId] int NOT NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentProviders_PaymentProviderId] FOREIGN KEY ([PaymentProviderId]) REFERENCES [PaymentProviders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentStatuses_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentTypes_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Subscriptions] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NULL,
    [OfferId] int NULL,
    [OrganizationTypeId] int NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [IX_AspNetUsers_GenderId] ON [AspNetUsers] ([GenderId]);

GO

CREATE INDEX [IX_AspNetUsers_IdentificationId] ON [AspNetUsers] ([IdentificationId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUsers_StateId] ON [AspNetUsers] ([StateId]);

GO

CREATE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

CREATE INDEX [IX_NextOfKins_GenderId] ON [NextOfKins] ([GenderId]);

GO

CREATE INDEX [IX_Offers_OfferStatusId] ON [Offers] ([OfferStatusId]);

GO

CREATE INDEX [IX_Offers_PlotId] ON [Offers] ([PlotId]);

GO

CREATE INDEX [IX_OTPs_AppUserId] ON [OTPs] ([AppUserId]);

GO

CREATE INDEX [IX_Payments_OfferId] ON [Payments] ([OfferId]);

GO

CREATE INDEX [IX_Payments_PaymentMethodId] ON [Payments] ([PaymentMethodId]);

GO

CREATE INDEX [IX_Payments_PaymentProviderId] ON [Payments] ([PaymentProviderId]);

GO

CREATE INDEX [IX_Payments_PaymentStatusId] ON [Payments] ([PaymentStatusId]);

GO

CREATE INDEX [IX_Payments_PaymentTypeId] ON [Payments] ([PaymentTypeId]);

GO

CREATE INDEX [IX_Plots_AppUserId] ON [Plots] ([AppUserId]);

GO

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201104193906_InitialMigration', N'3.1.8');

GO

ALTER TABLE [OTPs] ADD [ExpiryDateTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [OTPs] ADD [IsExpired] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [OTPs] ADD [UsedDateTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201104232306_UseDateTimeMigrations', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [HasUploadedDocument] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201105171458_BooleanModelAspNetUsers', N'3.1.8');

GO

ALTER TABLE [OTPs] ADD [IsUsed] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201106095957_AddedIsUsed', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [EntryName] nvarchar(max) NULL;

GO

ALTER TABLE [AspNetUsers] ADD [OfficeAddress] nvarchar(max) NULL;

GO

ALTER TABLE [AspNetUsers] ADD [RCNumber] nvarchar(max) NULL;

GO

ALTER TABLE [AspNetUsers] ADD [WebsiteUrl] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201106134029_MoreFieldsToAspNetUsers', N'3.1.8');

GO

ALTER TABLE [OTPs] ADD [PlatformId] int NULL;

GO

CREATE TABLE [Platform] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Platform] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_OTPs_PlatformId] ON [OTPs] ([PlatformId]);

GO

ALTER TABLE [OTPs] ADD CONSTRAINT [FK_OTPs_Platform_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platform] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201108174902_SomeFieldsAdded', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [OrganizationTypeId] int NULL;

GO

CREATE INDEX [IX_AspNetUsers_OrganizationTypeId] ON [AspNetUsers] ([OrganizationTypeId]);

GO

ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201109001411_AddOrganizationTypeIdToAppUser', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [HasUploadedProfilePhoto] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201109005617_HasUploadedPhoto', N'3.1.8');

GO

ALTER TABLE [OTPs] ADD [CodeSlug] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201110133333_CodeSlugField', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [IsNew] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [AspNetUsers] ADD [IsSubscriber] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [AspNetUsers] ADD [IsVendor] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201112031525_AddedSomeBooleanValues', N'3.1.8');

GO

ALTER TABLE [OTPs] DROP CONSTRAINT [FK_OTPs_Platform_PlatformId];

GO

ALTER TABLE [Platform] DROP CONSTRAINT [PK_Platform];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'IsSubscriber');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [IsSubscriber];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'IsVendor');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [IsVendor];

GO

EXEC sp_rename N'[Platform]', N'Platforms';

GO

ALTER TABLE [Platforms] ADD CONSTRAINT [PK_Platforms] PRIMARY KEY ([Id]);

GO

ALTER TABLE [OTPs] ADD CONSTRAINT [FK_OTPs_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201112103557_IsNewProperty', N'3.1.8');

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'IsNew');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [IsNew];

GO

ALTER TABLE [AspNetUsers] ADD [IsExisting] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201112110012_IsExistingProperty', N'3.1.8');

GO

CREATE TABLE [DocumentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DocumentTypes_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [DocumentTypeId] int NOT NULL,
    [AppUserId] int NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Documents_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

CREATE INDEX [IX_Documents_DocumentTypeId] ON [Documents] ([DocumentTypeId]);

GO

CREATE INDEX [IX_DocumentTypes_AppUserId] ON [DocumentTypes] ([AppUserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201121060829_DocumentModels', N'3.1.8');

GO

ALTER TABLE [Documents] DROP CONSTRAINT [FK_Documents_AspNetUsers_AppUserId];

GO

DROP INDEX [IX_Documents_AppUserId] ON [Documents];
DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Documents]') AND [c].[name] = N'AppUserId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Documents] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Documents] ALTER COLUMN [AppUserId] int NOT NULL;
CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

ALTER TABLE [Documents] ADD CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201121062540_AddAppUserIdToDocument', N'3.1.8');

GO

ALTER TABLE [DocumentTypes] DROP CONSTRAINT [FK_DocumentTypes_AspNetUsers_AppUserId];

GO

DROP INDEX [IX_DocumentTypes_AppUserId] ON [DocumentTypes];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DocumentTypes]') AND [c].[name] = N'AppUserId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [DocumentTypes] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [DocumentTypes] DROP COLUMN [AppUserId];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201121070416_RemoveDocumentTypeIdFromDocument', N'3.1.8');

GO

DELETE FROM [Plots]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 4;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 5;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 6;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 7;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 8;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 9;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 10;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 11;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 12;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 13;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 14;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 15;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 16;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 17;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 18;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 19;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 20;
SELECT @@ROWCOUNT;


GO

DELETE FROM [Plots]
WHERE [Id] = 61;
SELECT @@ROWCOUNT;


GO

DELETE FROM [PlotTypes]
WHERE [Id] = 1;
SELECT @@ROWCOUNT;


GO

DELETE FROM [PlotTypes]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;


GO

DELETE FROM [PlotTypes]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125065414_LinkedPlotToDocument', N'3.1.8');

GO

ALTER TABLE [Documents] DROP CONSTRAINT [FK_Documents_Plots_PlotId];

GO

DROP INDEX [IX_Documents_PlotId] ON [Documents];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Documents]') AND [c].[name] = N'PlotId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Documents] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Documents] DROP COLUMN [PlotId];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125065609_RemovePlotProperties', N'3.1.8');

GO

ALTER TABLE [Documents] ADD [PlotId] int NOT NULL DEFAULT 0;

GO

CREATE INDEX [IX_Documents_PlotId] ON [Documents] ([PlotId]);

GO

ALTER TABLE [Documents] ADD CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125065755_LinkedPlotToDocumentAgain', N'3.1.8');

GO

ALTER TABLE [Documents] DROP CONSTRAINT [FK_Documents_Plots_PlotId];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Documents]') AND [c].[name] = N'PlotId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Documents] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Documents] ALTER COLUMN [PlotId] int NULL;

GO

ALTER TABLE [Documents] ADD CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125070319_MakeDocumentPlotIdNullable', N'3.1.8');

GO

ALTER TABLE [Payments] DROP CONSTRAINT [FK_Payments_Offers_OfferId];

GO

ALTER TABLE [Subscriptions] ADD [SubscriptionStatusId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Plots] ADD [IsPaymentComplete] bit NOT NULL DEFAULT CAST(0 AS bit);

GO

ALTER TABLE [Plots] ADD [PlotStatusId] int NULL;

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Payments]') AND [c].[name] = N'OfferId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Payments] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Payments] ALTER COLUMN [OfferId] int NULL;

GO

ALTER TABLE [Payments] ADD [subscriptionId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [DocumentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PlotStatus] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotStatus] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SubscriptionStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_SubscriptionStatuses] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Subscriptions_SubscriptionStatusId] ON [Subscriptions] ([SubscriptionStatusId]);

GO

CREATE INDEX [IX_Plots_PlotStatusId] ON [Plots] ([PlotStatusId]);

GO

CREATE INDEX [IX_Payments_subscriptionId] ON [Payments] ([subscriptionId]);

GO

ALTER TABLE [Payments] ADD CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Payments] ADD CONSTRAINT [FK_Payments_Subscriptions_subscriptionId] FOREIGN KEY ([subscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Plots] ADD CONSTRAINT [FK_Plots_PlotStatus_PlotStatusId] FOREIGN KEY ([PlotStatusId]) REFERENCES [PlotStatus] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Subscriptions] ADD CONSTRAINT [FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId] FOREIGN KEY ([SubscriptionStatusId]) REFERENCES [SubscriptionStatuses] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125081115_AddedSomeProperties2', N'3.1.8');

GO

CREATE TABLE [WorkOrderTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [WorkOrders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [SubscriptionId] int NOT NULL,
    [WorkOrderTypeId] int NOT NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkOrders_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId] FOREIGN KEY ([WorkOrderTypeId]) REFERENCES [WorkOrderTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_WorkOrders_SubscriptionId] ON [WorkOrders] ([SubscriptionId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderTypeId] ON [WorkOrders] ([WorkOrderTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125082229_WorkOrderModels', N'3.1.8');

GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkOrders]') AND [c].[name] = N'Name');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [WorkOrders] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [WorkOrders] DROP COLUMN [Name];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125105600_SomeModel', N'3.1.8');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125114215_RemovedAppUserIdFromPlot', N'3.1.8');

GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Plots]') AND [c].[name] = N'HasAmount');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Plots] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Plots] DROP COLUMN [HasAmount];

GO

ALTER TABLE [Payments] ADD [TrnxRef] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125160842_AddAmountToPlot', N'3.1.8');

GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Plots]') AND [c].[name] = N'Amount');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Plots] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [Plots] DROP COLUMN [Amount];

GO

ALTER TABLE [Plots] ADD [Price] float NOT NULL DEFAULT 0.0E0;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201125161134_AddPriceToPlot', N'3.1.8');

GO

ALTER TABLE [Payments] DROP CONSTRAINT [FK_Payments_Subscriptions_subscriptionId];

GO

EXEC sp_rename N'[Payments].[subscriptionId]', N'SubscriptionId', N'COLUMN';

GO

EXEC sp_rename N'[Payments].[IX_Payments_subscriptionId]', N'IX_Payments_SubscriptionId', N'INDEX';

GO

ALTER TABLE [Payments] ADD CONSTRAINT [FK_Payments_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201126073614_ChangesSubsciptionId', N'3.1.8');

GO

ALTER TABLE [WorkOrders] ADD [AppUserId] int NULL;

GO

ALTER TABLE [WorkOrders] ADD [Name] nvarchar(max) NULL;

GO

CREATE INDEX [IX_WorkOrders_AppUserId] ON [WorkOrders] ([AppUserId]);

GO

ALTER TABLE [WorkOrders] ADD CONSTRAINT [FK_WorkOrders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201127204221_AddSomeMainModel', N'3.1.8');

GO

CREATE TABLE [CalendarEvents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CalendarEvents] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Calendars] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [CalendarEventId] int NOT NULL,
    [PlotId] int NOT NULL,
    CONSTRAINT [PK_Calendars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Calendars_CalendarEvents_CalendarEventId] FOREIGN KEY ([CalendarEventId]) REFERENCES [CalendarEvents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calendars_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Calendars_CalendarEventId] ON [Calendars] ([CalendarEventId]);

GO

CREATE INDEX [IX_Calendars_PlotId] ON [Calendars] ([PlotId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201128105529_AddModelsToCalendar', N'3.1.8');

GO

ALTER TABLE [WorkOrders] DROP CONSTRAINT [FK_WorkOrders_Subscriptions_SubscriptionId];

GO

DROP INDEX [IX_WorkOrders_SubscriptionId] ON [WorkOrders];

GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[WorkOrders]') AND [c].[name] = N'SubscriptionId');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [WorkOrders] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [WorkOrders] DROP COLUMN [SubscriptionId];

GO

ALTER TABLE [WorkOrders] ADD [PlotId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Mobilizations] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [PlotId] int NOT NULL,
    [LeadName] nvarchar(max) NULL,
    [LeadPhoneNumber] nvarchar(max) NULL,
    [NumberOfWorkers] int NOT NULL,
    [IdentityPath] nvarchar(max) NULL,
    CONSTRAINT [PK_Mobilizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilizations_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [PermitTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [VehicleTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Visitors] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Vehicles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Make] nvarchar(max) NULL,
    [PlateNumber] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    [VehicleTypeId] int NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Permits] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [VisitorId] int NULL,
    [VehicleId] int NULL,
    [PermitTypeId] int NOT NULL,
    CONSTRAINT [PK_Permits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permits_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitTypes_PermitTypeId] FOREIGN KEY ([PermitTypeId]) REFERENCES [PermitTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Permits_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_WorkOrders_PlotId] ON [WorkOrders] ([PlotId]);

GO

CREATE INDEX [IX_Mobilizations_PlotId] ON [Mobilizations] ([PlotId]);

GO

CREATE INDEX [IX_Permits_AppUserId] ON [Permits] ([AppUserId]);

GO

CREATE INDEX [IX_Permits_PermitTypeId] ON [Permits] ([PermitTypeId]);

GO

CREATE INDEX [IX_Permits_VehicleId] ON [Permits] ([VehicleId]);

GO

CREATE INDEX [IX_Permits_VisitorId] ON [Permits] ([VisitorId]);

GO

CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);

GO

ALTER TABLE [WorkOrders] ADD CONSTRAINT [FK_WorkOrders_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201202233418_PermitAndMobilizationMigration', N'3.1.8');

GO

ALTER TABLE [Mobilizations] ADD [AppUserId] int NULL;

GO

CREATE INDEX [IX_Mobilizations_AppUserId] ON [Mobilizations] ([AppUserId]);

GO

ALTER TABLE [Mobilizations] ADD CONSTRAINT [FK_Mobilizations_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201203003919_AppUserIdToMobilization', N'3.1.8');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201203004720_AnonymousMigrationId', N'3.1.8');

GO

ALTER TABLE [WorkOrders] ADD [Document] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201203063709_DocumentToWorkOrder', N'3.1.8');

GO

ALTER TABLE [WorkOrders] ADD [Description] nvarchar(max) NULL;

GO

ALTER TABLE [WorkOrders] ADD [WorkOrderStatusId] int NULL;

GO

CREATE TABLE [WorkOrderStatus] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderStatus] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderStatusId] ON [WorkOrders] ([WorkOrderStatusId]);

GO

ALTER TABLE [WorkOrders] ADD CONSTRAINT [FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId] FOREIGN KEY ([WorkOrderStatusId]) REFERENCES [WorkOrderStatus] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201204084100_WorkOrderStatusId', N'3.1.8');

GO

ALTER TABLE [AspNetUsers] ADD [GUI] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201205125142_AddedAspNetGUI', N'3.1.8');

GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AspNetUsers]') AND [c].[name] = N'GUI');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [AspNetUsers] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [AspNetUsers] DROP COLUMN [GUI];

GO

ALTER TABLE [AspNetUsers] ADD [GUID] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201205130728_ChangeGUIToGUID', N'3.1.8');

GO

CREATE TABLE [RequestTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_RequestTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Requests] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [RequestId] int NOT NULL,
    [RequestTypeId] int NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requests_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Requests_AppUserId] ON [Requests] ([AppUserId]);

GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201205150135_RequestTypeMigration', N'3.1.8');

GO

ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId];

GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Requests]') AND [c].[name] = N'RequestId');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Requests] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Requests] DROP COLUMN [RequestId];

GO

DROP INDEX [IX_Requests_RequestTypeId] ON [Requests];
DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Requests]') AND [c].[name] = N'RequestTypeId');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Requests] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Requests] ALTER COLUMN [RequestTypeId] int NOT NULL;
CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

ALTER TABLE [Requests] ADD [Name] nvarchar(max) NULL;

GO

ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201205172858_SomeMoreEntityModelInIt', N'3.1.8');

GO

ALTER TABLE [Calendars] ADD [Description] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201205182504_AddDescriptionToCalendar', N'3.1.8');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201206050432_RemoveDescription', N'3.1.8');

GO

ALTER TABLE [Visitors] ADD [AppUserId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Vehicles] ADD [AppUserId] int NOT NULL DEFAULT 0;

GO

CREATE INDEX [IX_Visitors_AppUserId] ON [Visitors] ([AppUserId]);

GO

CREATE INDEX [IX_Vehicles_AppUserId] ON [Vehicles] ([AppUserId]);

GO

ALTER TABLE [Vehicles] ADD CONSTRAINT [FK_Vehicles_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Visitors] ADD CONSTRAINT [FK_Visitors_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201206140330_AddedAppUserId', N'3.1.8');

GO

ALTER TABLE [Mobilizations] ADD [MobilizationStatusId] int NULL;

GO

CREATE TABLE [MobilizationStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MobilizationStatuses] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Mobilizations_MobilizationStatusId] ON [Mobilizations] ([MobilizationStatusId]);

GO

ALTER TABLE [Mobilizations] ADD CONSTRAINT [FK_Mobilizations_MobilizationStatuses_MobilizationStatusId] FOREIGN KEY ([MobilizationStatusId]) REFERENCES [MobilizationStatuses] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201207092057_MobilizationStatus', N'3.1.8');

GO

ALTER TABLE [Requests] ADD [Description] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201208073641_Description', N'3.1.8');

GO

ALTER TABLE [Requests] ADD [RequestStatusId] int NULL;

GO

CREATE TABLE [requestStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_requestStatuses] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Requests_RequestStatusId] ON [Requests] ([RequestStatusId]);

GO

ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_requestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [requestStatuses] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201209091150_RequestStatusId', N'3.1.8');

GO

ALTER TABLE [Requests] DROP CONSTRAINT [FK_Requests_requestStatuses_RequestStatusId];

GO

ALTER TABLE [requestStatuses] DROP CONSTRAINT [PK_requestStatuses];

GO

EXEC sp_rename N'[requestStatuses]', N'RequestStatuses';

GO

ALTER TABLE [RequestStatuses] ADD CONSTRAINT [PK_RequestStatuses] PRIMARY KEY ([Id]);

GO

ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_RequestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [RequestStatuses] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201209092339_RenameRequestStatusTable', N'3.1.8');

GO

ALTER TABLE [Permits] ADD [PermitStatusId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [Forums] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Forums] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [PermitStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ForumMessages] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [ForumId] int NOT NULL,
    CONSTRAINT [PK_ForumMessages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [ForumSubscriptions] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [ForumId] int NOT NULL,
    [AppUserId] int NOT NULL,
    CONSTRAINT [PK_ForumSubscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumSubscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ForumSubscriptions_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Permits_PermitStatusId] ON [Permits] ([PermitStatusId]);

GO

CREATE INDEX [IX_ForumMessages_ForumId] ON [ForumMessages] ([ForumId]);

GO

CREATE INDEX [IX_ForumSubscriptions_AppUserId] ON [ForumSubscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_ForumSubscriptions_ForumId] ON [ForumSubscriptions] ([ForumId]);

GO

ALTER TABLE [Permits] ADD CONSTRAINT [FK_Permits_PermitStatuses_PermitStatusId] FOREIGN KEY ([PermitStatusId]) REFERENCES [PermitStatuses] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201210125319_ForumAndPermitStatus', N'3.1.8');

GO

DROP INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins];

GO

CREATE UNIQUE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201210170643_AddingNextOfKinBack', N'3.1.8');

GO

ALTER TABLE [Requests] ADD [PlotId] int NULL;

GO

CREATE INDEX [IX_Requests_PlotId] ON [Requests] ([PlotId]);

GO

ALTER TABLE [Requests] ADD CONSTRAINT [FK_Requests_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201211154618_AddedPlotIdToRequest', N'3.1.8');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201211155106_PlotAddRequest', N'3.1.8');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201211155849_UpdatesPlotRequest', N'3.1.8');

GO

ALTER TABLE [ForumMessages] DROP CONSTRAINT [FK_ForumMessages_Forums_ForumId];

GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ForumMessages]') AND [c].[name] = N'ForumId');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [ForumMessages] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [ForumMessages] ALTER COLUMN [ForumId] int NULL;

GO

ALTER TABLE [ForumMessages] ADD [ForumMessageTypeId] int NOT NULL DEFAULT 0;

GO

CREATE TABLE [ForumMessageType] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ForumMessageType] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_ForumMessages_ForumMessageTypeId] ON [ForumMessages] ([ForumMessageTypeId]);

GO

ALTER TABLE [ForumMessages] ADD CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [ForumMessages] ADD CONSTRAINT [FK_ForumMessages_ForumMessageType_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageType] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214053814_AdjustmentInForumEntity', N'3.1.8');

GO

ALTER TABLE [ForumMessages] DROP CONSTRAINT [FK_ForumMessages_ForumMessageType_ForumMessageTypeId];

GO

ALTER TABLE [ForumMessageType] DROP CONSTRAINT [PK_ForumMessageType];

GO

EXEC sp_rename N'[ForumMessageType]', N'ForumMessageTypes';

GO

ALTER TABLE [ForumMessageTypes] ADD CONSTRAINT [PK_ForumMessageTypes] PRIMARY KEY ([Id]);

GO

ALTER TABLE [ForumMessages] ADD CONSTRAINT [FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageTypes] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214054218_AdjustmentInForumEntityAgain', N'3.1.8');

GO

ALTER TABLE [NextOfKins] ADD [MailingAddress] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214110210_AddedMailingAddress', N'3.1.8');

GO

CREATE TABLE [ContactTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ContactTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [ContactId] int NOT NULL,
    [ContactTypeId] int NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201214135026_ContactEntity', N'3.1.8');

GO

ALTER TABLE [Calendars] ADD [EndDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Calendars] ADD [Location] nvarchar(max) NULL;

GO

ALTER TABLE [Calendars] ADD [Name] nvarchar(max) NULL;

GO

ALTER TABLE [Calendars] ADD [StartDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215030421_AddedSomeCalendarFields', N'3.1.8');

GO

ALTER TABLE [Contacts] DROP CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId];

GO

DECLARE @var16 sysname;
SELECT @var16 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'ContactId');
IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var16 + '];');
ALTER TABLE [Contacts] DROP COLUMN [ContactId];

GO

DROP INDEX [IX_Contacts_ContactTypeId] ON [Contacts];
DECLARE @var17 sysname;
SELECT @var17 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Contacts]') AND [c].[name] = N'ContactTypeId');
IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Contacts] DROP CONSTRAINT [' + @var17 + '];');
ALTER TABLE [Contacts] ALTER COLUMN [ContactTypeId] int NOT NULL;
CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

ALTER TABLE [Contacts] ADD CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201215031555_RemovedContactIdFromContactEntity', N'3.1.8');

GO

