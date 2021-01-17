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

CREATE TABLE [CalendarEvents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CalendarEvents] PRIMARY KEY ([Id])
);

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

CREATE TABLE [DocumentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DocumentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ForumMessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ForumMessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [JobStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JobTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageAction] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageAction] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageIndicators] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Reference] nvarchar(max) NULL,
    [IsEnded] bit NOT NULL,
    CONSTRAINT [PK_MessageIndicators] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [PermitStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitStatuses] PRIMARY KEY ([Id])
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

CREATE TABLE [Platforms] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY ([Id])
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

CREATE TABLE [PlotTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProposalStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ProposalStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RequestStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_RequestStatuses] PRIMARY KEY ([Id])
);

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

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
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

CREATE TABLE [VehicleTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [WorkOrderTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderTypes] PRIMARY KEY ([Id])
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

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [ContactTypeId] int NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE CASCADE
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
    [ForumId] int NULL,
    [ForumMessageTypeId] int NOT NULL,
    CONSTRAINT [PK_ForumMessages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageTypes] ([Id]) ON DELETE CASCADE
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
    [GUID] nvarchar(max) NULL,
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
    [OrganizationTypeId] int NULL,
    [StateId] int NULL,
    [HasUploadedDocument] bit NOT NULL,
    [HasUploadedProfilePhoto] bit NOT NULL,
    [EntryName] nvarchar(max) NULL,
    [RCNumber] nvarchar(max) NULL,
    [OfficeAddress] nvarchar(max) NULL,
    [WebsiteUrl] nvarchar(max) NULL,
    [IsExisting] bit NOT NULL,
    [FireBaseToken] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [JobTypeId] int NOT NULL,
    [JobStatusId] int NOT NULL,
    [AppUserId] int NULL,
    [ValidityPeriod] datetime2 NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jobs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Jobs_JobStatuses_JobStatusId] FOREIGN KEY ([JobStatusId]) REFERENCES [JobStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_JobTypes_JobTypeId] FOREIGN KEY ([JobTypeId]) REFERENCES [JobTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Text] nvarchar(max) NULL,
    [MessageIndicatorId] int NULL,
    [SenderId] int NOT NULL,
    [ReceiverId] int NULL,
    [MessageTypeId] int NOT NULL,
    [MessageStatusId] int NOT NULL,
    [MessageQuoteId] int NULL,
    [Indicator] nvarchar(max) NULL,
    [MessageActionId] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_MessageAction_MessageActionId] FOREIGN KEY ([MessageActionId]) REFERENCES [MessageAction] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageIndicators_MessageIndicatorId] FOREIGN KEY ([MessageIndicatorId]) REFERENCES [MessageIndicators] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_Messages_MessageQuoteId] FOREIGN KEY ([MessageQuoteId]) REFERENCES [Messages] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_MessageStatuses_MessageStatusId] FOREIGN KEY ([MessageStatusId]) REFERENCES [MessageStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageTypes_MessageTypeId] FOREIGN KEY ([MessageTypeId]) REFERENCES [MessageTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
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
    [MailingAddress] nvarchar(max) NULL,
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
    [CodeSlug] nvarchar(max) NULL,
    [PlatformId] int NULL,
    [IsExpired] bit NOT NULL,
    [IsUsed] bit NOT NULL,
    [ExpiryDateTime] datetime2 NOT NULL,
    [UsedDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_OTPs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OTPs_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms] ([Id]) ON DELETE NO ACTION
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
    [IsPaymentComplete] bit NOT NULL,
    [PlotStatusId] int NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotStatus_PlotStatusId] FOREIGN KEY ([PlotStatusId]) REFERENCES [PlotStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Vehicles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [Make] nvarchar(max) NULL,
    [PlateNumber] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    [VehicleTypeId] int NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vehicles_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Visitors] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Address] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Visitors_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Proposals] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [JobId] int NOT NULL,
    [AppUserId] int NOT NULL,
    [ProposalStatusId] int NOT NULL,
    CONSTRAINT [PK_Proposals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Proposals_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_ProposalStatuses_ProposalStatusId] FOREIGN KEY ([ProposalStatusId]) REFERENCES [ProposalStatuses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Calendars] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [CalendarEventId] int NOT NULL,
    [PlotId] int NOT NULL,
    [Location] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Calendars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Calendars_CalendarEvents_CalendarEventId] FOREIGN KEY ([CalendarEventId]) REFERENCES [CalendarEvents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calendars_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [DocumentTypeId] int NOT NULL,
    [PlotId] int NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Mobilizations] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [PlotId] int NOT NULL,
    [AppUserId] int NULL,
    [LeadName] nvarchar(max) NULL,
    [LeadPhoneNumber] nvarchar(max) NULL,
    [NumberOfWorkers] int NOT NULL,
    [IdentityPath] nvarchar(max) NULL,
    [MobilizationStatusId] int NULL,
    CONSTRAINT [PK_Mobilizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilizations_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_MobilizationStatuses_MobilizationStatusId] FOREIGN KEY ([MobilizationStatusId]) REFERENCES [MobilizationStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
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

CREATE TABLE [Requests] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [RequestTypeId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [PlotId] int NULL,
    [RequestStatusId] int NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requests_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [RequestStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkOrders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NULL,
    [PlotId] int NOT NULL,
    [WorkOrderTypeId] int NOT NULL,
    [Document] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [WorkOrderStatusId] int NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkOrders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId] FOREIGN KEY ([WorkOrderStatusId]) REFERENCES [WorkOrderStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId] FOREIGN KEY ([WorkOrderTypeId]) REFERENCES [WorkOrderTypes] ([Id]) ON DELETE CASCADE
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
    [PermitStatusId] int NOT NULL,
    CONSTRAINT [PK_Permits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permits_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitStatuses_PermitStatusId] FOREIGN KEY ([PermitStatusId]) REFERENCES [PermitStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitTypes_PermitTypeId] FOREIGN KEY ([PermitTypeId]) REFERENCES [PermitTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Permits_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id]) ON DELETE NO ACTION
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
    [SubscriptionStatusId] int NOT NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId] FOREIGN KEY ([SubscriptionStatusId]) REFERENCES [SubscriptionStatuses] ([Id]) ON DELETE CASCADE
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
    [SubscriptionId] int NOT NULL,
    [TrnxRef] nvarchar(max) NULL,
    [OfferId] int NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentProviders_PaymentProviderId] FOREIGN KEY ([PaymentProviderId]) REFERENCES [PaymentProviders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentStatuses_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentTypes_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [IX_AspNetUsers_OrganizationTypeId] ON [AspNetUsers] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_AspNetUsers_StateId] ON [AspNetUsers] ([StateId]);

