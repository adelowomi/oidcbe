IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
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
    [GenderId] int NOT NULL,
    [ProfilePhoto] nvarchar(max) NULL,
    [Token] nvarchar(max) NULL,
    [OTP] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
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

CREATE TABLE [PostTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    CONSTRAINT [PK_PostTypes] PRIMARY KEY ([Id])
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

CREATE TABLE [Posts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Comment] nvarchar(max) NULL,
    [PostTypeId] int NOT NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Posts_PostTypes_PostTypeId] FOREIGN KEY ([PostTypeId]) REFERENCES [PostTypes] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_Posts_PostTypeId] ON [Posts] ([PostTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201005122512_InitialMigration', N'3.1.8');

GO

CREATE INDEX [IX_AspNetUsers_GenderId] ON [AspNetUsers] ([GenderId]);

GO

ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201005124215_MappedGenderToUser', N'3.1.8');

GO

DROP TABLE [Posts];

GO

DROP TABLE [PostTypes];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201019101830_AnotherMigration', N'3.1.8');

GO

ALTER TABLE [AppUserDetails] DROP CONSTRAINT [FK_AppUserDetails_AppUserTypes_AppUserTypeId];

GO

ALTER TABLE [AppUserDetails] DROP CONSTRAINT [FK_AppUserDetails_Genders_GenderId];

GO

ALTER TABLE [Subscriptions] DROP CONSTRAINT [FK_Subscriptions_AppUserDetails_AppUserDetailId];

GO

DROP INDEX [IX_Subscriptions_AppUserDetailId] ON [Subscriptions];

GO

DROP INDEX [IX_AppUserDetails_AppUserTypeId] ON [AppUserDetails];

GO

DROP INDEX [IX_AppUserDetails_GenderId] ON [AppUserDetails];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Subscriptions]') AND [c].[name] = N'AppUserDetailId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Subscriptions] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Subscriptions] DROP COLUMN [AppUserDetailId];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'AppUserTypeId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [AppUserTypeId];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'FirstName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [FirstName];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'GenderId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [GenderId];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'LastName');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [LastName];

GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'MiddleName');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [MiddleName];

GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'OTP');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [OTP];

GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[AppUserDetails]') AND [c].[name] = N'Token');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [AppUserDetails] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [AppUserDetails] DROP COLUMN [Token];

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201020152211_ManyFieldsKMigration', N'3.1.8');

GO

