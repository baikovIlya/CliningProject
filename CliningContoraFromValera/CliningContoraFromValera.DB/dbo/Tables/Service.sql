CREATE TABLE [dbo].[Service] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100)  NOT NULL,
    [Description]     NVARCHAR (255)  NOT NULL,
    [Price]           DECIMAL (10, 2) NOT NULL,
    [CommercialPrice] DECIMAL (10, 2) NOT NULL,
    [Unit]            NVARCHAR (30)   NULL,
    [ServiceTypeId]   INT             NOT NULL,
    [EstimatedTime]   NVARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ServiceTypeId]) REFERENCES [dbo].[ServiceType] ([Id])
);

