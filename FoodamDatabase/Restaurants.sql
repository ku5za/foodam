CREATE TABLE [dbo].[Restaurants]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[RestaurantsName] VARCHAR(30) NOT NULL, 
    [PhoneNumber] NCHAR(9) NOT NULL,
	[Street] VARCHAR(100) NOT NULL, 
    [PostalCode] NCHAR(6) NOT NULL, 
    [City] VARCHAR(30) NOT NULL
)