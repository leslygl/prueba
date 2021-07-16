CREATE DATABASE Biblioteca
GO
USE Biblioteca

CREATE TABLE Volumen(
NumeroVolumen INT PRIMARY KEY,
Titulo VARCHAR (100)
)

CREATE TABLE Coordenadas(
IdCoordenadas INT PRIMARY KEY IDENTITY(1,1),
Estante VARCHAR(20),
Sala VARCHAR(50),
Librero VARCHAR (10),
Posicion INT
)

GO
CREATE PROCEDURE VolumenGetAll
AS
SELECT [NumeroVolumen]
      ,[Titulo]
FROM Volumen
GO
CREATE PROCEDURE CoordenadasGetAll
AS
SELECT [Estante]
	  ,[IdCoordenadas]
      ,[Sala]
      ,[Librero]
      ,[Posicion]
  FROM [dbo].[Coordenadas]

GO

CREATE PROCEDURE VolumenGetById
@NumeroVolumen INT
AS
SELECT [NumeroVolumen]
      ,[Titulo]
FROM Volumen
WHERE NumeroVolumen=@NumeroVolumen

GO
CREATE PROCEDURE CoordenadasGetById 
@IdCoordenada INT
AS
SELECT [Estante]
	  ,[IdCoordenadas]
      ,[Sala]
      ,[Librero]
      ,[Posicion]
  FROM [dbo].[Coordenadas]
WHERE IdCoordenadas= @IdCoordenada

GO
CREATE PROCEDURE VolumenAdd 
@NumeroVolumen INT,
@Titulo VARCHAR(100)
AS
INSERT INTO [Volumen]
           ([NumeroVolumen]
           ,[Titulo])
     VALUES
           (@NumeroVolumen
           ,@Titulo)

GO
CREATE PROCEDURE CoordenadasAdd 
@Estante VARCHAR(20),
@Sala VARCHAR(50),
@Librero VARCHAR(10),
@Posicion INT
AS
INSERT INTO [Coordenadas]
           ([Estante]
           ,[Sala]
           ,[Librero]
           ,[Posicion])
     VALUES
           (@Estante
           ,@Sala
           ,@Librero
           ,@posicion)

GO
CREATE PROCEDURE VolumenUpdate
@NumeroVolumen INT,
@Titulo VARCHAR(100)
AS
UPDATE [Volumen]
   SET [Titulo] = @Titulo
 WHERE NumeroVolumen = @NumeroVolumen
GO
CREATE PROCEDURE CoordenadasUpdate 
@IdCoordenadas INT,
@Estante VARCHAR(20),
@Sala VARCHAR(50),
@Librero VARCHAR(10),
@Posicion INT
AS
UPDATE [dbo].[Coordenadas]
   SET [Estante] = @Estante
      ,[Sala] = @Sala
      ,[Librero] = @Librero
      ,[Posicion] = @Posicion
 WHERE IdCoordenadas = @IdCoordenadas
GO
CREATE PROCEDURE VolumenDelete
@NumeroVolumen INT
AS
DELETE FROM Volumen
WHERE NumeroVolumen=@NumeroVolumen
GO
CREATE PROCEDURE CoordenadasDelete 
@IdCoordenadas INT
AS
DELETE FROM Coordenadas
WHERE IdCoordenadas=@IdCoordenadas




INSERT INTO Volumen VALUES(1,'Volumen prueba')
INSERT INTO Coordenadas VALUES ('A12','Historia','H',34)
