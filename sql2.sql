﻿CREATE TABLE Users (
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



