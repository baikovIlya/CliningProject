CREATE TABLE [dbo].[WorkTime] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Date]       DATE          NOT NULL,
    [StartTime]  TIME          NOT NULL,
    [FinishTime] TIME          NOT NULL,
    [EmployeeId] INT           NOT NULL,
    [IsDeleted] BIT DEFAULT 0  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee]([Id])
);

