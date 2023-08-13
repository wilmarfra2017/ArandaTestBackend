CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[NameProduct] NVARCHAR(200) NOT NULL,
	[Description] NVARCHAR(1000),
	[CategoryId] int,
	[ImageUrl] NVARCHAR(1000),
	FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
