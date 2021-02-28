use TCC_RISCO

GO 
	IF OBJECT_ID('Inspecao', 'U') IS NOT NULL
	DROP TABLE Inspecao;

GO 
	IF OBJECT_ID('NotaMeioProtecaoTecnico', 'U') IS NOT NULL
	DROP TABLE NotaMeioProtecaoTecnico;

GO 
	IF OBJECT_ID('NotaMeioProtecaoFisico', 'U') IS NOT NULL
	DROP TABLE NotaMeioProtecaoFisico;

GO 
	IF OBJECT_ID('NotaAvaliacaoProcedimento', 'U') IS NOT NULL
	DROP TABLE NotaAvaliacaoProcedimento;

GO 
	IF OBJECT_ID('NotaMeioProtecaoHumano', 'U') IS NOT NULL
	DROP TABLE NotaMeioProtecaoHumano;

GO 
	IF OBJECT_ID('Apartamento', 'U') IS NOT NULL
	DROP TABLE Apartamento;

GO 
	IF OBJECT_ID('Predio', 'U') IS NOT NULL
	DROP TABLE Predio;

GO 
	IF OBJECT_ID('Cliente', 'U') IS NOT NULL
	DROP TABLE Cliente;

GO 
	IF OBJECT_ID('Bairro', 'U') IS NOT NULL
	DROP TABLE Bairro;

GO 
	IF OBJECT_ID('Risco', 'U') IS NOT NULL
	DROP TABLE Risco;

GO 
	IF OBJECT_ID('BatalhaoPoliciaMilitar', 'U') IS NOT NULL
	DROP TABLE BatalhaoPoliciaMilitar;

GO 
	IF OBJECT_ID('DelegaciaPoliciaCivil', 'U') IS NOT NULL
	DROP TABLE DelegaciaPoliciaCivil;

GO
CREATE TABLE DelegaciaPoliciaCivil(
	 id_delegacia INT IDENTITY(1,1) NOT NULL,
	 ds_delegacia NVARCHAR(100) NOT NULL,
	 cep NVARCHAR(10) NOT NULL,
	 logradouro NVARCHAR(100) NOT NULL,
	 numero NVARCHAR(100) NULL,
	 complemento NVARCHAR(100) NULL,
	 cidade NVARCHAR(100) NOT NULL,
	 bairro NVARCHAR(100) NOT NULL,
	 estado NVARCHAR(100) NOT NULL,
	 PRIMARY KEY(id_delegacia))

GO
CREATE TABLE BatalhaoPoliciaMilitar(
	 id_batalhao INT IDENTITY(1,1) NOT NULL,
	 ds_delegacia NVARCHAR(100) NOT NULL,
	 cep NVARCHAR(10) NOT NULL,
	 logradouro NVARCHAR(100) NOT NULL,
	 numero NVARCHAR(100) NULL,
	 complemento NVARCHAR(100) NULL,
	 cidade NVARCHAR(100) NOT NULL,
	 bairro NVARCHAR(100) NOT NULL,
	 estado NVARCHAR(100) NOT NULL, 
	 PRIMARY KEY(id_batalhao))

GO
 CREATE TABLE Risco(
	 id_risco INT IDENTITY(1,1) NOT NULL,
	 ds_risco NVARCHAR(100) NOT NULL,
	 PRIMARY KEY(id_risco))

/*GO
 INSERT INTO Risco(ds_risco) VALUES ('Baixo');
	INSERT INTO Risco(ds_risco) VALUES ('Médio');
	INSERT INTO Risco(ds_risco) VALUES ('Alto');
*/

