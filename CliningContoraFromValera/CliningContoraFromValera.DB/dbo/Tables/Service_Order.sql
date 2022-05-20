CREATE TABLE [dbo].[Service_Order] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [OrderId]   INT NOT NULL,
    [ServiceId] INT NOT NULL,
    [Count]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([Id])
);

