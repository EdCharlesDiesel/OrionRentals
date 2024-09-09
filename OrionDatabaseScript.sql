
GO
PRINT N'Creating [dbo].[Account]...';

CREATE TABLE [dbo].[Account] (
    [AccountId]  INT           IDENTITY (1, 1) NOT NULL,
    [LoginEmail] NVARCHAR (50) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Address]    NVARCHAR (50) NOT NULL,
    [City]       NVARCHAR (50) NOT NULL,
    [State]      NVARCHAR (2)  NOT NULL,
    [ZipCode]    NCHAR (10)    NOT NULL,
    [CreditCard] NVARCHAR (16) NOT NULL,
    [ExpDate]    NVARCHAR (4)  NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId] ASC)
);


GO
PRINT N'Creating [dbo].[Car]...';
CREATE TABLE [dbo].[Car] (
    [CarId]       INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NOT NULL,
    [Color]       NVARCHAR (25) NOT NULL,
    [Year]        INT           NOT NULL,
    [RentalPrice] MONEY         NOT NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([CarId] ASC)
);

GO
PRINT N'Creating [dbo].[Rental]...';


GO
CREATE TABLE [dbo].[Rental] (
    [RentalId]     INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]    INT      NOT NULL,
    [CarId]        INT      NOT NULL,
    [DateRented]   DATETIME NOT NULL,
    [DateReturned] DATETIME NULL,
    [DateDue]      DATETIME NOT NULL,
    CONSTRAINT [PK_Rental] PRIMARY KEY CLUSTERED ([RentalId] ASC)
);


GO
PRINT N'Creating [dbo].[Reservation]...';


GO
CREATE TABLE [dbo].[Reservation] (
    [ReservationId] INT      IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT      NOT NULL,
    [CarId]         INT      NOT NULL,
    [RentalDate]    DATETIME NOT NULL,
    [ReturnDate]    DATETIME NOT NULL,
    CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED ([ReservationId] ASC)
);


GO
PRINT N'Creating [dbo].[webpages_Membership]...';


GO
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId]                                  INT            NOT NULL,
    [CreateDate]                              DATETIME       NULL,
    [ConfirmationToken]                       NVARCHAR (128) NULL,
    [IsConfirmed]                             BIT            NULL,
    [LastPasswordFailureDate]                 DATETIME       NULL,
    [PasswordFailuresSinceLastSuccess]        INT            NOT NULL,
    [Password]                                NVARCHAR (128) NOT NULL,
    [PasswordChangedDate]                     DATETIME       NULL,
    [PasswordSalt]                            NVARCHAR (128) NOT NULL,
    [PasswordVerificationToken]               NVARCHAR (128) NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
PRINT N'Creating [dbo].[webpages_OAuthMembership]...';


GO
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider]       NVARCHAR (30)  NOT NULL,
    [ProviderUserId] NVARCHAR (100) NOT NULL,
    [UserId]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Provider] ASC, [ProviderUserId] ASC)
);


GO
PRINT N'Creating [dbo].[webpages_Roles]...';


GO
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId]   INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC),
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);


GO
PRINT N'Creating [dbo].[webpages_UsersInRoles]...';


GO
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC)
);


GO
PRINT N'Creating DF__webpages___IsCon__37A5467C...';


GO
ALTER TABLE [dbo].[webpages_Membership]
    ADD DEFAULT ((0)) FOR [IsConfirmed];


GO
PRINT N'Creating DF__webpages___Passw__38996AB5...';


GO
ALTER TABLE [dbo].[webpages_Membership]
    ADD DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess];


GO
PRINT N'Creating fk_UserId...';


GO
ALTER TABLE [dbo].[webpages_UsersInRoles] WITH NOCHECK
    ADD CONSTRAINT [fk_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Account] ([AccountId]);


GO
PRINT N'Creating fk_RoleId...';


GO
ALTER TABLE [dbo].[webpages_UsersInRoles] WITH NOCHECK
    ADD CONSTRAINT [fk_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO




ALTER TABLE [dbo].[webpages_UsersInRoles] WITH CHECK CHECK CONSTRAINT [fk_UserId];

ALTER TABLE [dbo].[webpages_UsersInRoles] WITH CHECK CHECK CONSTRAINT [fk_RoleId];


GO
PRINT N'Update complete.';