GO

CREATE INDEX [IX_Calendars_CalendarEventId] ON [Calendars] ([CalendarEventId]);

GO

CREATE INDEX [IX_Calendars_PlotId] ON [Calendars] ([PlotId]);

GO

CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

CREATE INDEX [IX_Documents_DocumentTypeId] ON [Documents] ([DocumentTypeId]);

GO

CREATE INDEX [IX_Documents_PlotId] ON [Documents] ([PlotId]);

GO

CREATE INDEX [IX_ForumMessages_ForumId] ON [ForumMessages] ([ForumId]);

GO

CREATE INDEX [IX_ForumMessages_ForumMessageTypeId] ON [ForumMessages] ([ForumMessageTypeId]);

GO

CREATE INDEX [IX_ForumSubscriptions_AppUserId] ON [ForumSubscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_ForumSubscriptions_ForumId] ON [ForumSubscriptions] ([ForumId]);

GO

CREATE INDEX [IX_Jobs_AppUserId] ON [Jobs] ([AppUserId]);

GO

CREATE INDEX [IX_Jobs_JobStatusId] ON [Jobs] ([JobStatusId]);

GO

CREATE INDEX [IX_Jobs_JobTypeId] ON [Jobs] ([JobTypeId]);

GO

CREATE INDEX [IX_Messages_MessageActionId] ON [Messages] ([MessageActionId]);

GO

CREATE INDEX [IX_Messages_MessageIndicatorId] ON [Messages] ([MessageIndicatorId]);

GO

CREATE INDEX [IX_Messages_MessageQuoteId] ON [Messages] ([MessageQuoteId]);

GO

CREATE INDEX [IX_Messages_MessageStatusId] ON [Messages] ([MessageStatusId]);

GO

CREATE INDEX [IX_Messages_MessageTypeId] ON [Messages] ([MessageTypeId]);

GO

CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);

GO

CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);

GO

CREATE INDEX [IX_Mobilizations_AppUserId] ON [Mobilizations] ([AppUserId]);

GO

CREATE INDEX [IX_Mobilizations_MobilizationStatusId] ON [Mobilizations] ([MobilizationStatusId]);

GO

CREATE INDEX [IX_Mobilizations_PlotId] ON [Mobilizations] ([PlotId]);

GO

CREATE UNIQUE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

CREATE INDEX [IX_NextOfKins_GenderId] ON [NextOfKins] ([GenderId]);

GO

CREATE INDEX [IX_Offers_OfferStatusId] ON [Offers] ([OfferStatusId]);

GO

CREATE INDEX [IX_Offers_PlotId] ON [Offers] ([PlotId]);

GO

CREATE INDEX [IX_OTPs_AppUserId] ON [OTPs] ([AppUserId]);

GO

CREATE INDEX [IX_OTPs_PlatformId] ON [OTPs] ([PlatformId]);

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

CREATE INDEX [IX_Payments_SubscriptionId] ON [Payments] ([SubscriptionId]);

GO

CREATE INDEX [IX_Permits_AppUserId] ON [Permits] ([AppUserId]);

GO

CREATE INDEX [IX_Permits_PermitStatusId] ON [Permits] ([PermitStatusId]);

GO

CREATE INDEX [IX_Permits_PermitTypeId] ON [Permits] ([PermitTypeId]);

GO

CREATE INDEX [IX_Permits_VehicleId] ON [Permits] ([VehicleId]);

GO

CREATE INDEX [IX_Permits_VisitorId] ON [Permits] ([VisitorId]);

GO

CREATE INDEX [IX_Plots_AppUserId] ON [Plots] ([AppUserId]);

GO

CREATE INDEX [IX_Plots_PlotStatusId] ON [Plots] ([PlotStatusId]);

GO

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Proposals_AppUserId] ON [Proposals] ([AppUserId]);

GO

CREATE INDEX [IX_Proposals_JobId] ON [Proposals] ([JobId]);

GO

CREATE INDEX [IX_Proposals_ProposalStatusId] ON [Proposals] ([ProposalStatusId]);

GO

CREATE INDEX [IX_Requests_AppUserId] ON [Requests] ([AppUserId]);

GO

CREATE INDEX [IX_Requests_PlotId] ON [Requests] ([PlotId]);

GO

CREATE INDEX [IX_Requests_RequestStatusId] ON [Requests] ([RequestStatusId]);

GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_Subscriptions_SubscriptionStatusId] ON [Subscriptions] ([SubscriptionStatusId]);

GO

CREATE INDEX [IX_Vehicles_AppUserId] ON [Vehicles] ([AppUserId]);

GO

CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);

GO

CREATE INDEX [IX_Visitors_AppUserId] ON [Visitors] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_AppUserId] ON [WorkOrders] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_PlotId] ON [WorkOrders] ([PlotId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderStatusId] ON [WorkOrders] ([WorkOrderStatusId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderTypeId] ON [WorkOrders] ([WorkOrderTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210113200536_InitialMigration', N'3.1.8');

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

CREATE TABLE [CalendarEvents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CalendarEvents] PRIMARY KEY ([Id])
);

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

CREATE TABLE [DocumentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DocumentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ForumMessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ForumMessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [JobStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JobTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageAction] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageAction] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageIndicators] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Reference] nvarchar(max) NULL,
    [IsEnded] bit NOT NULL,
    CONSTRAINT [PK_MessageIndicators] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [PermitStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitStatuses] PRIMARY KEY ([Id])
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

CREATE TABLE [Platforms] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY ([Id])
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

CREATE TABLE [PlotTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProposalStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ProposalStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RequestStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_RequestStatuses] PRIMARY KEY ([Id])
);

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

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
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

