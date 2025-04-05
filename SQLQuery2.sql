CREATE TABLE RefreshTokens (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Token] NVARCHAR(255) NOT NULL,
    [UserId] INT NOT NULL,
    [ExpiryDate] DATETIME2 NOT NULL,
    [IsRevoked] BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_RefreshTokens_Users FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);


CREATE TABLE UserFollowRequests (
    [Id] INT PRIMARY KEY IDENTITY,
    [FromUserId] INT NOT NULL,
    [ToUserId] INT NOT NULL,
    [Status] INT NOT NULL DEFAULT(0),
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [RespondedDate] DATETIME2 NULL,

    CONSTRAINT FK_FollowRequests_FromUser FOREIGN KEY (FromUserId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_FollowRequests_ToUser FOREIGN KEY (ToUserId) REFERENCES Users(Id) ON DELETE NO ACTION
);

DROP TABLE UserFollowRequests;

CREATE TABLE UserFollowers (
    [Id] INT PRIMARY KEY IDENTITY,
    [FollowerId] INT NOT NULL,
    [FollowingId] INT NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),

    CONSTRAINT FK_UserFollowers_Follower FOREIGN KEY (FollowerId) REFERENCES Users(Id) ON DELETE CASCADE,
    CONSTRAINT FK_UserFollowers_Following FOREIGN KEY (FollowingId) REFERENCES Users(Id) ON DELETE NO ACTION
);


CREATE TABLE Users (
    [Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL,
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) UNIQUE NOT NULL,
    [PasswordHash] NVARCHAR(255) NOT NULL,
    [PasswordSalt] NVARCHAR(255) NULL, -- lazım deyilsə, silinə bilər
    [ProfilePictureUrl] NVARCHAR(MAX) NULL,
    [Headline] NVARCHAR(255) NULL,
    [Summary] NVARCHAR(MAX) NULL,
    [Bio] NVARCHAR(MAX) NULL,
    [CurrentCompany] NVARCHAR(255) NULL,
    [CurrentPosition] NVARCHAR(255) NULL,
    [Location] NVARCHAR(255) NULL,
    [Industry] NVARCHAR(255) NULL,
    [CoverPhotoUrl] NVARCHAR(MAX) NULL,
    [LinkedInUrl] NVARCHAR(500) NULL,
    [IsEmailConfirmed] BIT DEFAULT ((0)) NOT NULL,
    [EmailConfirmationCode] NVARCHAR(10) NULL,
    [Role] INT DEFAULT ((0)) CHECK ([Role] IN (0,1,2)) NOT NULL, -- 0: User, 1: Admin, 2: Moderator
    [LastActiveAt] DATETIME NULL,
    [UpdatedBy] INT NULL,
    [CreatedBy] INT NULL,
    [DeletedBy] INT NULL,
    [CreatedDate] DATETIME2 (7) DEFAULT (GETDATE()) NOT NULL,
    [DeletedDate] DATETIME2 (7) NULL,
    [UpdatedDate] DATETIME2 (7) NULL,
    [IsDeleted] BIT DEFAULT ((0)) NULL
);

SELECT Id, Email, PasswordHash, PasswordSalt, EmailConfirmationCode, IsEmailConfirmed
FROM Users ORDER BY CreatedDate DESC;

DELETE FROM Users;

