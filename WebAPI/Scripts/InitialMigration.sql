﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

CREATE TABLE [Plots] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [PlotTypeId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [KilometerSquare] float NOT NULL,
    [Acres] float NOT NULL,
    [Longitude] float NOT NULL,
    [Lattitude] float NOT NULL,
    [IsAvailable] bit NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
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
    [GenderId] int NULL,
    [ProfilePhoto] nvarchar(max) NULL,
    [Token] nvarchar(max) NULL,
    [OTP] nvarchar(max) NULL,
    [AppUserTypeId] int NOT NULL,
    [IdentificationId] int NULL,
    [ResidentialAddress] nvarchar(max) NULL,
    [MailingAddress] nvarchar(max) NULL,
    [StateOfOriginId] int NULL,
    [StateId] int NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_States_StateId] FOREIGN KEY ([StateId]) REFERENCES [States] ([Id]) ON DELETE NO ACTION
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
    [Gender] nvarchar(max) NULL,
    CONSTRAINT [PK_NextOfKins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_NextOfKins_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201028080712_InitialMigration', N'3.1.8');

GO

