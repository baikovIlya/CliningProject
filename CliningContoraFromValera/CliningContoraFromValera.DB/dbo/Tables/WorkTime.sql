CREATE TABLE [dbo].[WorkTime] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Date]       NVARCHAR (10) NOT NULL,
    [StartTime]  NVARCHAR (10) NOT NULL,
    [FinishTime] NVARCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

