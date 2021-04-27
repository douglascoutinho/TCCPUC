using AutoMapper;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace RiscSegPre.Application.Services
{
    public class InspecaoService : IInspecaoService
    {
        private readonly IInspecaoRepository repository;
        private readonly IMapper _mapper;

        public InspecaoService(IInspecaoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(InspecaoModel model)
        {
            var inspecao = _mapper.Map<Inspecao>(model);
            repository.Insert(inspecao);
        }

        public void Atualizar(InspecaoModel model)
        {
            var inspecao = _mapper.Map<Inspecao>(model);
            repository.Update(inspecao);
        }

        public List<InspecaoModel> ConsultarTodos()
        {
            
            var inspecoes = repository.GetAll(); 
            return _mapper.Map<List<InspecaoModel>>(inspecoes);
        }

        public InspecaoModel ConsultarPorId(int id)
        {
            return _mapper.Map<InspecaoModel>(repository.GetById(id));
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public InspecaoModel GerarNota(InspecaoModel model)
        {
            var nota_fisico = _mapper.Map<NotaMeioProtecaoFisico>(model.id_notaMeioProtecaoFisicoNavigation);
            var nota_humano = _mapper.Map<NotaMeioProtecaoHumano>(model.id_notaMeioProtecaoHumanoNavigation);
            var nota_tecnico = _mapper.Map<NotaMeioProtecaoTecnico>(model.id_notaMeioProtecaoTecnicoNavigation);
            var nota_procedimento = _mapper.Map<NotaAvaliacaoProcedimento>(model.id_notaAvaliacaoProcedimentoNavigation);

            var inspecao = new Inspecao(

                nota_fisico,
                nota_humano,
                nota_tecnico,
                nota_procedimento
            );

            inspecao = CalcularNota.CalcularRisco(inspecao);
            model.nota = inspecao.nota;
            model.situacao = inspecao.situacao;
            model.motivoReprovacao = inspecao.motivoReprovacao;

            return model;
        }

        public bool EsixteCliente(int id_cliente)
        {
            return repository.GetAll(x => x.id_cliente == id_cliente).Any();
        }

        public bool ExisteLocal(int id_local)
        {
            return repository.GetAll(x => x.id_local == id_local).Any();
        }

        public bool ExisteCliente(int id_cliente)
        {
            return repository.GetAll(x => x.id_cliente == id_cliente).Any();
        }

        public bool ExisteApartamento(int id_apartamento)
        {
            return repository.GetAll(x => x.id_apartamento == id_apartamento).Any();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}