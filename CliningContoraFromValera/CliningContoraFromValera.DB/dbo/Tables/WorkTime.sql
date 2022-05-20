CREATE TABLE [dbo].[WorkTime] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Date]       NVARCHAR (10) NOT NULL,
    [StartTime]  TIME (7)      NOT NULL,
    [FinishTime] TIME (7)      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

