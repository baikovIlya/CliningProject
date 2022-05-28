CREATE TABLE [dbo].[WorkArea] (
    [Id]   INT IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (30)        NOT NULL,
    [IsDeleted] BIT DEFAULT 0  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

