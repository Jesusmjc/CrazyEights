--USE CrazyEights;

CREATE TABLE Jugadores (
	IDJugador INT IDENTITY (1,1) NOT NULL,
	nombreUsuario NVARCHAR(30) NOT NULL,
	monedas INT,
	fotoPerfil NVARCHAR(100),
	IDUsuario INT NOT NULL,
	PRIMARY KEY(IDJugador)
)

CREATE TABLE Usuarios(
	IDUsuario INT IDENTITY(1,1) NOT NULL,
	contraseña NVARCHAR(64) NOT NULL,
	correoElectrónico NVARCHAR(40) NOT NULL,
	IDJugador INT,
	PRIMARY KEY(IDUsuario)
)

ALTER TABLE Jugadores
ADD CONSTRAINT FK_Jugadores_Usuarios FOREIGN KEY(IDUsuario)
REFERENCES Usuarios(IDUsuario) ON DELETE CASCADE ON UPDATE CASCADE

SELECT * FROM Jugadores;