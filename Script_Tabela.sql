CREATE DATABASE Apostila;
USE Apostila;

CREATE TABLE Usuarios(
		ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        Nome VARCHAR(255),
        Email VARCHAR(255),
        Telefone VARCHAR(255)
);

INSERT INTO Usuarios (Nome, Email, Telefone) Values 
('Lourival',  'lourival@gmail.com' , '(11)987654321'),
('João',  'joao@gmail.com' , '(11)123456789'),
('Maria',  'maria@gmail.com' , '(99)987654321');