CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME NULL, 
    [CheckNo] NCHAR(10) NULL, 
    [CompanyName] NCHAR(100) NULL, 
    [TIN] NCHAR(20) NULL, 
    [ProductName] NCHAR(10) NULL, 
    [Price] NCHAR(12) NULL
)
