  DROP TABLE Users
    DROP TABLE UserType
  -- Criação da tabela UserType
CREATE TABLE UserType (
  IdUserType int IDENTITY NOT NULL PRIMARY KEY,
  UserType varchar(255) NULL
);

-- Criação da tabela Users com referência à tabela UserType
CREATE TABLE Users (
  IdUser int IDENTITY NOT NULL PRIMARY KEY,
  IdUserType int NOT NULL FOREIGN KEY REFERENCES UserType(IdUserType),
  UserName varchar(255) NULL,
  Passwords varchar(255) NULL,
  Name varchar(255) NULL
);

INSERT UserType (UserType) VALUES ('Admin');
INSERT UserType (UserType) VALUES ('Manager');
INSERT UserType (UserType) VALUES ('Agent');
INSERT UserType (UserType) VALUES ('Evaluator');

INSERT INTO Users (IdUserType, UserName, Passwords, Name) VALUES 
(1, 'Admin1', '1234', 'Administrador 1');
INSERT INTO Users (IdUserType, UserName, Passwords, Name) VALUES 
(2, 'Manager1', '1234', 'Manager 1 ');


