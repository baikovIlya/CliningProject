CREATE TABLE [dbo].[WorkArea] (
    [id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (30) NOT NULL,
    [IsDeleted] bit default 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

