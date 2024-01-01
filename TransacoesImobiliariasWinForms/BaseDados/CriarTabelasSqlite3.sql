

CREATE TABLE Imovel (
  IdImovel                   INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  IdCP                       integer(10), 
  IdTipoImovel               integer(10), 
  Area                       real(10), 
  "ClienteNIF Proprientario" integer(10), 
  FOREIGN KEY(IdCP) REFERENCES "Cod. Postal"(IdCP), 
  FOREIGN KEY("ClienteNIF Proprientario") REFERENCES Cliente(NIF), 
  FOREIGN KEY(IdTipoImovel) REFERENCES TipoImovel(IdTipoImovel));
CREATE TABLE "Cod. Postal" (
  IdCP      INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Descricao varchar(255));
CREATE TABLE Cliente (
  IdCP     integer(10), 
  Nome     varchar(255), 
  Morada   varchar(255), 
  DataNasc date, 
  NIF      INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  CC       integer(10), 
  FOREIGN KEY(IdCP) REFERENCES "Cod. Postal"(IdCP));
CREATE TABLE Proposta (
  IdProposta             INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Data                   time, 
  Valor                  numeric(19, 0), 
  DataLimite             date, 
  "ClienteNIF Comprador" integer(10), 
  IdContratoMediacao     integer(10), 
  Ativa                  blob, 
  FOREIGN KEY("ClienteNIF Comprador") REFERENCES Cliente(NIF), 
  FOREIGN KEY(IdContratoMediacao) REFERENCES ContratoMediacao(IdCMediacao));
CREATE TABLE TipoImovel (
  IdTipoImovel INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Descricao    varchar(255));
CREATE TABLE Agente (
  NomeAgente varchar(255), 
  NIFAgente  INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT);
CREATE TABLE Lucro (
  IdLucro     INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Valor       numeric(19, 0), 
  IdCMediacao integer(10), 
  FOREIGN KEY(IdCMediacao) REFERENCES ContratoMediacao(IdCMediacao));
CREATE TABLE VisitaImovel (
  IdImovel      integer(10) NOT NULL, 
  Data          date, 
  ClienteNIF    integer(10) NOT NULL, 
  ValorAvaliado numeric(19, 0), 
  PRIMARY KEY (IdImovel, 
  ClienteNIF), 
  FOREIGN KEY(ClienteNIF) REFERENCES Cliente(NIF), 
  FOREIGN KEY(IdImovel) REFERENCES Imovel(IdImovel));
CREATE TABLE Avaliar (
  IdAvalia      INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  IdAvaliador   integer(10), 
  DataAvaliacao time, 
  FOREIGN KEY(IdAvaliador) REFERENCES Avaliador(IdAvaliador));
CREATE TABLE Avaliador (
  IdAvaliador INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Nome        varchar(255));
CREATE TABLE ImovelAvalia (
  IdImovel integer(10) NOT NULL, 
  IdAvalia integer(10) NOT NULL, 
  PRIMARY KEY (IdImovel, 
  IdAvalia), 
  FOREIGN KEY(IdAvalia) REFERENCES Avaliar(IdAvalia), 
  FOREIGN KEY(IdImovel) REFERENCES Imovel(IdImovel));
CREATE TABLE ContratoCompraVenda (
  IdNegocio INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  TimeStamp time, 
  Data      date);
CREATE TABLE Pagamento (
  DataPagamento       timestamp, 
  IdPagamento         INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  ContratoCompraVenda integer(10), 
  Valor               numeric(19, 0), 
  FOREIGN KEY(ContratoCompraVenda) REFERENCES ContratoCompraVenda(IdNegocio));
CREATE TABLE ClienteContacto (
  TCId       integer(10) NOT NULL, 
  Contacto   varchar(20), 
  ClienteNIF integer(10) NOT NULL, 
  IdContacto integer(10) NOT NULL, 
  PRIMARY KEY (IdContacto), 
  FOREIGN KEY(ClienteNIF) REFERENCES Cliente(NIF), 
  FOREIGN KEY(TCId) REFERENCES "Tipo Contacto"(TCId));
CREATE TABLE "Tipo Contacto" (
  TCId   INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  DescTC varchar(255));
CREATE TABLE AgenteContacto (
  TCId      integer(10) NOT NULL, 
  Contacto  varchar(20), 
  AgenteNIF integer(10) NOT NULL, 
  PRIMARY KEY (TCId, 
  AgenteNIF), 
  FOREIGN KEY(AgenteNIF) REFERENCES Agente(NIFAgente), 
  FOREIGN KEY(TCId) REFERENCES "Tipo Contacto"(TCId));
