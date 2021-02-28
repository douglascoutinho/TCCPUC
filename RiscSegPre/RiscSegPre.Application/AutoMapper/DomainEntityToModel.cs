using AutoMapper;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;

namespace RiscSegPre.Application.AutoMapper
{
    public class DomainEntityToModel : Profile
    {
        public DomainEntityToModel()
        {
            CreateMap<Apartamento, ApartamentoModel>().ReverseMap();
            CreateMap<Predio, PredioModel>().ReverseMap();
            CreateMap<Cliente, ClienteModel>().ReverseMap();
            CreateMap<Bairro, BairroModel>().ReverseMap();

            CreateMap<BatalhaoPoliciaMilitar, BatalhaoPoliciaMilitarModel>()
                   .ConvertUsing((src, dst) =>
                   {
                       return new BatalhaoPoliciaMilitarModel
                       {
                           id_batalhao = src.id_batalhao,
                           ds_delegacia = src.ds_delegacia,
                           bairro = src.bairro,
                           cep = src.cep,
                           cidade = src.cidade,
                           complemento = src.complemento,
                           estado = src.estado,
                           logradouro = src.logradouro,
                           numero = src.numero
                       };
                   });

            CreateMap<DelegaciaPoliciaCivil, DelegaciaPoliciaCivilModel>()
                   .ConvertUsing((src, dst) =>
                   {
                       return new DelegaciaPoliciaCivilModel
                       {
                           id_delegacia = src.id_delegacia,
                           ds_delegacia = src.ds_delegacia,
                           bairro = src.bairro,
                           cep = src.cep,
                           cidade = src.cidade,
                           complemento = src.complemento,
                           estado = src.estado,
                           logradouro = src.logradouro,
                           numero = src.numero
                       };
                   });

            CreateMap<Inspecao, InspecaoModel>()
            .ForMember(dest => dest.id_inspecao, opt => opt.MapFrom(src => src.id_inspecao))
            .ForMember(dest => dest.distanciaComunidade, opt => opt.MapFrom(src => src.distanciaComunidade))
            .ForMember(dest => dest.motivoReprovacao, opt => opt.MapFrom(src => src.motivoReprovacao))
            .ForMember(dest => dest.nota, opt => opt.MapFrom(src => src.nota))
            .ForMember(dest => dest.situacao, opt => opt.MapFrom(src => src.situacao))
            .ForMember(dest => dest.fotoPredio, opt => opt.MapFrom(src => src.fotoPredio))
            .ForMember(dest => dest.fotoApartamento, opt => opt.MapFrom(src => src.fotoApartamento))
            .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
            .ForMember(dest => dest.id_predio, opt => opt.MapFrom(src => src.id_predio))
            .ForMember(dest => dest.id_apartamento, opt => opt.MapFrom(src => src.id_apartamento))
            .ForMember(dest => dest.id_bairro, opt => opt.MapFrom(src => src.id_bairro))
            .ForMember(dest => dest.id_notaMeioProtecaoTecnico, opt => opt.MapFrom(src => src.id_notaMeioProtecaoTecnico))
            .ForMember(dest => dest.id_notaMeioProtecaoFisico, opt => opt.MapFrom(src => src.id_notaMeioProtecaoFisico))
            .ForMember(dest => dest.id_notaAvaliacaoProcedimento, opt => opt.MapFrom(src => src.id_notaAvaliacaoProcedimento))
            .ForMember(dest => dest.id_notaMeioProtecaoHumano, opt => opt.MapFrom(src => src.id_notaMeioProtecaoHumano))
            .ForMember(dest => dest.dt_cadastro, opt => opt.MapFrom(src => src.dt_cadastro))
            .ForMember(dest => dest.id_apartamentoNavigation, opt => opt.MapFrom(src => src.id_apartamentoNavigation))
            .ForMember(dest => dest.id_bairroNavigation, opt => opt.MapFrom(src => src.id_bairroNavigation))
            .ForMember(dest => dest.id_clienteNavigation, opt => opt.MapFrom(src => src.id_clienteNavigation))
            .ForMember(dest => dest.id_predioNavigation, opt => opt.MapFrom(src => src.id_predioNavigation));

            CreateMap<NotaMeioProtecaoFisico, NotaMeioProtecaoFisicoModel>()
                .ForMember(dest => dest.id_notaMeioProtecaoFisico, opt => opt.MapFrom(src => src.id_notaMeioProtecaoFisico))
                .ForMember(dest => dest.sistemaDeteccaoIntruso, opt => opt.MapFrom(src => src.sistemaDeteccaoIntruso))
                .ForMember(dest => dest.recursoSegurancaPerimetroExterno, opt => opt.MapFrom(src => src.recursoSegurancaPerimetroExterno))
                .ForMember(dest => dest.meiosDesaceleracaoFrenagemVeiculo, opt => opt.MapFrom(src => src.meiosDesaceleracaoFrenagemVeiculo))
                .ForMember(dest => dest.controleAcessoVeiculo, opt => opt.MapFrom(src => src.controleAcessoVeiculo))
                .ForMember(dest => dest.controleAcessoPedestre, opt => opt.MapFrom(src => src.controleAcessoPedestre))
                .ForMember(dest => dest.meioProtecaoEdificio, opt => opt.MapFrom(src => src.meioProtecaoEdificio))
                .ForMember(dest => dest.armarioSeguranca, opt => opt.MapFrom(src => src.armarioSeguranca));

            CreateMap<NotaMeioProtecaoHumano, NotaMeioProtecaoHumanoModel>()
                .ForMember(dest => dest.id_notaMeioProtecaoHumano, opt => opt.MapFrom(src => src.id_notaMeioProtecaoHumano))
                .ForMember(dest => dest.guardaSeguranca, opt => opt.MapFrom(src => src.guardaSeguranca))
                .ForMember(dest => dest.gestaoServicoVigilancia, opt => opt.MapFrom(src => src.gestaoServicoVigilancia))
                .ForMember(dest => dest.equipamentoMaterial, opt => opt.MapFrom(src => src.equipamentoMaterial))
                .ForMember(dest => dest.capacidadeOperacional, opt => opt.MapFrom(src => src.capacidadeOperacional));

            CreateMap<NotaMeioProtecaoTecnico, NotaMeioProtecaoTecnicoModel>()
                .ForMember(dest => dest.id_notaMeioProtecaoTecnico, opt => opt.MapFrom(src => src.id_notaMeioProtecaoTecnico))
                .ForMember(dest => dest.sistemaDeteccaoIntruso, opt => opt.MapFrom(src => src.sistemaDeteccaoIntruso))
                .ForMember(dest => dest.sistemaAlarmeIntruso, opt => opt.MapFrom(src => src.sistemaAlarmeIntruso))
                .ForMember(dest => dest.circuitoFechadoVideo, opt => opt.MapFrom(src => src.circuitoFechadoVideo))
                .ForMember(dest => dest.sistemaControleAcesso, opt => opt.MapFrom(src => src.sistemaControleAcesso))
                .ForMember(dest => dest.sistemaComunicacao, opt => opt.MapFrom(src => src.sistemaComunicacao))
                .ForMember(dest => dest.sistemaControleRodizio, opt => opt.MapFrom(src => src.sistemaControleRodizio))
                .ForMember(dest => dest.telemonitoramento, opt => opt.MapFrom(src => src.telemonitoramento));

            CreateMap<NotaAvaliacaoProcedimento, NotaAvaliacaoProcedimentoModel>()
                .ForMember(dest => dest.id_notaAvaliacaoProcedimento, opt => opt.MapFrom(src => src.id_notaAvaliacaoProcedimento))
                .ForMember(dest => dest.especificosLocal, opt => opt.MapFrom(src => src.especificosLocal))
                .ForMember(dest => dest.organizacaoSeguranca, opt => opt.MapFrom(src => src.organizacaoSeguranca))
                .ForMember(dest => dest.treinamentoConscientizacaoSeguranca, opt => opt.MapFrom(src => src.treinamentoConscientizacaoSeguranca))
                .ForMember(dest => dest.segurancaEmergenciaExpatriados, opt => opt.MapFrom(src => src.segurancaEmergenciaExpatriados));
        }
    }
}