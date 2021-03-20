cd .. && cd home/documents/orangeisland && git pull && docker build -t orange . && docker stop oidc-be && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
git pull && docker build -t orange . && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
docker build -t orange . && docker run --rm -d -p 5000:80 -p 5001:443 -e ASPNETCORE_HTTPS_URL=https://+5001 -e ASPNETCORE_PORT=http://+5000 --name oidc-be orange && clear
npx localtunnel --port 8080 --print-requests


GO

ALTER TABLE [AspNetUsers] ADD [DepartmentId] int NULL DEFAULT NULL;

GO

CREATE INDEX [IX_AspNetUsers_DepartmentId] ON [AspNetUsers] ([DepartmentId]);

GO

ALTER TABLE [AspNetUsers] ADD CONSTRAINT [FK_AspNetUsers_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([Id]) ON DELETE CASCADE;

GO

GO


ALTER TABLE [Transactions] ADD [TotalAmount] float NOT NULL DEFAULT 0.0E0;

ALTER TABLE [Offer] ADD [IsInstalmentalPayment] BIT NOT NULL DEFAULT CAST(0 AS BIT)



===========================================================================================================
GO

CREATE TABLE [PaymentCycles] (
    [Id] int NOT NULL IDENTITY,
    [DateCreated] datetime2 NOT NULL,
    [DateModified] datetime2 NOT NULL,
    [IsEnabled] bit NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_PaymentCycles] PRIMARY KEY ([Id])
);

GO

ALTER TABLE [Offers] ADD [AdministrativeFee] FLOAT NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [Offers] ADD [LegalCharge] FLOAT NOT NULL DEFAULT 0.0E0;

GO

ALTER TABLE [Offers] ADD [IsInstalmentalPayment] BIT NOT NULL DEFAULT CAST(0 AS BIT);

GO

ALTER TABLE [Offers] ADD [InitialPaymentPercentage] INT NOT NULL DEFAULT 0;

GO 

ALTER TABLE [Offers] ADD [PaymentCycleId] INT NULL DEFAULT NULL;

GO

CREATE INDEX [IX_Offers_PaymentCycleId] ON [PaymentCycles] ([PaymentCycleId]);

GO

ALTER TABLE [Offers] ADD CONSTRAINT [FK_Offers_PaymentCycles_PaymentCycleId] FOREIGN KEY ([PaymentCycleId]) REFERENCES [PaymentCycles] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Offers] ADD [PercentagePerCycle] INT NOT NULL DEFAULT 0;

GO

ALTER TABLE [Offers] ADD [PaymentInNumberOfMonths] INT NOT NULL DEFAULT 0;


===========================================================================================================

INSERT INTO [PaymentCycles] ([DateCreated], [DateModified], [IsEnabled], [Name])
VALUES (N'2020-10-10', N'2020-10-10', 1, N'MONTHLY')


 dotnet ef migrations add AccountMigrationAgain --verbose --project=WebAPI && dotnet ef migrations script --output WebAPI/Scripts/MigrationScript.sql --verbose --project=WebAPI