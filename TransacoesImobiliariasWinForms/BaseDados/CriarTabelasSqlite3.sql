

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


  
  
