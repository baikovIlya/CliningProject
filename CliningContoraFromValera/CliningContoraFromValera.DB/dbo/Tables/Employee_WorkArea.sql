CREATE TABLE [dbo].[Employee_WorkArea] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [WorkAreaId] INT NOT NULL,
    [EmployeeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([WorkAreaId]) REFERENCES [dbo].[WorkArea] ([id]),
    UNIQUE (WorkAreaId, EmployeeId)
);