CREATE TABLE ContratoMediacao (
  ImovelIdImovel integer(10), 
  AgenteNIF      integer(10), 
  ClienteNIF     integer(10), 
  Data           time, 
  Validade       time, 
  ValorPedido    numeric(19, 0), 
  IdCMediacao    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
  Ativo          blob, 
  FOREIGN KEY(ImovelIdImovel) REFERENCES Imovel(IdImovel), 
  FOREIGN KEY(AgenteNIF) REFERENCES Agente(NIFAgente), 
  FOREIGN KEY(ClienteNIF) REFERENCES Cliente(NIF));
CREATE TABLE PropostaContrato (
  ContratoCompraVenda integer(10) NOT NULL, 
  PropostaIdProposta  integer(10) NOT NULL, 
  PRIMARY KEY (ContratoCompraVenda, 
  PropostaIdProposta), 
  FOREIGN KEY(ContratoCompraVenda) REFERENCES ContratoCompraVenda(IdNegocio), 
  FOREIGN KEY(PropostaIdProposta) REFERENCES Proposta(IdProposta));
CREATE TABLE ComissaoAgente (
  AgenteNIF integer(10) NOT NULL, 
  Lucro     integer(10) NOT NULL, 
  Valor     numeric(19, 0), 
  PRIMARY KEY (AgenteNIF, 
  Lucro), 
  FOREIGN KEY(AgenteNIF) REFERENCES Agente(NIFAgente), 
  FOREIGN KEY(Lucro) REFERENCES Lucro(IdLucro));
CREATE TABLE Curso (
  IdCurso integer(10));
  
  -- Criação da tabela UserType
CREATE TABLE IF NOT EXISTS UserType (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    UserType TEXT NOT NULL
);


-- Criação da tabela Users
CREATE TABLE IF NOT EXISTS Users (
    ID INTEGER PRIMARY KEY AUTOINCREMENT,
    IdUserType INTEGER NOT NULL,
    UserName TEXT NOT NULL,
    Passwords TEXT NOT NULL,
    Name TEXT NOT NULL,
    FOREIGN KEY (IdUserType) REFERENCES UserType(ID)
);



-- Inserir dados na tabela [Cod. Postal]
INSERT INTO [Cod. Postal] (Descricao) VALUES ('Porto');
INSERT INTO [Cod. Postal] (Descricao) VALUES ('Braga');

-- Inserir dados na tabela TipoImovel
INSERT INTO TipoImovel (Descricao) VALUES ('Casa');
INSERT INTO TipoImovel (Descricao) VALUES ('Apartamento');

-- Inserir dados na tabela Cliente
--INSERT INTO Cliente (Nome, Morada, DataNasc, NIF, CC) VALUES ('João Silva', 'Rua A, Lisboa', '1990-01-01', 123456789, 111222333);

--SET IDENTITY_INSERT INTO Cliente ON
INSERT INTO Cliente (IdCP, Nome, Morada, DataNasc, NIF, CC) VALUES (1, 'João Silva', 'Rua A, Lisboa', '1990-01-01', 123456789, 111222333);
INSERT INTO Cliente (IdCP ,Nome, Morada, DataNasc, NIF, CC) VALUES (2, 'Maria Santos', 'Rua B, Porto', '1985-05-15', 987654321, 444555666);
INSERT INTO Cliente (IdCP ,Nome, Morada, DataNasc, NIF, CC) VALUES (2, 'Alice', 'Rua de casa dela, Porto', '2020-06-29', 21545665, 1548794);

-- Inserir dados na tabela Imovel
INSERT INTO Imovel (IdCP, IdTipoImovel, Area, [ClienteNIF Proprientario]) VALUES (1, 1, 150.5, 123456789);
INSERT INTO Imovel (IdCP, IdTipoImovel, Area, [ClienteNIF Proprientario]) VALUES (2, 2, 80.0, 987654321);
INSERT INTO Imovel (IdCP, IdTipoImovel, Area, [ClienteNIF Proprientario]) VALUES (2, 2, 200.0, 21545665);

-- Inserir dados na tabela Agente
INSERT INTO Agente (NomeAgente) VALUES ('Agente1');
INSERT INTO Agente (NomeAgente) VALUES ('Agente2');


-- Inserir dados na tabela VisitaImovel
INSERT INTO VisitaImovel (IdImovel, Data, ClienteNIF) VALUES (1, '2023-01-05', 987654321);
INSERT INTO VisitaImovel (IdImovel, Data, ClienteNIF) VALUES (2, '2023-01-10', 123456789);

-- Inserir dados na tabela Avaliador
INSERT INTO Avaliador (Nome) VALUES ('Avaliador1');
INSERT INTO Avaliador (Nome) VALUES ('Avaliador2');

