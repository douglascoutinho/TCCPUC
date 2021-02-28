using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;

namespace RiscSegPre.Application.Services
{
    public class PredioService : IPredioService
    {
        private readonly IPredioRepository repository;
        private readonly IMapper _mapper;

        public PredioService(IPredioRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(PredioModel model)
        {
            var predio = _mapper.Map<Predio>(model);
            repository.Insert(predio);
        }
        public void Atualizar(PredioModel model)
        {
            var predio = _mapper.Map<Predio>(model);
            repository.Update(predio);
        }

        public List<PredioModel> ConsultarTodos()
        {
            var predios = repository.GetAll();
            return _mapper.Map<List<PredioModel>>(predios);
        }

        public PredioModel ConsultarPorId(int id)
        {
            var predio = repository.GetById(id);
            return _mapper.Map<PredioModel>(predio);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarPredios(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarPredios()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
