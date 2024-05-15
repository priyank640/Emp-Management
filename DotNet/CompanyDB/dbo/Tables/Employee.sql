CREATE TABLE [dbo].[Employee] (
    [Id]  INT             NOT NULL,
    [FirstName]   NVARCHAR (50)   NULL,
    [LastName]    NVARCHAR (50)   NULL,
    [Email]       NVARCHAR (100)  NULL,
    [PhoneNumber] NVARCHAR (15)   NULL,
    [Department]  NVARCHAR (50)   NULL,
    [Salary]      DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