-- Inserir dados na tabela Avaliar
INSERT INTO Avaliar (IdAvaliador, DataAvaliacao) VALUES (1, '2023-01-08');
INSERT INTO Avaliar (IdAvaliador, DataAvaliacao) VALUES (2, '2023-01-12');

-- Inserir dados na tabela ImovelAvalia
INSERT INTO ImovelAvalia (IdImovel, IdAvalia) VALUES (1, 1);
INSERT INTO ImovelAvalia (IdImovel, IdAvalia) VALUES (2, 2);

-- Inserir dados na tabela ContratoCompraVenda
INSERT INTO ContratoCompraVenda (TimeStamp, Data) VALUES ('2023-01-15 12:00:00', '2023-01-15');
INSERT INTO ContratoCompraVenda (TimeStamp, Data) VALUES ('2023-01-20 14:30:00', '2023-01-20');

-- Inserir dados na tabela Pagamento
INSERT INTO Pagamento (DataPagamento, ContratoCompraVenda, Valor) VALUES ('2023-01-20', 1, 180000);
INSERT INTO Pagamento (DataPagamento, ContratoCompraVenda, Valor) VALUES ('2023-01-25', 2, 100000);

-- Inserir dados na tabela [Tipo Contacto]
INSERT INTO [Tipo Contacto] (DescTC) VALUES ('Telemóvel');
INSERT INTO [Tipo Contacto] (DescTC) VALUES ('Email');

-- Inserir dados na tabela ClienteContacto
INSERT INTO ClienteContacto (TCId, Contacto, ClienteNIF, IdContacto) VALUES (1, '912345678', 123456789, 1);
INSERT INTO ClienteContacto (TCId, Contacto, ClienteNIF, IdContacto) VALUES (2, '987654321', 987654321, 2);

-- Inserir dados na tabela AgenteContacto
INSERT INTO AgenteContacto (TCId, Contacto, AgenteNIF) VALUES (1, '923456789', 1);
INSERT INTO AgenteContacto (TCId, Contacto, AgenteNIF) VALUES (2, 'agente1@email.com', 2);

-- Inserir dados na tabela ContratoMediacao
INSERT INTO ContratoMediacao (ImovelIdImovel, AgenteNIF, ClienteNIF, Data, Validade, ValorPedido, Ativo) 
VALUES (1, 1, 123456789, '2023-01-15', '2023-02-15', 200000, 1);
INSERT INTO ContratoMediacao (ImovelIdImovel, AgenteNIF, ClienteNIF, Data, Validade, ValorPedido, Ativo) VALUES (2, 2, 987654321, '2023-01-20', '2023-02-20', 120000, 1);

-- Inserir dados na tabela Proposta
INSERT INTO Proposta (Data, Valor, DataLimite, [ClienteNIF Comprador], IdContratoMediacao, Ativa) VALUES ('2023-01-15', 200000, '2023-02-01', 987654321, 1, 1);
INSERT INTO Proposta (Data, Valor, DataLimite, [ClienteNIF Comprador], IdContratoMediacao, Ativa) VALUES ('2023-01-20', 120000, '2023-02-10', 123456789, 2, 1);

-- Inserir dados na tabela PropostaContrato
INSERT INTO PropostaContrato (ContratoCompraVenda, PropostaIdProposta) VALUES (1, 1); -- atencao aqui pode ser necessario mudar para (1, 2)
INSERT INTO PropostaContrato (ContratoCompraVenda, PropostaIdProposta) VALUES (2, 2);

-- Inserir dados na tabela Lucro
INSERT INTO Lucro (Valor, IdCMediacao) VALUES (5000, 1);
INSERT INTO Lucro (Valor, IdCMediacao) VALUES (3000, 2);

--Inserir dados na tabela Comissao
INSERT INTO ComissaoAgente (AgenteNIF, Valor, Lucro) VALUES (1, 4000, 2);-- atencao aqui pode ser necessario mudar para (1, 2)
INSERT INTO ComissaoAgente (AgenteNIF, Valor, [Lucro]) VALUES (2, 23000, 1);-- atencao aqui pode ser necessario mudar para (1, 2)

--Inserir dados na tabela UserType
INSERT INTO UserType (UserType) VALUES ('Admin');
INSERT INTO UserType (UserType) VALUES ('Manager');
INSERT INTO UserType (UserType) VALUES ('Agent');
INSERT INTO UserType (UserType) VALUES ('Evaluator');

INSERT INTO Users (IdUserType, UserName, Passwords, Name) VALUES 
(1, 'Admin1', '1234', 'Administrador 1');
INSERT INTO Users (IdUserType, UserName, Passwords, Name) VALUES 
(2, 'Manager1', '1234', 'Manager 1 ');