CREATE TABLE [VehicleTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [WorkOrderTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderTypes] PRIMARY KEY ([Id])
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

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [ContactTypeId] int NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE CASCADE
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
    [ForumId] int NULL,
    [ForumMessageTypeId] int NOT NULL,
    CONSTRAINT [PK_ForumMessages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageTypes] ([Id]) ON DELETE CASCADE
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
    [GUID] nvarchar(max) NULL,
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
    [OrganizationTypeId] int NULL,
    [StateId] int NULL,
    [HasUploadedDocument] bit NOT NULL,
    [HasUploadedProfilePhoto] bit NOT NULL,
    [EntryName] nvarchar(max) NULL,
    [RCNumber] nvarchar(max) NULL,
    [OfficeAddress] nvarchar(max) NULL,
    [WebsiteUrl] nvarchar(max) NULL,
    [IsExisting] bit NOT NULL,
    [FireBaseToken] nvarchar(max) NULL,
    [UserTypeId] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [JobTypeId] int NOT NULL,
    [JobStatusId] int NOT NULL,
    [AppUserId] int NULL,
    [ValidityPeriod] datetime2 NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jobs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Jobs_JobStatuses_JobStatusId] FOREIGN KEY ([JobStatusId]) REFERENCES [JobStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_JobTypes_JobTypeId] FOREIGN KEY ([JobTypeId]) REFERENCES [JobTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Text] nvarchar(max) NULL,
    [MessageIndicatorId] int NULL,
    [SenderId] int NOT NULL,
    [ReceiverId] int NULL,
    [MessageTypeId] int NOT NULL,
    [MessageStatusId] int NOT NULL,
    [MessageQuoteId] int NULL,
    [Indicator] nvarchar(max) NULL,
    [MessageActionId] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_MessageAction_MessageActionId] FOREIGN KEY ([MessageActionId]) REFERENCES [MessageAction] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageIndicators_MessageIndicatorId] FOREIGN KEY ([MessageIndicatorId]) REFERENCES [MessageIndicators] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_Messages_MessageQuoteId] FOREIGN KEY ([MessageQuoteId]) REFERENCES [Messages] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_MessageStatuses_MessageStatusId] FOREIGN KEY ([MessageStatusId]) REFERENCES [MessageStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageTypes_MessageTypeId] FOREIGN KEY ([MessageTypeId]) REFERENCES [MessageTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
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
    [MailingAddress] nvarchar(max) NULL,
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
    [CodeSlug] nvarchar(max) NULL,
    [PlatformId] int NULL,
    [IsExpired] bit NOT NULL,
    [IsUsed] bit NOT NULL,
    [ExpiryDateTime] datetime2 NOT NULL,
    [UsedDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_OTPs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OTPs_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms] ([Id]) ON DELETE NO ACTION
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
    [IsPaymentComplete] bit NOT NULL,
    [PlotStatusId] int NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotStatus_PlotStatusId] FOREIGN KEY ([PlotStatusId]) REFERENCES [PlotStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Vehicles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [Make] nvarchar(max) NULL,
    [PlateNumber] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    [VehicleTypeId] int NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vehicles_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Visitors] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Address] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Visitors_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Proposals] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [JobId] int NOT NULL,
    [AppUserId] int NOT NULL,
    [ProposalStatusId] int NOT NULL,
    CONSTRAINT [PK_Proposals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Proposals_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_ProposalStatuses_ProposalStatusId] FOREIGN KEY ([ProposalStatusId]) REFERENCES [ProposalStatuses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Calendars] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [CalendarEventId] int NOT NULL,
    [PlotId] int NOT NULL,
    [Location] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Calendars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Calendars_CalendarEvents_CalendarEventId] FOREIGN KEY ([CalendarEventId]) REFERENCES [CalendarEvents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calendars_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [DocumentTypeId] int NOT NULL,
    [PlotId] int NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Mobilizations] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [PlotId] int NOT NULL,
    [AppUserId] int NULL,
    [LeadName] nvarchar(max) NULL,
    [LeadPhoneNumber] nvarchar(max) NULL,
    [NumberOfWorkers] int NOT NULL,
    [IdentityPath] nvarchar(max) NULL,
    [MobilizationStatusId] int NULL,
    CONSTRAINT [PK_Mobilizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilizations_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_MobilizationStatuses_MobilizationStatusId] FOREIGN KEY ([MobilizationStatusId]) REFERENCES [MobilizationStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
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

CREATE TABLE [Requests] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [RequestTypeId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [PlotId] int NULL,
    [RequestStatusId] int NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requests_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [RequestStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkOrders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NULL,
    [PlotId] int NOT NULL,
    [WorkOrderTypeId] int NOT NULL,
    [Document] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [WorkOrderStatusId] int NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkOrders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId] FOREIGN KEY ([WorkOrderStatusId]) REFERENCES [WorkOrderStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId] FOREIGN KEY ([WorkOrderTypeId]) REFERENCES [WorkOrderTypes] ([Id]) ON DELETE CASCADE
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
    [PermitStatusId] int NOT NULL,
    CONSTRAINT [PK_Permits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permits_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitStatuses_PermitStatusId] FOREIGN KEY ([PermitStatusId]) REFERENCES [PermitStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitTypes_PermitTypeId] FOREIGN KEY ([PermitTypeId]) REFERENCES [PermitTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Permits_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id]) ON DELETE NO ACTION
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
    [SubscriptionStatusId] int NOT NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId] FOREIGN KEY ([SubscriptionStatusId]) REFERENCES [SubscriptionStatuses] ([Id]) ON DELETE CASCADE
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
    [SubscriptionId] int NOT NULL,
    [TrnxRef] nvarchar(max) NULL,
    [OfferId] int NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentProviders_PaymentProviderId] FOREIGN KEY ([PaymentProviderId]) REFERENCES [PaymentProviders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentStatuses_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentTypes_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [IX_AspNetUsers_OrganizationTypeId] ON [AspNetUsers] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_AspNetUsers_StateId] ON [AspNetUsers] ([StateId]);

GO

CREATE INDEX [IX_Calendars_CalendarEventId] ON [Calendars] ([CalendarEventId]);

GO

CREATE INDEX [IX_Calendars_PlotId] ON [Calendars] ([PlotId]);

GO

CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

CREATE INDEX [IX_Documents_DocumentTypeId] ON [Documents] ([DocumentTypeId]);

GO

CREATE INDEX [IX_Documents_PlotId] ON [Documents] ([PlotId]);

GO

CREATE INDEX [IX_ForumMessages_ForumId] ON [ForumMessages] ([ForumId]);

GO

CREATE INDEX [IX_ForumMessages_ForumMessageTypeId] ON [ForumMessages] ([ForumMessageTypeId]);

GO

CREATE INDEX [IX_ForumSubscriptions_AppUserId] ON [ForumSubscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_ForumSubscriptions_ForumId] ON [ForumSubscriptions] ([ForumId]);

GO

CREATE INDEX [IX_Jobs_AppUserId] ON [Jobs] ([AppUserId]);

GO

