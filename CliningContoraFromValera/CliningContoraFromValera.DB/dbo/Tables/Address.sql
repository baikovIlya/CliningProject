CREATE TABLE [dbo].[Address] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Street]     NVARCHAR (50) NOT NULL,
    [Building]   NVARCHAR (50) NOT NULL,
    [Room]       NVARCHAR (50) NULL,
    [WorkAreaId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([WorkAreaId]) REFERENCES [dbo].[WorkArea] ([id])
);

