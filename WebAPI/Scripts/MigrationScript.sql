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