CREATE INDEX [IX_Jobs_JobStatusId] ON [Jobs] ([JobStatusId]);

GO

CREATE INDEX [IX_Jobs_JobTypeId] ON [Jobs] ([JobTypeId]);

GO

CREATE INDEX [IX_Messages_MessageActionId] ON [Messages] ([MessageActionId]);

GO

CREATE INDEX [IX_Messages_MessageIndicatorId] ON [Messages] ([MessageIndicatorId]);

GO

CREATE INDEX [IX_Messages_MessageQuoteId] ON [Messages] ([MessageQuoteId]);

GO

CREATE INDEX [IX_Messages_MessageStatusId] ON [Messages] ([MessageStatusId]);

GO

CREATE INDEX [IX_Messages_MessageTypeId] ON [Messages] ([MessageTypeId]);

GO

CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);

GO

CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);

GO

CREATE INDEX [IX_Mobilizations_AppUserId] ON [Mobilizations] ([AppUserId]);

GO

CREATE INDEX [IX_Mobilizations_MobilizationStatusId] ON [Mobilizations] ([MobilizationStatusId]);

GO

CREATE INDEX [IX_Mobilizations_PlotId] ON [Mobilizations] ([PlotId]);

GO

CREATE UNIQUE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

CREATE INDEX [IX_NextOfKins_GenderId] ON [NextOfKins] ([GenderId]);

GO

CREATE INDEX [IX_Offers_OfferStatusId] ON [Offers] ([OfferStatusId]);

GO

CREATE INDEX [IX_Offers_PlotId] ON [Offers] ([PlotId]);

GO

CREATE INDEX [IX_OTPs_AppUserId] ON [OTPs] ([AppUserId]);

GO

CREATE INDEX [IX_OTPs_PlatformId] ON [OTPs] ([PlatformId]);

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

CREATE INDEX [IX_Payments_SubscriptionId] ON [Payments] ([SubscriptionId]);

GO

CREATE INDEX [IX_Permits_AppUserId] ON [Permits] ([AppUserId]);

GO

CREATE INDEX [IX_Permits_PermitStatusId] ON [Permits] ([PermitStatusId]);

GO

CREATE INDEX [IX_Permits_PermitTypeId] ON [Permits] ([PermitTypeId]);

GO

CREATE INDEX [IX_Permits_VehicleId] ON [Permits] ([VehicleId]);

GO

CREATE INDEX [IX_Permits_VisitorId] ON [Permits] ([VisitorId]);

GO

CREATE INDEX [IX_Plots_AppUserId] ON [Plots] ([AppUserId]);

GO

CREATE INDEX [IX_Plots_PlotStatusId] ON [Plots] ([PlotStatusId]);

GO

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Proposals_AppUserId] ON [Proposals] ([AppUserId]);

GO

CREATE INDEX [IX_Proposals_JobId] ON [Proposals] ([JobId]);

GO

CREATE INDEX [IX_Proposals_ProposalStatusId] ON [Proposals] ([ProposalStatusId]);

GO

CREATE INDEX [IX_Requests_AppUserId] ON [Requests] ([AppUserId]);

GO

CREATE INDEX [IX_Requests_PlotId] ON [Requests] ([PlotId]);

GO

CREATE INDEX [IX_Requests_RequestStatusId] ON [Requests] ([RequestStatusId]);

GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_Subscriptions_SubscriptionStatusId] ON [Subscriptions] ([SubscriptionStatusId]);

GO

CREATE INDEX [IX_Vehicles_AppUserId] ON [Vehicles] ([AppUserId]);

GO

CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);

GO

CREATE INDEX [IX_Visitors_AppUserId] ON [Visitors] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_AppUserId] ON [WorkOrders] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_PlotId] ON [WorkOrders] ([PlotId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderStatusId] ON [WorkOrders] ([WorkOrderStatusId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderTypeId] ON [WorkOrders] ([WorkOrderTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210117013321_UserTypeId', N'3.1.8');

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

CREATE TABLE [CalendarEvents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CalendarEvents] PRIMARY KEY ([Id])
);

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

CREATE TABLE [DocumentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DocumentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ForumMessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ForumMessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [JobStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JobTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageAction] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageAction] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageIndicators] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Reference] nvarchar(max) NULL,
    [IsEnded] bit NOT NULL,
    CONSTRAINT [PK_MessageIndicators] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [PermitStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitStatuses] PRIMARY KEY ([Id])
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

CREATE TABLE [Platforms] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY ([Id])
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

CREATE TABLE [PlotTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProposalStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ProposalStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RequestStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_RequestStatuses] PRIMARY KEY ([Id])
);

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

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
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

