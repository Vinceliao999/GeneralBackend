CREATE TABLE [dbo].[User] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (20) NOT NULL,
    [Height] INT           NULL,
    [Weight] INT           NULL,
    [Group] NVARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