GO
CREATE TABLE Bairro(
	 id_bairro INT IDENTITY(1,1) NOT NULL,
	 nm_bairro NVARCHAR(100) NOT NULL,
	 cidade NVARCHAR(100) NOT NULL,
	 estado NVARCHAR(100) NOT NULL,
	 cisp NVARCHAR(100) NOT NULL,
	 risp NVARCHAR(100) NOT NULL,
	 aisp NVARCHAR(100) NOT NULL,
	 ocorrencias NVARCHAR(100) NOT NULL,
	 id_delegacia INT NOT NULL,
	 id_batalhao INT NOT NULL,
	 id_risco INT NOT NULL,
	 dt_atualizacao DATETIME NULL,
	 dt_cadastro DATETIME NOT NULL,
	 PRIMARY KEY(id_bairro),
	 CONSTRAINT FK_Delegacia_Bairro FOREIGN KEY (id_delegacia) REFERENCES DelegaciaPoliciaCivil(id_delegacia),
	 CONSTRAINT FK_Batalhao_Bairro FOREIGN KEY (id_batalhao) REFERENCES BatalhaoPoliciaMilitar(id_batalhao),
	 CONSTRAINT FK_Risco_Bairro FOREIGN KEY (id_risco) REFERENCES Risco(id_risco))

GO
CREATE TABLE Cliente(
	 id_cliente INT IDENTITY(1,1) NOT NULL,
	 nm_cliente NVARCHAR(100) NOT NULL,
	 PRIMARY KEY(id_cliente))

GO
CREATE TABLE Predio(
	 id_predio INT IDENTITY(1,1) NOT NULL,
	 nm_predio NVARCHAR(100) NOT NULL,
	 cep NVARCHAR(10) NOT NULL,
	 logradouro NVARCHAR(100) NOT NULL,
	 numero NVARCHAR(100) NULL,
	 complemento NVARCHAR(100) NULL,
	 cidade NVARCHAR(100) NOT NULL,
	 bairro NVARCHAR(100) NOT NULL,
	 estado NVARCHAR(100) NOT NULL,
	 PRIMARY KEY(id_predio))

GO
CREATE TABLE Apartamento(
	 id_apartamento INT IDENTITY(1,1) NOT NULL,
	 nm_apartamento NVARCHAR(100) NOT NULL,
	 numero NVARCHAR(100) NULL,
	 id_predio INT NOT NULL,
	 CONSTRAINT FK_Predio_Apartamento FOREIGN KEY (id_predio) REFERENCES Predio(id_predio),
	 PRIMARY KEY(id_apartamento))
	 
GO
CREATE TABLE NotaMeioProtecaoTecnico(
	id_notaMeioProtecaoTecnico INT IDENTITY(1,1) NOT NULL,
	sistemaDeteccaoIntruso int NOT NULL,
	sistemaAlarmeIntruso int NOT NULL,
	circuitoFechadoVideo int NOT NULL,
	sistemaControleAcesso int NOT NULL,
	sistemaComunicacao int NOT NULL,
	sistemaControleRodizio int NOT NULL,
	telemonitoramento int NOT NULL,
	 PRIMARY KEY(id_notaMeioProtecaoTecnico))

GO
CREATE TABLE NotaMeioProtecaoFisico(
		id_notaMeioProtecaoFisico INT IDENTITY(1,1) NOT NULL,
		sistemaDeteccaoIntruso int NOT NULL,
		recursoSegurancaPerimetroExterno int NOT NULL,
		meiosDesaceleracaoFrenagemVeiculo int NOT NULL,
		controleAcessoVeiculo int NOT NULL,
		controleAcessoPedestre int NOT NULL,
		meioProtecaoEdificio int NOT NULL,
		armarioSeguranca int NOT NULL,
	 PRIMARY KEY(id_notaMeioProtecaoFisico))

GO
CREATE TABLE NotaAvaliacaoProcedimento(
		id_notaAvaliacaoProcedimento INT IDENTITY(1,1) NOT NULL,
		especificosLocal int NOT NULL,
		organizacaoSeguranca int NOT NULL,
		treinamentoConscientizacaoSeguranca int NOT NULL,	
		segurancaEmergenciaExpatriados int NOT NULL,
		PRIMARY KEY(id_notaAvaliacaoProcedimento))