CREATE TABLE [VehicleTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [WorkOrderTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderTypes] PRIMARY KEY ([Id])
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

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [ContactTypeId] int NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE CASCADE
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
    [ForumId] int NULL,
    [ForumMessageTypeId] int NOT NULL,
    CONSTRAINT [PK_ForumMessages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageTypes] ([Id]) ON DELETE CASCADE
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
    [GUID] nvarchar(max) NULL,
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
    [OrganizationTypeId] int NULL,
    [StateId] int NULL,
    [HasUploadedDocument] bit NOT NULL,
    [HasUploadedProfilePhoto] bit NOT NULL,
    [EntryName] nvarchar(max) NULL,
    [RCNumber] nvarchar(max) NULL,
    [OfficeAddress] nvarchar(max) NULL,
    [WebsiteUrl] nvarchar(max) NULL,
    [IsExisting] bit NOT NULL,
    [FireBaseToken] nvarchar(max) NULL,
    [UserTypeId] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [JobTypeId] int NOT NULL,
    [JobStatusId] int NOT NULL,
    [AppUserId] int NULL,
    [ValidityPeriod] datetime2 NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jobs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Jobs_JobStatuses_JobStatusId] FOREIGN KEY ([JobStatusId]) REFERENCES [JobStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_JobTypes_JobTypeId] FOREIGN KEY ([JobTypeId]) REFERENCES [JobTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Text] nvarchar(max) NULL,
    [MessageIndicatorId] int NULL,
    [SenderId] int NOT NULL,
    [ReceiverId] int NULL,
    [MessageTypeId] int NOT NULL,
    [MessageStatusId] int NOT NULL,
    [MessageQuoteId] int NULL,
    [Indicator] nvarchar(max) NULL,
    [MessageActionId] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_MessageAction_MessageActionId] FOREIGN KEY ([MessageActionId]) REFERENCES [MessageAction] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageIndicators_MessageIndicatorId] FOREIGN KEY ([MessageIndicatorId]) REFERENCES [MessageIndicators] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_Messages_MessageQuoteId] FOREIGN KEY ([MessageQuoteId]) REFERENCES [Messages] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_MessageStatuses_MessageStatusId] FOREIGN KEY ([MessageStatusId]) REFERENCES [MessageStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageTypes_MessageTypeId] FOREIGN KEY ([MessageTypeId]) REFERENCES [MessageTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
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
    [MailingAddress] nvarchar(max) NULL,
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
    [CodeSlug] nvarchar(max) NULL,
    [PlatformId] int NULL,
    [IsExpired] bit NOT NULL,
    [IsUsed] bit NOT NULL,
    [ExpiryDateTime] datetime2 NOT NULL,
    [UsedDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_OTPs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OTPs_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms] ([Id]) ON DELETE NO ACTION
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
    [IsPaymentComplete] bit NOT NULL,
    [PlotStatusId] int NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotStatus_PlotStatusId] FOREIGN KEY ([PlotStatusId]) REFERENCES [PlotStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Vehicles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [Make] nvarchar(max) NULL,
    [PlateNumber] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    [VehicleTypeId] int NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vehicles_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Visitors] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Address] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Visitors_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Proposals] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [JobId] int NOT NULL,
    [AppUserId] int NOT NULL,
    [ProposalStatusId] int NOT NULL,
    CONSTRAINT [PK_Proposals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Proposals_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_ProposalStatuses_ProposalStatusId] FOREIGN KEY ([ProposalStatusId]) REFERENCES [ProposalStatuses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Calendars] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [CalendarEventId] int NOT NULL,
    [PlotId] int NOT NULL,
    [Location] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Calendars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Calendars_CalendarEvents_CalendarEventId] FOREIGN KEY ([CalendarEventId]) REFERENCES [CalendarEvents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calendars_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [DocumentTypeId] int NOT NULL,
    [PlotId] int NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Mobilizations] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [PlotId] int NOT NULL,
    [AppUserId] int NULL,
    [LeadName] nvarchar(max) NULL,
    [LeadPhoneNumber] nvarchar(max) NULL,
    [NumberOfWorkers] int NOT NULL,
    [IdentityPath] nvarchar(max) NULL,
    [MobilizationStatusId] int NULL,
    CONSTRAINT [PK_Mobilizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilizations_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_MobilizationStatuses_MobilizationStatusId] FOREIGN KEY ([MobilizationStatusId]) REFERENCES [MobilizationStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
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

CREATE TABLE [Requests] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [RequestTypeId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [PlotId] int NULL,
    [RequestStatusId] int NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requests_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [RequestStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkOrders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NULL,
    [PlotId] int NOT NULL,
    [WorkOrderTypeId] int NOT NULL,
    [Document] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [WorkOrderStatusId] int NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkOrders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId] FOREIGN KEY ([WorkOrderStatusId]) REFERENCES [WorkOrderStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId] FOREIGN KEY ([WorkOrderTypeId]) REFERENCES [WorkOrderTypes] ([Id]) ON DELETE CASCADE
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
    [PermitStatusId] int NOT NULL,
    CONSTRAINT [PK_Permits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permits_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitStatuses_PermitStatusId] FOREIGN KEY ([PermitStatusId]) REFERENCES [PermitStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitTypes_PermitTypeId] FOREIGN KEY ([PermitTypeId]) REFERENCES [PermitTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Permits_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id]) ON DELETE NO ACTION
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
    [SubscriptionStatusId] int NOT NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId] FOREIGN KEY ([SubscriptionStatusId]) REFERENCES [SubscriptionStatuses] ([Id]) ON DELETE CASCADE
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
    [SubscriptionId] int NOT NULL,
    [TrnxRef] nvarchar(max) NULL,
    [OfferId] int NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentProviders_PaymentProviderId] FOREIGN KEY ([PaymentProviderId]) REFERENCES [PaymentProviders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentStatuses_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentTypes_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [IX_AspNetUsers_OrganizationTypeId] ON [AspNetUsers] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_AspNetUsers_StateId] ON [AspNetUsers] ([StateId]);

GO

CREATE INDEX [IX_Calendars_CalendarEventId] ON [Calendars] ([CalendarEventId]);

GO

CREATE INDEX [IX_Calendars_PlotId] ON [Calendars] ([PlotId]);

GO

CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

CREATE INDEX [IX_Documents_DocumentTypeId] ON [Documents] ([DocumentTypeId]);

GO

CREATE INDEX [IX_Documents_PlotId] ON [Documents] ([PlotId]);

GO

CREATE INDEX [IX_ForumMessages_ForumId] ON [ForumMessages] ([ForumId]);

GO

CREATE INDEX [IX_ForumMessages_ForumMessageTypeId] ON [ForumMessages] ([ForumMessageTypeId]);

GO

CREATE INDEX [IX_ForumSubscriptions_AppUserId] ON [ForumSubscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_ForumSubscriptions_ForumId] ON [ForumSubscriptions] ([ForumId]);

GO

CREATE INDEX [IX_Jobs_AppUserId] ON [Jobs] ([AppUserId]);

GO

CREATE INDEX [IX_Jobs_JobStatusId] ON [Jobs] ([JobStatusId]);

GO

CREATE INDEX [IX_Jobs_JobTypeId] ON [Jobs] ([JobTypeId]);

GO

CREATE INDEX [IX_Messages_MessageActionId] ON [Messages] ([MessageActionId]);

GO

CREATE INDEX [IX_Messages_MessageIndicatorId] ON [Messages] ([MessageIndicatorId]);

GO

CREATE INDEX [IX_Messages_MessageQuoteId] ON [Messages] ([MessageQuoteId]);

GO

CREATE INDEX [IX_Messages_MessageStatusId] ON [Messages] ([MessageStatusId]);

GO

CREATE INDEX [IX_Messages_MessageTypeId] ON [Messages] ([MessageTypeId]);

GO

CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);

GO

CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);

GO

CREATE INDEX [IX_Mobilizations_AppUserId] ON [Mobilizations] ([AppUserId]);

GO

CREATE INDEX [IX_Mobilizations_MobilizationStatusId] ON [Mobilizations] ([MobilizationStatusId]);

GO

CREATE INDEX [IX_Mobilizations_PlotId] ON [Mobilizations] ([PlotId]);

GO

CREATE UNIQUE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

