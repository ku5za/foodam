CREATE TABLE [Restaurants]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[RestaurantsName] VARCHAR(30) NOT NULL, 
    [PhoneNumber] NCHAR(9) NOT NULL,
	[Street] VARCHAR(100) NOT NULL, 
    [PostalCode] NCHAR(6) NOT NULL, 
    [City] VARCHAR(30) NOT NULL
);

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('COBA', '732883123', 'Rynek główny 3', '87-300', 'Brodnica');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Telepizza Miodowa', '512244231', 'Miodowa 18', '00-213', 'Warszawa');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Restauracja 3', '512231703', 'Restauracyjna 31', '00-123', 'Warszawa');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Restauracja 32', '548231223', 'Restauracyjna 32', '00-123', 'Warszawa');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Restauracyjna 33', '655231442', 'Restauracyjna 33', '00-123', 'Warszawa');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Szychta', '742213231', 'Barbary 332', '40-012', 'Katowice');

INSERT INTO Restaurants(RestaurantsName, PhoneNumber, Street, PostalCode, City)
VALUES ('Dolce Vita', '523215757', 'Podwale 2', '85-111', 'Bydgoszcz');

SELECT * FROM Restaurants;