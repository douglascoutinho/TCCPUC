-- use TCC_RISCO --TESTE

GO 
	IF OBJECT_ID('MotivoReprovacaoApartamento', 'U') IS NOT NULL
	DROP TABLE MotivoReprovacaoApartamento;

GO 
	IF OBJECT_ID('MotivoReprovacaoPredio', 'U') IS NOT NULL
	DROP TABLE MotivoReprovacaoPredio;

GO 
	IF OBJECT_ID('StatusApartamento', 'U') IS NOT NULL
	DROP TABLE StatusApartamento;

GO 
	IF OBJECT_ID('StatusPredio', 'U') IS NOT NULL
	DROP TABLE StatusPredio;

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
	IF OBJECT_ID('FotoApartamento', 'U') IS NOT NULL
	DROP TABLE FotoApartamento;

GO 
	IF OBJECT_ID('FotoPredio', 'U') IS NOT NULL
	DROP TABLE FotoPredio;

GO 
	IF OBJECT_ID('Foto', 'U') IS NOT NULL
	DROP TABLE Foto;

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
	 ds_delegacia NVARCHAR(100),
	 cep NVARCHAR(10),
	 logradouro NVARCHAR(100),
	 numero NVARCHAR(100),
	 complemento NVARCHAR(100),
	 cidade NVARCHAR(100),
	 bairro NVARCHAR(100),
	 estado NVARCHAR(100),
	 PRIMARY KEY(id_delegacia))

GO
CREATE TABLE BatalhaoPoliciaMilitar(
	 id_batalhao INT IDENTITY(1,1) NOT NULL,
	 ds_delegacia NVARCHAR(100),
	 cep NVARCHAR(10),
	 logradouro NVARCHAR(100),
	 numero NVARCHAR(100),
	 complemento NVARCHAR(100),
	 cidade NVARCHAR(100),
	 bairro NVARCHAR(100),
	 estado NVARCHAR(100), 
	 PRIMARY KEY(id_batalhao))

GO
 CREATE TABLE Risco(
	 id_risco INT IDENTITY(1,1) NOT NULL,
	 ds_risco NVARCHAR(100) NOT NULL,
	 PRIMARY KEY(id_risco))

GO
 INSERT INTO Risco(ds_risco) VALUES ('Baixo');
	INSERT INTO Risco(ds_risco) VALUES ('Médio');
	INSERT INTO Risco(ds_risco) VALUES ('Alto');

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
CREATE TABLE Foto(
	 id_foto INT IDENTITY(1,1) NOT NULL,
	 ds_foto NVARCHAR(100) NOT NULL,
	 img_foto image NOT NULL,
	 PRIMARY KEY(id_foto))

GO
CREATE TABLE Predio(
	 id_predio INT IDENTITY(1,1) NOT NULL,
	 nm_predio NVARCHAR(100) NOT NULL,
	 cep NVARCHAR(10),
	 logradouro NVARCHAR(100),
	 numero NVARCHAR(100),
	 complemento NVARCHAR(100),
	 cidade NVARCHAR(100),
	 bairro NVARCHAR(100),
	 estado NVARCHAR(100),
	 PRIMARY KEY(id_predio))
GO
CREATE TABLE Apartamento(
	 id_apartamento INT IDENTITY(1,1) NOT NULL,
	 nm_apartamento NVARCHAR(100) NOT NULL,
	 numero NVARCHAR(100),
	 id_predio INT NOT NULL,
	 CONSTRAINT FK_Predio_Apartamento FOREIGN KEY (id_predio) REFERENCES Predio(id_predio),
	 PRIMARY KEY(id_apartamento))
	 
GO
CREATE TABLE FotoPredio(
	 id_fotoPredio INT IDENTITY(1,1) NOT NULL,
	 id_foto INT NOT NULL,
	 id_predio INT NOT NULL,
	 PRIMARY KEY(id_fotoPredio),
	 CONSTRAINT FK_Foto_FotoPredio FOREIGN KEY (id_foto) REFERENCES Foto(id_foto),
	 CONSTRAINT FK_Predio_FotoPredio FOREIGN KEY (id_predio) REFERENCES Predio(id_predio))

GO
CREATE TABLE FotoApartamento(
	 id_fotoApartamento INT IDENTITY(1,1) NOT NULL,
	 id_foto INT NOT NULL,
	 id_apartamento INT NOT NULL,
	 PRIMARY KEY(id_fotoApartamento),
	 CONSTRAINT FK_Foto_FotoApartamento FOREIGN KEY (id_foto) REFERENCES Foto(id_foto),
	 CONSTRAINT FK_Predio_FotoApartamento FOREIGN KEY (id_apartamento) REFERENCES Apartamento(id_apartamento))
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
	 situacao NVARCHAR(100) NOT NULL,
	 fotoPredio NVARCHAR(100) NOT NULL,
	 fotoApartamento NVARCHAR(100) NOT NULL,
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
	 CONSTRAINT FK_Inspecao_id_NotaAvaliacaoProcedimento FOREIGN KEY (id_notaAvaliacaoProcedimento) REFERENCES notaAvaliacaoProcedimento(id_notaAvaliacaoProcedimento))
/*
GO
CREATE TABLE StatusPredio(
     id_statusPredio INT IDENTITY(1,1) NOT NULL,
	 ds_statusPredio NVARCHAR(100) NOT NUll,
	 PRIMARY KEY(id_statusPredio))

GO
CREATE TABLE StatusApartamento(
     id_statusApartamento INT IDENTITY(1,1) NOT NULL,
	 ds_statusApartamento NVARCHAR(100) NOT NUll,
	 PRIMARY KEY(id_statusApartamento))

GO
CREATE TABLE MotivoReprovacaoPredio(
     id_motivoReprovacaoPredio INT IDENTITY(1,1) NOT NULL,
	 ds_motivoReprovacaoPredio NVARCHAR(100) NOT NUll,
	 recomendacoesPredio NVARCHAR(100) NOT NUll,
	 observacoes NVARCHAR(100) NUll,
	 id_statusPredio INT NOT NUll,
	 id_inspecao INT NOT NULL,
	 dt_cadastro DATETIME NOT NULL,
	 PRIMARY KEY(id_motivoReprovacaoPredio),
	 CONSTRAINT FK_MotivoReprovacaoPredio_Inspecao FOREIGN KEY (id_inspecao) REFERENCES Inspecao(id_inspecao),
	 CONSTRAINT FK_MotivoReprovacaoPredio_StatusPredio FOREIGN KEY (id_statusPredio) REFERENCES StatusPredio(id_statusPredio))

GO
CREATE TABLE MotivoReprovacaoApartamento(
     id_motivoReprovacaoApartamento INT IDENTITY(1,1) NOT NULL,
	 ds_motivoReprovacaoApartamento NVARCHAR(100) NOT NUll,
	 recomendacoesApartamento NVARCHAR(100) NOT NUll,
	 observacoes NVARCHAR(100) NUll,
	 id_statusApartamento INT NOT NUll,
	 id_inspecao INT NOT NULL,
	 dt_cadastro DATETIME NOT NULL,
	 PRIMARY KEY(id_motivoReprovacaoApartamento),
	 CONSTRAINT FK_MotivoReprovacaoApartamento_Inspecao FOREIGN KEY (id_inspecao) REFERENCES Inspecao(id_inspecao),
	 CONSTRAINT FK_MotivoReprovacaoApartamento_StatusPredio FOREIGN KEY (id_statusApartamento) REFERENCES StatusApartamento(id_statusApartamento))
*/	 