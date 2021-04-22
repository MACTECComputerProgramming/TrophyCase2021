CREATE TABLE [dbo].[Award] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [YearEarned] INT            NOT NULL,
    [Details]    NVARCHAR (MAX) NULL,
    [ImagePath]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED ([Id] ASC)
);