CREATE INDEX [IX_NextOfKins_GenderId] ON [NextOfKins] ([GenderId]);

GO

CREATE INDEX [IX_Offers_OfferStatusId] ON [Offers] ([OfferStatusId]);

GO

CREATE INDEX [IX_Offers_PlotId] ON [Offers] ([PlotId]);

GO

CREATE INDEX [IX_OTPs_AppUserId] ON [OTPs] ([AppUserId]);

GO

CREATE INDEX [IX_OTPs_PlatformId] ON [OTPs] ([PlatformId]);

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

CREATE INDEX [IX_Payments_SubscriptionId] ON [Payments] ([SubscriptionId]);

GO

CREATE INDEX [IX_Permits_AppUserId] ON [Permits] ([AppUserId]);

GO

CREATE INDEX [IX_Permits_PermitStatusId] ON [Permits] ([PermitStatusId]);

GO

CREATE INDEX [IX_Permits_PermitTypeId] ON [Permits] ([PermitTypeId]);

GO

CREATE INDEX [IX_Permits_VehicleId] ON [Permits] ([VehicleId]);

GO

CREATE INDEX [IX_Permits_VisitorId] ON [Permits] ([VisitorId]);

GO

CREATE INDEX [IX_Plots_AppUserId] ON [Plots] ([AppUserId]);

GO

CREATE INDEX [IX_Plots_PlotStatusId] ON [Plots] ([PlotStatusId]);

GO

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Proposals_AppUserId] ON [Proposals] ([AppUserId]);

GO

CREATE INDEX [IX_Proposals_JobId] ON [Proposals] ([JobId]);

GO

CREATE INDEX [IX_Proposals_ProposalStatusId] ON [Proposals] ([ProposalStatusId]);

GO

CREATE INDEX [IX_Requests_AppUserId] ON [Requests] ([AppUserId]);

GO

CREATE INDEX [IX_Requests_PlotId] ON [Requests] ([PlotId]);

GO

CREATE INDEX [IX_Requests_RequestStatusId] ON [Requests] ([RequestStatusId]);

GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_Subscriptions_SubscriptionStatusId] ON [Subscriptions] ([SubscriptionStatusId]);

GO

CREATE INDEX [IX_Vehicles_AppUserId] ON [Vehicles] ([AppUserId]);

GO

CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);

GO

CREATE INDEX [IX_Visitors_AppUserId] ON [Visitors] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_AppUserId] ON [WorkOrders] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_PlotId] ON [WorkOrders] ([PlotId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderStatusId] ON [WorkOrders] ([WorkOrderStatusId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderTypeId] ON [WorkOrders] ([WorkOrderTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210117013910_UserTypeMigrationId', N'3.1.8');

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

CREATE TABLE [CalendarEvents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_CalendarEvents] PRIMARY KEY ([Id])
);

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

CREATE TABLE [DocumentStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [DocumentTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ForumMessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ForumMessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [JobStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [JobTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_JobTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageAction] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageAction] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageIndicators] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [Reference] nvarchar(max) NULL,
    [IsEnded] bit NOT NULL,
    CONSTRAINT [PK_MessageIndicators] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [MessageTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_MessageTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [PermitStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PermitStatuses] PRIMARY KEY ([Id])
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

CREATE TABLE [Platforms] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY ([Id])
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

CREATE TABLE [PlotTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PlotTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [ProposalStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_ProposalStatuses] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [RequestStatuses] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_RequestStatuses] PRIMARY KEY ([Id])
);

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

CREATE TABLE [States] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Id])
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

CREATE TABLE [VehicleTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([Id])
);

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

CREATE TABLE [WorkOrderTypes] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_WorkOrderTypes] PRIMARY KEY ([Id])
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

CREATE TABLE [Contacts] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [ContactTypeId] int NOT NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contacts_ContactTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [ContactTypes] ([Id]) ON DELETE CASCADE
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
    [ForumId] int NULL,
    [ForumMessageTypeId] int NOT NULL,
    CONSTRAINT [PK_ForumMessages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ForumMessages_Forums_ForumId] FOREIGN KEY ([ForumId]) REFERENCES [Forums] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ForumMessages_ForumMessageTypes_ForumMessageTypeId] FOREIGN KEY ([ForumMessageTypeId]) REFERENCES [ForumMessageTypes] ([Id]) ON DELETE CASCADE
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
    [GUID] nvarchar(max) NULL,
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
    [OrganizationTypeId] int NULL,
    [StateId] int NULL,
    [HasUploadedDocument] bit NOT NULL,
    [HasUploadedProfilePhoto] bit NOT NULL,
    [EntryName] nvarchar(max) NULL,
    [RCNumber] nvarchar(max) NULL,
    [OfficeAddress] nvarchar(max) NULL,
    [WebsiteUrl] nvarchar(max) NULL,
    [IsExisting] bit NOT NULL,
    [FireBaseToken] nvarchar(max) NULL,
    [UserTypeId] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [Genders] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_Identification_IdentificationId] FOREIGN KEY ([IdentificationId]) REFERENCES [Identification] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AspNetUsers_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
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

