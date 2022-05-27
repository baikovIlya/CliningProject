CREATE TABLE [dbo].[Order] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [ClientId]         INT             NOT NULL,
    [Date]             DATE            NOT NULL,
    [StartTime]        TIME (0)        NOT NULL,
    [EstimatedEndTime] TIME (0)        NOT NULL,
    [FinishTime]       TIME (0)           NULL,
    [Price]            DECIMAL (10, 2) NOT NULL,
    [Status]           NVARCHAR (50)   NOT NULL,
    [AddressId]        INT             NOT NULL,
    [CountOfEmployees] INT             NOT NULL,
    [IsCommercial]     BIT             NOT NULL,
    [IsDeleted]        bit default 0   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

