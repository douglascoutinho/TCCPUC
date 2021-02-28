using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace RiscSegPre.Application.Services
{
    public class ApartamentoService : IApartamentoService
    {
        private readonly IApartamentoRepository repository;
        private readonly IMapper _mapper;

        public ApartamentoService(IApartamentoRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(ApartamentoModel model)
        {
            var apartamento = _mapper.Map<Apartamento>(model);
            repository.Insert(apartamento);
        }

        public void Atualizar(ApartamentoModel model)
        {
            var apartamento = _mapper.Map<Apartamento>(model);
            repository.Update(apartamento);
        }

        public List<ApartamentoModel> ConsultarTodos()
        {
            var apartamentos = repository.GetAll();
            return _mapper.Map<List<ApartamentoModel>>(apartamentos);
        }

        public ApartamentoModel ConsultarPorId(int id)
        {
            var apartamento = repository.GetById(id);
            return _mapper.Map<ApartamentoModel>(apartamento);
        }
        public List<ApartamentoModel> ConsultarPorPredio(int id)
        {
            var apartamento = repository.GetAll(x => x.id_predio ==  id);
            return _mapper.Map<List<ApartamentoModel>>(apartamento);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public bool ExisteApartamento(int id_predio)
        {
            return repository.GetAll(x => x.id_predio == id_predio).Any();
        }

        public IEnumerable<SelectListItem> CarregarApartamentos(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarApartamentos()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