CREATE TABLE [Jobs] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [JobTypeId] int NOT NULL,
    [JobStatusId] int NOT NULL,
    [AppUserId] int NULL,
    [ValidityPeriod] datetime2 NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Jobs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Jobs_JobStatuses_JobStatusId] FOREIGN KEY ([JobStatusId]) REFERENCES [JobStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Jobs_JobTypes_JobTypeId] FOREIGN KEY ([JobTypeId]) REFERENCES [JobTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Messages] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Text] nvarchar(max) NULL,
    [MessageIndicatorId] int NULL,
    [SenderId] int NOT NULL,
    [ReceiverId] int NULL,
    [MessageTypeId] int NOT NULL,
    [MessageStatusId] int NOT NULL,
    [MessageQuoteId] int NULL,
    [Indicator] nvarchar(max) NULL,
    [MessageActionId] int NOT NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Messages_MessageAction_MessageActionId] FOREIGN KEY ([MessageActionId]) REFERENCES [MessageAction] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageIndicators_MessageIndicatorId] FOREIGN KEY ([MessageIndicatorId]) REFERENCES [MessageIndicators] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_Messages_MessageQuoteId] FOREIGN KEY ([MessageQuoteId]) REFERENCES [Messages] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_MessageStatuses_MessageStatusId] FOREIGN KEY ([MessageStatusId]) REFERENCES [MessageStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_MessageTypes_MessageTypeId] FOREIGN KEY ([MessageTypeId]) REFERENCES [MessageTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Messages_AspNetUsers_ReceiverId] FOREIGN KEY ([ReceiverId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Messages_AspNetUsers_SenderId] FOREIGN KEY ([SenderId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
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
    [MailingAddress] nvarchar(max) NULL,
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
    [CodeSlug] nvarchar(max) NULL,
    [PlatformId] int NULL,
    [IsExpired] bit NOT NULL,
    [IsUsed] bit NOT NULL,
    [ExpiryDateTime] datetime2 NOT NULL,
    [UsedDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_OTPs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OTPs_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OTPs_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [Platforms] ([Id]) ON DELETE NO ACTION
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
    [IsPaymentComplete] bit NOT NULL,
    [PlotStatusId] int NULL,
    [Price] float NOT NULL,
    CONSTRAINT [PK_Plots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Plots_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotStatus_PlotStatusId] FOREIGN KEY ([PlotStatusId]) REFERENCES [PlotStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Plots_PlotTypes_PlotTypeId] FOREIGN KEY ([PlotTypeId]) REFERENCES [PlotTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Vehicles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [Make] nvarchar(max) NULL,
    [PlateNumber] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    [VehicleTypeId] int NOT NULL,
    CONSTRAINT [PK_Vehicles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vehicles_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Visitors] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Address] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [EmailAddress] nvarchar(max) NULL,
    [CheckInDateTime] datetime2 NOT NULL,
    [CheckOutDateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Visitors] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Visitors_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Proposals] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [JobId] int NOT NULL,
    [AppUserId] int NOT NULL,
    [ProposalStatusId] int NOT NULL,
    CONSTRAINT [PK_Proposals] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Proposals_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_Jobs_JobId] FOREIGN KEY ([JobId]) REFERENCES [Jobs] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Proposals_ProposalStatuses_ProposalStatusId] FOREIGN KEY ([ProposalStatusId]) REFERENCES [ProposalStatuses] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Calendars] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Title] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [CalendarEventId] int NOT NULL,
    [PlotId] int NOT NULL,
    [Location] nvarchar(max) NULL,
    [Name] nvarchar(max) NULL,
    [StartDate] datetime2 NOT NULL,
    [EndDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Calendars] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Calendars_CalendarEvents_CalendarEventId] FOREIGN KEY ([CalendarEventId]) REFERENCES [CalendarEvents] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Calendars_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Documents] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [AppUserId] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [DocumentTypeId] int NOT NULL,
    [PlotId] int NULL,
    CONSTRAINT [PK_Documents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Documents_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [DocumentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Documents_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Mobilizations] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [PlotId] int NOT NULL,
    [AppUserId] int NULL,
    [LeadName] nvarchar(max) NULL,
    [LeadPhoneNumber] nvarchar(max) NULL,
    [NumberOfWorkers] int NOT NULL,
    [IdentityPath] nvarchar(max) NULL,
    [MobilizationStatusId] int NULL,
    CONSTRAINT [PK_Mobilizations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mobilizations_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_MobilizationStatuses_MobilizationStatusId] FOREIGN KEY ([MobilizationStatusId]) REFERENCES [MobilizationStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mobilizations_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE
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

CREATE TABLE [Requests] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NOT NULL,
    [RequestTypeId] int NOT NULL,
    [Description] nvarchar(max) NULL,
    [PlotId] int NULL,
    [RequestStatusId] int NULL,
    CONSTRAINT [PK_Requests] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Requests_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Requests_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestStatuses_RequestStatusId] FOREIGN KEY ([RequestStatusId]) REFERENCES [RequestStatuses] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Requests_RequestTypes_RequestTypeId] FOREIGN KEY ([RequestTypeId]) REFERENCES [RequestTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [WorkOrders] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    [AppUserId] int NULL,
    [PlotId] int NOT NULL,
    [WorkOrderTypeId] int NOT NULL,
    [Document] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [WorkOrderStatusId] int NULL,
    CONSTRAINT [PK_WorkOrders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_WorkOrders_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_Plots_PlotId] FOREIGN KEY ([PlotId]) REFERENCES [Plots] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_WorkOrders_WorkOrderStatus_WorkOrderStatusId] FOREIGN KEY ([WorkOrderStatusId]) REFERENCES [WorkOrderStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_WorkOrders_WorkOrderTypes_WorkOrderTypeId] FOREIGN KEY ([WorkOrderTypeId]) REFERENCES [WorkOrderTypes] ([Id]) ON DELETE CASCADE
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
    [PermitStatusId] int NOT NULL,
    CONSTRAINT [PK_Permits] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Permits_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitStatuses_PermitStatusId] FOREIGN KEY ([PermitStatusId]) REFERENCES [PermitStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_PermitTypes_PermitTypeId] FOREIGN KEY ([PermitTypeId]) REFERENCES [PermitTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Permits_Vehicles_VehicleId] FOREIGN KEY ([VehicleId]) REFERENCES [Vehicles] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Permits_Visitors_VisitorId] FOREIGN KEY ([VisitorId]) REFERENCES [Visitors] ([Id]) ON DELETE NO ACTION
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
    [SubscriptionStatusId] int NOT NULL,
    CONSTRAINT [PK_Subscriptions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Subscriptions_AspNetUsers_AppUserId] FOREIGN KEY ([AppUserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_OrganizationTypes_OrganizationTypeId] FOREIGN KEY ([OrganizationTypeId]) REFERENCES [OrganizationTypes] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Subscriptions_SubscriptionStatuses_SubscriptionStatusId] FOREIGN KEY ([SubscriptionStatusId]) REFERENCES [SubscriptionStatuses] ([Id]) ON DELETE CASCADE
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
    [SubscriptionId] int NOT NULL,
    [TrnxRef] nvarchar(max) NULL,
    [OfferId] int NULL,
    CONSTRAINT [PK_Payments] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Payments_Offers_OfferId] FOREIGN KEY ([OfferId]) REFERENCES [Offers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Payments_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [PaymentMethods] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentProviders_PaymentProviderId] FOREIGN KEY ([PaymentProviderId]) REFERENCES [PaymentProviders] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentStatuses_PaymentStatusId] FOREIGN KEY ([PaymentStatusId]) REFERENCES [PaymentStatuses] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_PaymentTypes_PaymentTypeId] FOREIGN KEY ([PaymentTypeId]) REFERENCES [PaymentTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Payments_Subscriptions_SubscriptionId] FOREIGN KEY ([SubscriptionId]) REFERENCES [Subscriptions] ([Id]) ON DELETE CASCADE
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

