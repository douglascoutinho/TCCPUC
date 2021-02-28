USE [TCC_RISCO]
GO
SET IDENTITY_INSERT [dbo].[DelegaciaPoliciaCivil] ON 
GO
INSERT [dbo].[DelegaciaPoliciaCivil] ([id_delegacia], [ds_delegacia], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (1, N'14ª Delegacia', N'23075-248', N' Rua Bangu', N'132', N'Próximo a Estação', N'Rio de Janeiro', N'Bangu', N'RJ')
GO
INSERT [dbo].[DelegaciaPoliciaCivil] ([id_delegacia], [ds_delegacia], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (2, N'5ª Delegacia', N'12444-646', N'Rua do Governo', N'12', N'Próximo ao Shopping Realengo', N'Rio de Janeiro', N'Realengo', N'RJ')
GO
SET IDENTITY_INSERT [dbo].[DelegaciaPoliciaCivil] OFF
GO
SET IDENTITY_INSERT [dbo].[BatalhaoPoliciaMilitar] ON 
GO
INSERT [dbo].[BatalhaoPoliciaMilitar] ([id_batalhao], [ds_delegacia], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (1, N'14º Batalhão', N'23075-245', N'Rua Barão', N'125', N'Próximo ao shopping Bangu', N'Rio de Janeiro', N'Bangu', N'RJ')
GO
INSERT [dbo].[BatalhaoPoliciaMilitar] ([id_batalhao], [ds_delegacia], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (2, N'5º Batalhão', N'21546-444', N'Rua Realengo', N'745', N'Próximo ao shopping Realengo', N'Rio de Janeiro', N'Ralengo', N'RJ')
GO
INSERT [dbo].[BatalhaoPoliciaMilitar] ([id_batalhao], [ds_delegacia], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (4, N'1º Batalhão Barra da Tijuca', N'21545-454', N'Av. das Américas', N'451', N'Próximo ao Barra Shopping ', N'Rio de Janeiro', N'Barra da Tijuca', N'RJ')
GO
SET IDENTITY_INSERT [dbo].[BatalhaoPoliciaMilitar] OFF
GO
SET IDENTITY_INSERT [dbo].[Risco] ON 
GO
INSERT [dbo].[Risco] ([id_risco], [ds_risco]) VALUES (1, N'Baixo')
GO
INSERT [dbo].[Risco] ([id_risco], [ds_risco]) VALUES (2, N'Médio')
GO
INSERT [dbo].[Risco] ([id_risco], [ds_risco]) VALUES (3, N'Alto')
GO
SET IDENTITY_INSERT [dbo].[Risco] OFF
GO
SET IDENTITY_INSERT [dbo].[Bairro] ON 
GO
INSERT [dbo].[Bairro] ([id_bairro], [nm_bairro], [cidade], [estado], [cisp], [risp], [aisp], [ocorrencias], [id_delegacia], [id_batalhao], [id_risco], [dt_atualizacao], [dt_cadastro]) VALUES (2, N'Bangu', N'Rio de Janeiro', N'RJ', N'123', N'123', N'123', N'2 ocorrências de assalto', 1, 1, 1, NULL, CAST(N'2021-02-20T14:38:46.727' AS DateTime))
GO
INSERT [dbo].[Bairro] ([id_bairro], [nm_bairro], [cidade], [estado], [cisp], [risp], [aisp], [ocorrencias], [id_delegacia], [id_batalhao], [id_risco], [dt_atualizacao], [dt_cadastro]) VALUES (3, N'Realengo', N'Rio de Janeiro', N'RJ', N'345', N'125', N'412', N'3 Assaltos por dia.', 2, 2, 1, CAST(N'2021-02-20T15:09:54.320' AS DateTime), CAST(N'2021-02-20T14:56:37.787' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Bairro] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (1, N'André Matos')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (2, N'Ricardo Confessori')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (3, N'Tobias Sammet')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (4, N'Victor Emeka')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (5, N'Daísa Munhoz')
GO
INSERT [dbo].[Cliente] ([id_cliente], [nm_cliente]) VALUES (6, N'Amanda Somerville')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Predio] ON 
GO
INSERT [dbo].[Predio] ([id_predio], [nm_predio], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (1, N'Condomínio Bangu', N'23075-84', N'Rua Bangu', N'1234', N'Próximo a Estação de Bangu', N'Rio de Janeiro', N'Bangu', N'RJ')
GO
INSERT [dbo].[Predio] ([id_predio], [nm_predio], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (2, N'Condomínio Realengo', N'21831-360', N'Rua Realengo', N'123', N'Próximo ao Shopping de Realengo', N'Rio de Janeiro', N'Realengo', N'RJ')
GO
INSERT [dbo].[Predio] ([id_predio], [nm_predio], [cep], [logradouro], [numero], [complemento], [cidade], [bairro], [estado]) VALUES (4, N'Condomínio Barra ', N'43434-334', N'Av. das Americas', N'321', N'Próximo ao Barra Shopping', N'Rio de Janeiro', N'Barra da Tijuca', N'RJ')
GO
SET IDENTITY_INSERT [dbo].[Predio] OFF
GO
SET IDENTITY_INSERT [dbo].[Apartamento] ON 
GO
INSERT [dbo].[Apartamento] ([id_apartamento], [nm_apartamento], [numero], [id_predio]) VALUES (1, N' CB Bloco 11', N'AP301', 1)
GO
INSERT [dbo].[Apartamento] ([id_apartamento], [nm_apartamento], [numero], [id_predio]) VALUES (2, N'CR Bloco 5', N'AP 350', 2)
GO
INSERT [dbo].[Apartamento] ([id_apartamento], [nm_apartamento], [numero], [id_predio]) VALUES (5, N'CB - Bloco 01', N'AP 302', 1)
GO
SET IDENTITY_INSERT [dbo].[Apartamento] OFF
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoTecnico] ON 
GO
INSERT [dbo].[NotaMeioProtecaoTecnico] ([id_notaMeioProtecaoTecnico], [sistemaDeteccaoIntruso], [sistemaAlarmeIntruso], [circuitoFechadoVideo], [sistemaControleAcesso], [sistemaComunicacao], [sistemaControleRodizio], [telemonitoramento]) VALUES (1, 10, 9, 8, 7, 6, 5, 4)
GO
INSERT [dbo].[NotaMeioProtecaoTecnico] ([id_notaMeioProtecaoTecnico], [sistemaDeteccaoIntruso], [sistemaAlarmeIntruso], [circuitoFechadoVideo], [sistemaControleAcesso], [sistemaComunicacao], [sistemaControleRodizio], [telemonitoramento]) VALUES (2, 90, 90, 80, 70, 90, 90, 62)
GO
INSERT [dbo].[NotaMeioProtecaoTecnico] ([id_notaMeioProtecaoTecnico], [sistemaDeteccaoIntruso], [sistemaAlarmeIntruso], [circuitoFechadoVideo], [sistemaControleAcesso], [sistemaComunicacao], [sistemaControleRodizio], [telemonitoramento]) VALUES (3, 90, 90, 80, 70, 90, 90, 62)
GO
INSERT [dbo].[NotaMeioProtecaoTecnico] ([id_notaMeioProtecaoTecnico], [sistemaDeteccaoIntruso], [sistemaAlarmeIntruso], [circuitoFechadoVideo], [sistemaControleAcesso], [sistemaComunicacao], [sistemaControleRodizio], [telemonitoramento]) VALUES (4, 90, 90, 80, 70, 90, 90, 62)
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoTecnico] OFF
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoFisico] ON 
GO
INSERT [dbo].[NotaMeioProtecaoFisico] ([id_notaMeioProtecaoFisico], [sistemaDeteccaoIntruso], [recursoSegurancaPerimetroExterno], [meiosDesaceleracaoFrenagemVeiculo], [controleAcessoVeiculo], [controleAcessoPedestre], [meioProtecaoEdificio], [armarioSeguranca]) VALUES (1, 10, 9, 8, 100, 20, 80, 90)
GO
INSERT [dbo].[NotaMeioProtecaoFisico] ([id_notaMeioProtecaoFisico], [sistemaDeteccaoIntruso], [recursoSegurancaPerimetroExterno], [meiosDesaceleracaoFrenagemVeiculo], [controleAcessoVeiculo], [controleAcessoPedestre], [meioProtecaoEdificio], [armarioSeguranca]) VALUES (2, 100, 100, 90, 100, 100, 90, 100)
GO
INSERT [dbo].[NotaMeioProtecaoFisico] ([id_notaMeioProtecaoFisico], [sistemaDeteccaoIntruso], [recursoSegurancaPerimetroExterno], [meiosDesaceleracaoFrenagemVeiculo], [controleAcessoVeiculo], [controleAcessoPedestre], [meioProtecaoEdificio], [armarioSeguranca]) VALUES (3, 100, 100, 90, 100, 100, 90, 100)
GO
INSERT [dbo].[NotaMeioProtecaoFisico] ([id_notaMeioProtecaoFisico], [sistemaDeteccaoIntruso], [recursoSegurancaPerimetroExterno], [meiosDesaceleracaoFrenagemVeiculo], [controleAcessoVeiculo], [controleAcessoPedestre], [meioProtecaoEdificio], [armarioSeguranca]) VALUES (4, 100, 100, 90, 100, 100, 90, 100)
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoFisico] OFF
GO
SET IDENTITY_INSERT [dbo].[NotaAvaliacaoProcedimento] ON 
GO
INSERT [dbo].[NotaAvaliacaoProcedimento] ([id_notaAvaliacaoProcedimento], [especificosLocal], [organizacaoSeguranca], [treinamentoConscientizacaoSeguranca], [segurancaEmergenciaExpatriados]) VALUES (1, 90, 90, 100, 10)
GO
INSERT [dbo].[NotaAvaliacaoProcedimento] ([id_notaAvaliacaoProcedimento], [especificosLocal], [organizacaoSeguranca], [treinamentoConscientizacaoSeguranca], [segurancaEmergenciaExpatriados]) VALUES (2, 10, 100, 100, 10)
GO
INSERT [dbo].[NotaAvaliacaoProcedimento] ([id_notaAvaliacaoProcedimento], [especificosLocal], [organizacaoSeguranca], [treinamentoConscientizacaoSeguranca], [segurancaEmergenciaExpatriados]) VALUES (3, 100, 100, 100, 70)
GO
INSERT [dbo].[NotaAvaliacaoProcedimento] ([id_notaAvaliacaoProcedimento], [especificosLocal], [organizacaoSeguranca], [treinamentoConscientizacaoSeguranca], [segurancaEmergenciaExpatriados]) VALUES (4, 100, 100, 100, 70)
GO
SET IDENTITY_INSERT [dbo].[NotaAvaliacaoProcedimento] OFF
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoHumano] ON 
GO
INSERT [dbo].[NotaMeioProtecaoHumano] ([id_notaMeioProtecaoHumano], [guardaSeguranca], [gestaoServicoVigilancia], [equipamentoMaterial], [capacidadeOperacional]) VALUES (1, 90, 9, 100, 100)
GO
INSERT [dbo].[NotaMeioProtecaoHumano] ([id_notaMeioProtecaoHumano], [guardaSeguranca], [gestaoServicoVigilancia], [equipamentoMaterial], [capacidadeOperacional]) VALUES (2, 100, 100, 100, 90)
GO
INSERT [dbo].[NotaMeioProtecaoHumano] ([id_notaMeioProtecaoHumano], [guardaSeguranca], [gestaoServicoVigilancia], [equipamentoMaterial], [capacidadeOperacional]) VALUES (3, 100, 100, 100, 90)
GO
INSERT [dbo].[NotaMeioProtecaoHumano] ([id_notaMeioProtecaoHumano], [guardaSeguranca], [gestaoServicoVigilancia], [equipamentoMaterial], [capacidadeOperacional]) VALUES (4, 100, 100, 100, 90)
GO
SET IDENTITY_INSERT [dbo].[NotaMeioProtecaoHumano] OFF
GO
SET IDENTITY_INSERT [dbo].[Inspecao] ON 
GO
INSERT [dbo].[Inspecao] ([id_inspecao], [distanciaComunidade], [motivoReprovacao], [nota], [situacao], [fotoPredio], [fotoApartamento], [id_cliente], [id_predio], [id_apartamento], [id_bairro], [id_notaMeioProtecaoTecnico], [id_notaMeioProtecaoFisico], [id_notaAvaliacaoProcedimento], [id_notaMeioProtecaoHumano], [dt_cadastro]) VALUES (1, N'2KM', N'Meio Proteção Fisico Meio Proteção Tecnico, ', CAST(50 AS Decimal(18, 0)), N'Reprovada', N'FP20022021144312.png', N'FA20022021144312.png', 1, 1, 1, 2, 1, 1, 1, 1, CAST(N'2021-02-20T14:43:12.813' AS DateTime))
GO
INSERT [dbo].[Inspecao] ([id_inspecao], [distanciaComunidade], [motivoReprovacao], [nota], [situacao], [fotoPredio], [fotoApartamento], [id_cliente], [id_predio], [id_apartamento], [id_bairro], [id_notaMeioProtecaoTecnico], [id_notaMeioProtecaoFisico], [id_notaAvaliacaoProcedimento], [id_notaMeioProtecaoHumano], [dt_cadastro]) VALUES (2, N'4KM', N'', CAST(92 AS Decimal(18, 0)), N'Aprovada', N'FP20022021151116.jpeg', N'FA20022021151116.png', 2, 2, 2, 3, 4, 4, 4, 4, CAST(N'2021-02-20T15:11:16.833' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Inspecao] OFF
GO
