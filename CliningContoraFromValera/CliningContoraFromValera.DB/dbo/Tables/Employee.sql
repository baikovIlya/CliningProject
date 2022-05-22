CREATE TABLE [dbo].[Employee] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [Phone]      NVARCHAR (25) NOT NULL,
    [WorkTimeId] INT           NOT NULL,
    [IsDeleted]  BIT DEFAULT 0 NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkTimeId]) REFERENCES [dbo].[WorkTime] ([Id])
);