GO
CREATE TABLE NotaMeioProtecaoHumano(
		id_notaMeioProtecaoHumano INT IDENTITY(1,1) NOT NULL,
		guardaSeguranca int NOT NULL,
		gestaoServicoVigilancia int NOT NULL,
		equipamentoMaterial int NOT NULL,
		capacidadeOperacional int NOT NULL,
	 PRIMARY KEY(id_notaMeioProtecaoHumano))

GO
CREATE TABLE Inspecao(
	 id_inspecao INT IDENTITY(1,1) NOT NULL,
	 distanciaComunidade NVARCHAR(100) NOT NUll,
	 motivoReprovacao NVARCHAR(100) NULL,
	 nota DECIMAL NOT NULL,
	 situacao NVARCHAR(100) NULL,
	 fotoPredio NVARCHAR(100) NULL,
	 fotoApartamento NVARCHAR(100) NULL,
	 id_cliente INT NOT NULL,
	 id_predio INT NOT NULL,
	 id_apartamento INT NOT NULL,
	 id_bairro INT NOT NULL,
	 id_notaMeioProtecaoTecnico INT NOT NULL,
	 id_notaMeioProtecaoFisico INT NOT NULL,
	 id_notaAvaliacaoProcedimento INT NOT NULL,
	 id_notaMeioProtecaoHumano INT NOT NULL,
	 dt_cadastro DATETIME NOT NULL,
	 PRIMARY KEY(id_inspecao),
	 CONSTRAINT FK_Inspecao_Cliente FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
	 CONSTRAINT FK_Inspecao_Predio FOREIGN KEY (id_predio) REFERENCES Predio(id_predio),
	 CONSTRAINT FK_Inspecao_Apartamento FOREIGN KEY (id_apartamento) REFERENCES Apartamento(id_apartamento),
	 CONSTRAINT FK_Inspecao_Bairro FOREIGN KEY (id_bairro) REFERENCES Bairro(id_bairro),

	 CONSTRAINT FK_Inspecao_NotaMeioProtecaoTecnico FOREIGN KEY (id_notaMeioProtecaoTecnico) REFERENCES NotaMeioProtecaoTecnico(id_notaMeioProtecaoTecnico),
	 CONSTRAINT FK_Inspecao_NotaMeioProtecaoFisico FOREIGN KEY (id_notaMeioProtecaoFisico) REFERENCES NotaMeioProtecaoFisico(id_notaMeioProtecaoFisico),
	 CONSTRAINT FK_Inspecao_NotaMeioProtecaoHumano FOREIGN KEY (id_notaMeioProtecaoHumano) REFERENCES NotaMeioProtecaoHumano(id_notaMeioProtecaoHumano),
	 CONSTRAINT FK_Inspecao_NotaAvaliacaoProcedimento FOREIGN KEY (id_notaAvaliacaoProcedimento) REFERENCES notaAvaliacaoProcedimento(id_notaAvaliacaoProcedimento))

	 -- AspNetUsers Migrations
	 GO
	 DELETE FROM AspNetUsers

	 GO
	 INSERT INTO AspNetUsers(id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash /*Admin@01*/, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) 
	 VALUES ('4f9dd562-5553-43fa-bc01-926e28288e2b', 'teste@teste.com', 'TESTE@TESTE.COM', 'teste@teste.com', 'TESTE@TESTE.COM', 1,	'AQAAAAEAACcQAAAAEJoLS7ZxPRPkoOCtPyxJojDJR6JJlsiSzHD56DTYXlZYHcyULeVA9Og4ftz61vODgg==',	'3RLTAIVHH7THIFNXMBN4H2O2KJJGWFKS',	'2e327318-217d-42d9-b2bb-efec494f122d',	NULL, 0, 0,	NULL, 1, 0)