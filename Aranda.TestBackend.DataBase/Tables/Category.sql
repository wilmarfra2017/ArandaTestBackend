﻿CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(200) NOT NULL,
	UNIQUE (Name)
)
