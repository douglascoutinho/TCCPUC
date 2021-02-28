using AutoMapper;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;

namespace RiscSegPre.Application.AutoMapper
{
    public class ModelToDomainEntity : Profile
    {
        public ModelToDomainEntity()
        {
            CreateMap<ApartamentoModel, Apartamento>().ReverseMap();
            CreateMap<PredioModel, Predio>().ReverseMap();

            CreateMap<BatalhaoPoliciaMilitarModel, BatalhaoPoliciaMilitar>()
                .ForMember(dest => dest.id_batalhao, opt => opt.MapFrom(src => src.id_batalhao))
                .ForMember(dest => dest.ds_delegacia, opt => opt.MapFrom(src => src.ds_delegacia))
                .ForMember(dest => dest.cep, opt => opt.MapFrom(src => src.cep))
                .ForMember(dest => dest.logradouro, opt => opt.MapFrom(src => src.logradouro))
                .ForMember(dest => dest.numero, opt => opt.MapFrom(src => src.numero))
                .ForMember(dest => dest.bairro, opt => opt.MapFrom(src => src.bairro))
                .ForMember(dest => dest.cidade, opt => opt.MapFrom(src => src.cidade))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.estado))
                .ForMember(dest => dest.complemento, opt => opt.MapFrom(src => src.complemento))
                .ForMember(x => x.Bairro, y => y.Ignore());

            CreateMap<DelegaciaPoliciaCivilModel, DelegaciaPoliciaCivil>()
                .ForMember(dest => dest.id_delegacia, opt => opt.MapFrom(src => src.id_delegacia))
                .ForMember(dest => dest.ds_delegacia, opt => opt.MapFrom(src => src.ds_delegacia))
                .ForMember(dest => dest.cep, opt => opt.MapFrom(src => src.cep))
                .ForMember(dest => dest.logradouro, opt => opt.MapFrom(src => src.logradouro))
                .ForMember(dest => dest.numero, opt => opt.MapFrom(src => src.numero))
                .ForMember(dest => dest.bairro, opt => opt.MapFrom(src => src.bairro))
                .ForMember(dest => dest.cidade, opt => opt.MapFrom(src => src.cidade))
                .ForMember(dest => dest.estado, opt => opt.MapFrom(src => src.estado))
                .ForMember(dest => dest.complemento, opt => opt.MapFrom(src => src.complemento))
                .ForMember(x => x.Bairro, y => y.Ignore());

            CreateMap<ClienteModel, Cliente>()
                .ForMember(dest => dest.id_cliente, opt => opt.MapFrom(src => src.id_cliente))
                .ForMember(dest => dest.nm_cliente, opt => opt.MapFrom(src => src.nm_cliente))
                .ForMember(x => x.Inspecao, y => y.Ignore());

            CreateMap<BairroModel, Bairro>().ReverseMap()
                .ForMember(dest => dest.id_bairro, opt => opt.MapFrom(src => src.id_bairro))
                .ForMember(dest => dest.nm_bairro, opt => opt.MapFrom(src => src.nm_bairro))
                .ForMember(dest => dest.ocorrencias, opt => opt.MapFrom(src => src.ocorrencias))
                .ForMember(dest => dest.id_delegacia, opt => opt.MapFrom(src => src.id_delegacia))
                .ForMember(dest => dest.id_batalhao, opt => opt.MapFrom(src => src.id_batalhao))
                .ForMember(dest => dest.id_risco, opt => opt.MapFrom(src => src.id_risco));

