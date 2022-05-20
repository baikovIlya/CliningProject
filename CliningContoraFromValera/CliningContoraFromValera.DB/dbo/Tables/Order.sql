CREATE TABLE [dbo].[Order] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [ClientId]         INT             NOT NULL,
    [Date]             NVARCHAR (10)   NOT NULL,
    [StartTime]        TIME (7)        NOT NULL,
    [EstimatedEndTime] TIME (7)        NOT NULL,
    [EndTime]          TIME (7)        NULL,
    [Price]            DECIMAL (10, 2) NOT NULL,
    [Status]           NVARCHAR (1)    NOT NULL,
    [AddressId]        INT             NOT NULL,
    [CountOfEmployees] INT             NOT NULL,
    [IsCommercial]     BIT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]),
    FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

