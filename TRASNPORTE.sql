CREATE DATABASE TRANSPORTE
USE TRANSPORTE
/*Tabla de rutas*/

CREATE TABLE RUTAS(
ID INT IDENTITY(1,1) PRIMARY KEY,
CODIGORUTA AS ('R'+right('00'+CONVERT([varchar],[ID]),(2))),
IDAUTOBUS INT NULL,
NOMBRE VARCHAR(30),
/*Llave foranea para relacion con AUTOBUSES*/
FOREIGN KEY (IDAUTOBUS) REFERENCES  AUTOBUSES(ID)
)

/*STORE PROCEDURES DE TABLA RUTAS*/
USE TRANSPORTE
GO
CREATE PROC SP_BUSCARRUTA
@BUSCAR VARCHAR(30)
AS
SELECT * FROM RUTAS
WHERE CODIGORUTA LIKE @BUSCAR + '%' OR NOMBRE LIKE @BUSCAR + '%'
GO
/* STORE PROCEDURE GUARDAR */
USE TRANSPORTE
GO
CREATE PROC SP_GUARDARRUTA
@IDAUTOBUS INT,
@NOMBRE VARCHAR(30)	
AS
INSERT INTO RUTAS VALUES(@IDAUTOBUS,@NOMBRE)
GO

/*STORE PROCEDURE EDITAR RUTA*/
CREATE PROC SP_EDITARRUTA
@IDAUTOBUS INT,
@NOMBRE VARCHAR(30)	
AS
UPDATE RUTAS SET IDAUTOBUS = @IDAUTOBUS, NOMBRE = @NOMBRE
GO

/*STORE PROCEDURE ELIMINAR AUTOBUS*/
CREATE PROC SP_ELIMINARRUTA
@ID INT
AS
DELETE RUTAS WHERE ID = @ID
GO
/*FIN PROCEDURES TABLA RUTAS*/







/*Tabla de autobuses*/

CREATE TABLE AUTOBUSES(
ID INT IDENTITY(1,1) PRIMARY KEY,
IDCHOFER INT,
MARCA VARCHAR(30) NOT NULL,
MODELO VARCHAR(30) NOT NULL,
PLACA VARCHAR(30) NOT NULL,
COLOR VARCHAR(30) ,
ANO VARCHAR(30),
/*Llave foranea para relacion con choferes*/
FOREIGN KEY(IDCHOFER) REFERENCES CHOFERES(ID)
)



/* STORE PROCEDURES TABLA AUTOBUSES*/
/* STORE PROCEDURE BUSCAR */
USE TRANSPORTE
GO
CREATE PROC SP_BUSCARAUTOBUS
@BUSCAR VARCHAR(30)
AS
SELECT * FROM AUTOBUSES
WHERE MARCA LIKE @BUSCAR + '%' OR MODELO LIKE @BUSCAR + '%' OR PLACA LIKE @BUSCAR + '%'
GO
/* STORE PROCEDURE GUARDAR */
USE TRANSPORTE
GO
CREATE PROC SP_GUARDARAUTOBUS
@IDCHOFER INT,
@MARCA VARCHAR(30) ,
@MODELO VARCHAR(30) ,
@PLACA VARCHAR(30) ,
@COLOR VARCHAR(30) ,
@ANO VARCHAR(30)
AS
INSERT INTO AUTOBUSES VALUES(@IDCHOFER,@MARCA,@MODELO,@PLACA,@COLOR,@ANO)
GO

/*STORE PROCEDURE EDITAR AUTOBUS*/
CREATE PROC SP_EDITARAUTOBUS
@IDCHOFER INT,
@MARCA VARCHAR(30) ,
@MODELO VARCHAR(30) ,
@PLACA VARCHAR(30) ,
@COLOR VARCHAR(30) ,
@ANO VARCHAR(30)
AS
UPDATE AUTOBUSES SET IDCHOFER = @IDCHOFER, MARCA = @MARCA, MODELO = @MODELO, PLACA = @PLACA, COLOR = @COLOR, ANO = @ANO
GO

/*STORE PROCEDURE ELIMINAR AUTOBUS*/
CREATE PROC SP_ELIMINARAUTOBUS
@ID INT
AS
DELETE AUTOBUSES WHERE ID = @ID
GO
/* FIN STORE PROCEDURES AUTOBUSES*/

/*TABLA CHOFERES*/
GO
CREATE TABLE CHOFERES(
ID INT IDENTITY(1,1) PRIMARY KEY,
NOMBRE VARCHAR(30) NOT NULL,
APELLIDO VARCHAR(30) NOT NULL,
CEDULA NVARCHAR(30) NOT NULL,
FECHA_NACIMIENTO DATE NULL
)


/* STORE PROCEDURES TABLA CHOFERES*/
/* STORE PROCEDURE BUSCAR */

GO
CREATE PROC SP_BUSCARCHOFER
@BUSCAR VARCHAR(30)
AS
SELECT * FROM CHOFERES
WHERE NOMBRE LIKE @BUSCAR + '%'
GO
/* STORE PROCEDURE GUARDAR */
USE TRANSPORTE
GO
CREATE PROC SP_GUARDARCHOFER
@NOMBRE VARCHAR(30),
@APELLIDO VARCHAR(30), 
@CEDULA NVARCHAR(30),
@FECHA_NACIMIENTO DATE
AS
INSERT INTO CHOFERES VALUES(@NOMBRE,@APELLIDO,@CEDULA,@FECHA_NACIMIENTO)
GO

/*STORE PROCEDURE EDITAR CHOFER*/
CREATE PROC SP_EDITARCHOFER
@NOMBRE VARCHAR(30),
@APELLIDO VARCHAR(30), 
@CEDULA NVARCHAR(30),
@FECHA_NACIMIENTO DATE
AS
UPDATE CHOFERES SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, CEDULA = @CEDULA, FECHA_NACIMIENTO = @FECHA_NACIMIENTO
GO

/*STORE PROCEDURE ELIMINAR CHOFER*/
CREATE PROC SP_ELIMINARCHOFER
@ID INT
AS
DELETE CHOFERES WHERE ID = @ID
GO


/* FIN STORE PROCEDURES CHOFERES*/