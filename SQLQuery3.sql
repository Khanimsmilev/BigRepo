CREATE TABLE Posts (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [Content] NVARCHAR(MAX) NOT NULL,
    [ImageUrl] NVARCHAR(MAX) NULL,
    [VideoUrl] NVARCHAR(MAX) NULL,

    [CreatedDate] DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    [UpdatedDate] DATETIME2 NULL,
    [DeletedDate] DATETIME2 NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Posts_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);

ALTER TABLE Posts
ADD CreatedBy INT NULL,
    UpdatedBy INT NULL,
    DeletedBy INT NULL;


    CREATE TABLE Comments (
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,
    PostId INT NOT NULL,

    Content NVARCHAR(MAX) NOT NULL,

    CreatedBy INT NOT NULL,
    UpdatedBy INT NULL,
    DeletedBy INT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2 NULL,
    DeletedDate DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (PostId) REFERENCES Posts(Id)
);

CREATE TABLE Likes (
    Id INT PRIMARY KEY IDENTITY(1,1),

    UserId INT NOT NULL,
    PostId INT NULL,  
    CommentId INT NULL, 

    CreatedBy INT NOT NULL,
    UpdatedBy INT NULL,
    DeletedBy INT NULL,
    CreatedDate DATETIME2 NOT NULL,
    UpdatedDate DATETIME2 NULL,
    DeletedDate DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,

    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (PostId) REFERENCES Posts(Id),
    FOREIGN KEY (CommentId) REFERENCES Comments(Id)
);