            CreateMap<InspecaoModel, Inspecao>()
                 .ConvertUsing((src, dst) =>
                 {
                     return new Inspecao(

                         src.id_inspecao,
                         src.distanciaComunidade,
                         src.motivoReprovacao,
                         src.nota,
                         src.situacao,
                         src.fotoPredio,
                         src.fotoApartamento,

                         src.id_cliente,
                         src.id_predio,
                         src.id_apartamento,
                         src.id_bairro,

                         src.id_notaMeioProtecaoTecnico,
                         src.id_notaMeioProtecaoFisico,
                         src.id_notaAvaliacaoProcedimento,
                         src.id_notaMeioProtecaoHumano,

                         new NotaMeioProtecaoFisico(
                                src.id_notaMeioProtecaoFisicoNavigation.id_notaMeioProtecaoFisico,
                                src.id_notaMeioProtecaoFisicoNavigation.sistemaDeteccaoIntruso,
                                src.id_notaMeioProtecaoFisicoNavigation.recursoSegurancaPerimetroExterno,
                                src.id_notaMeioProtecaoFisicoNavigation.meiosDesaceleracaoFrenagemVeiculo,
                                src.id_notaMeioProtecaoFisicoNavigation.controleAcessoVeiculo,
                                src.id_notaMeioProtecaoFisicoNavigation.controleAcessoPedestre,
                                src.id_notaMeioProtecaoFisicoNavigation.meioProtecaoEdificio,
                                src.id_notaMeioProtecaoFisicoNavigation.armarioSeguranca),

                         new NotaMeioProtecaoHumano(
                             src.id_notaMeioProtecaoHumanoNavigation.id_notaMeioProtecaoHumano,
                             src.id_notaMeioProtecaoHumanoNavigation.guardaSeguranca,
                             src.id_notaMeioProtecaoHumanoNavigation.gestaoServicoVigilancia,
                             src.id_notaMeioProtecaoHumanoNavigation.equipamentoMaterial,
                             src.id_notaMeioProtecaoHumanoNavigation.capacidadeOperacional),

                         new NotaMeioProtecaoTecnico(
                             src.id_notaMeioProtecaoTecnicoNavigation.id_notaMeioProtecaoTecnico,
                             src.id_notaMeioProtecaoTecnicoNavigation.sistemaDeteccaoIntruso,
                             src.id_notaMeioProtecaoTecnicoNavigation.sistemaAlarmeIntruso,
                             src.id_notaMeioProtecaoTecnicoNavigation.circuitoFechadoVideo,
                             src.id_notaMeioProtecaoTecnicoNavigation.sistemaControleAcesso,
                             src.id_notaMeioProtecaoTecnicoNavigation.sistemaComunicacao,
                             src.id_notaMeioProtecaoTecnicoNavigation.sistemaControleRodizio,
                             src.id_notaMeioProtecaoTecnicoNavigation.telemonitoramento),

                         new NotaAvaliacaoProcedimento(
                             src.id_notaAvaliacaoProcedimentoNavigation.id_notaAvaliacaoProcedimento,
                             src.id_notaAvaliacaoProcedimentoNavigation.especificosLocal,
                             src.id_notaAvaliacaoProcedimentoNavigation.organizacaoSeguranca,
                             src.id_notaAvaliacaoProcedimentoNavigation.treinamentoConscientizacaoSeguranca,
                             src.id_notaAvaliacaoProcedimentoNavigation.segurancaEmergenciaExpatriados)
                     );
                 });

            CreateMap<NotaMeioProtecaoFisicoModel, NotaMeioProtecaoFisico>()
                   .ForMember(x => x.Inspecao, y => y.Ignore())
                  .ConvertUsing((src, dst) =>
                  {
                      return new NotaMeioProtecaoFisico(

                          src.id_notaMeioProtecaoFisico,
                          src.sistemaDeteccaoIntruso,
                          src.recursoSegurancaPerimetroExterno,
                          src.meiosDesaceleracaoFrenagemVeiculo,
                          src.controleAcessoVeiculo,
                          src.controleAcessoPedestre,
                          src.meioProtecaoEdificio,
                          src.armarioSeguranca
                      );
                  });

            CreateMap<NotaMeioProtecaoHumanoModel, NotaMeioProtecaoHumano>()
                .ForMember(x => x.Inspecao, y => y.Ignore())
                  .ConvertUsing((src, dst) =>
                  {
                      return new NotaMeioProtecaoHumano(

                          src.id_notaMeioProtecaoHumano,
                          src.guardaSeguranca,
                          src.gestaoServicoVigilancia,
                          src.equipamentoMaterial,
                          src.capacidadeOperacional
                      );
                  });

            CreateMap<NotaMeioProtecaoTecnicoModel, NotaMeioProtecaoTecnico>()
                .ForMember(x => x.Inspecao, y => y.Ignore())
                .ConvertUsing((src, dst) =>
                {
                    return new NotaMeioProtecaoTecnico(

                        src.id_notaMeioProtecaoTecnico,
                        src.sistemaDeteccaoIntruso,
                        src.sistemaAlarmeIntruso,
                        src.circuitoFechadoVideo,
                        src.sistemaControleAcesso,
                        src.sistemaComunicacao,
                        src.sistemaControleRodizio,
                        src.telemonitoramento
                    );
                });

            CreateMap<NotaAvaliacaoProcedimentoModel, NotaAvaliacaoProcedimento>()
                .ForMember(x => x.Inspecao, y => y.Ignore())
                .ConvertUsing((src, dst) =>
                {
                    return new NotaAvaliacaoProcedimento(

                        src.id_notaAvaliacaoProcedimento,
                        src.especificosLocal,
                        src.organizacaoSeguranca,
                        src.treinamentoConscientizacaoSeguranca,
                        src.segurancaEmergenciaExpatriados
                    );
                });
        }
    }
}