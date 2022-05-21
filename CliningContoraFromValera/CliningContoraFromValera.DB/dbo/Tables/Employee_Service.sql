CREATE TABLE [dbo].[Employee_Service] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT NOT NULL,
    [ServiceId]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([Id])
);

