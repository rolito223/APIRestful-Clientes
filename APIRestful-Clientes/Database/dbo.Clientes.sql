CREATE TABLE [dbo].[Clientes] (
    [Id]       INT        NOT NULL,
    [Name]     NCHAR (40) NOT NULL,
    [LastName] NCHAR (40) NOT NULL,
    [Address]  NCHAR (40) NOT NULL,
    [City]     NCHAR (40) NOT NULL,
    [ZipCode] NCHAR (10) NOT NULL,
    [Dni]      INT        NOT NULL,
    [Phone]    NCHAR(15)        NOT NULL,
    [Email]    NCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