CREATE INDEX [IX_AspNetUsers_OrganizationTypeId] ON [AspNetUsers] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_AspNetUsers_StateId] ON [AspNetUsers] ([StateId]);

GO

CREATE INDEX [IX_Calendars_CalendarEventId] ON [Calendars] ([CalendarEventId]);

GO

CREATE INDEX [IX_Calendars_PlotId] ON [Calendars] ([PlotId]);

GO

CREATE INDEX [IX_Contacts_ContactTypeId] ON [Contacts] ([ContactTypeId]);

GO

CREATE INDEX [IX_Documents_AppUserId] ON [Documents] ([AppUserId]);

GO

CREATE INDEX [IX_Documents_DocumentTypeId] ON [Documents] ([DocumentTypeId]);

GO

CREATE INDEX [IX_Documents_PlotId] ON [Documents] ([PlotId]);

GO

CREATE INDEX [IX_ForumMessages_ForumId] ON [ForumMessages] ([ForumId]);

GO

CREATE INDEX [IX_ForumMessages_ForumMessageTypeId] ON [ForumMessages] ([ForumMessageTypeId]);

GO

CREATE INDEX [IX_ForumSubscriptions_AppUserId] ON [ForumSubscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_ForumSubscriptions_ForumId] ON [ForumSubscriptions] ([ForumId]);

GO

CREATE INDEX [IX_Jobs_AppUserId] ON [Jobs] ([AppUserId]);

GO

CREATE INDEX [IX_Jobs_JobStatusId] ON [Jobs] ([JobStatusId]);

GO

CREATE INDEX [IX_Jobs_JobTypeId] ON [Jobs] ([JobTypeId]);

GO

CREATE INDEX [IX_Messages_MessageActionId] ON [Messages] ([MessageActionId]);

GO

CREATE INDEX [IX_Messages_MessageIndicatorId] ON [Messages] ([MessageIndicatorId]);

GO

CREATE INDEX [IX_Messages_MessageQuoteId] ON [Messages] ([MessageQuoteId]);

GO

CREATE INDEX [IX_Messages_MessageStatusId] ON [Messages] ([MessageStatusId]);

GO

CREATE INDEX [IX_Messages_MessageTypeId] ON [Messages] ([MessageTypeId]);

GO

CREATE INDEX [IX_Messages_ReceiverId] ON [Messages] ([ReceiverId]);

GO

CREATE INDEX [IX_Messages_SenderId] ON [Messages] ([SenderId]);

GO

CREATE INDEX [IX_Mobilizations_AppUserId] ON [Mobilizations] ([AppUserId]);

GO

CREATE INDEX [IX_Mobilizations_MobilizationStatusId] ON [Mobilizations] ([MobilizationStatusId]);

GO

CREATE INDEX [IX_Mobilizations_PlotId] ON [Mobilizations] ([PlotId]);

GO

CREATE UNIQUE INDEX [IX_NextOfKins_AppUserId] ON [NextOfKins] ([AppUserId]);

GO

CREATE INDEX [IX_NextOfKins_GenderId] ON [NextOfKins] ([GenderId]);

GO

CREATE INDEX [IX_Offers_OfferStatusId] ON [Offers] ([OfferStatusId]);

GO

CREATE INDEX [IX_Offers_PlotId] ON [Offers] ([PlotId]);

GO

CREATE INDEX [IX_OTPs_AppUserId] ON [OTPs] ([AppUserId]);

GO

CREATE INDEX [IX_OTPs_PlatformId] ON [OTPs] ([PlatformId]);

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

CREATE INDEX [IX_Payments_SubscriptionId] ON [Payments] ([SubscriptionId]);

GO

CREATE INDEX [IX_Permits_AppUserId] ON [Permits] ([AppUserId]);

GO

CREATE INDEX [IX_Permits_PermitStatusId] ON [Permits] ([PermitStatusId]);

GO

CREATE INDEX [IX_Permits_PermitTypeId] ON [Permits] ([PermitTypeId]);

GO

CREATE INDEX [IX_Permits_VehicleId] ON [Permits] ([VehicleId]);

GO

CREATE INDEX [IX_Permits_VisitorId] ON [Permits] ([VisitorId]);

GO

CREATE INDEX [IX_Plots_AppUserId] ON [Plots] ([AppUserId]);

GO

CREATE INDEX [IX_Plots_PlotStatusId] ON [Plots] ([PlotStatusId]);

GO

CREATE INDEX [IX_Plots_PlotTypeId] ON [Plots] ([PlotTypeId]);

GO

CREATE INDEX [IX_Proposals_AppUserId] ON [Proposals] ([AppUserId]);

GO

CREATE INDEX [IX_Proposals_JobId] ON [Proposals] ([JobId]);

GO

CREATE INDEX [IX_Proposals_ProposalStatusId] ON [Proposals] ([ProposalStatusId]);

GO

CREATE INDEX [IX_Requests_AppUserId] ON [Requests] ([AppUserId]);

GO

CREATE INDEX [IX_Requests_PlotId] ON [Requests] ([PlotId]);

GO

CREATE INDEX [IX_Requests_RequestStatusId] ON [Requests] ([RequestStatusId]);

GO

CREATE INDEX [IX_Requests_RequestTypeId] ON [Requests] ([RequestTypeId]);

GO

CREATE INDEX [IX_Subscriptions_AppUserId] ON [Subscriptions] ([AppUserId]);

GO

CREATE INDEX [IX_Subscriptions_OfferId] ON [Subscriptions] ([OfferId]);

GO

CREATE INDEX [IX_Subscriptions_OrganizationTypeId] ON [Subscriptions] ([OrganizationTypeId]);

GO

CREATE INDEX [IX_Subscriptions_SubscriptionStatusId] ON [Subscriptions] ([SubscriptionStatusId]);

GO

CREATE INDEX [IX_Vehicles_AppUserId] ON [Vehicles] ([AppUserId]);

GO

CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);

GO

CREATE INDEX [IX_Visitors_AppUserId] ON [Visitors] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_AppUserId] ON [WorkOrders] ([AppUserId]);

GO

CREATE INDEX [IX_WorkOrders_PlotId] ON [WorkOrders] ([PlotId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderStatusId] ON [WorkOrders] ([WorkOrderStatusId]);

GO

CREATE INDEX [IX_WorkOrders_WorkOrderTypeId] ON [WorkOrders] ([WorkOrderTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210117014203_UserTypeMigrationIdRun', N'3.1.8');

GO

