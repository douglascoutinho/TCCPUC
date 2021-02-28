using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;

namespace RiscSegPre.Application.Services
{
    public class DelegaciaPoliciaCivilService : IDelegaciaPoliciaCivilService
    {
        private readonly IDelegaciaPoliciaCivilRepository repository;
        private readonly IMapper _mapper;

        public DelegaciaPoliciaCivilService(IDelegaciaPoliciaCivilRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(DelegaciaPoliciaCivilModel model)
        {
            var delegacia = _mapper.Map<DelegaciaPoliciaCivil>(model);
            repository.Insert(delegacia);
        }

        public void Atualizar(DelegaciaPoliciaCivilModel model)
        {
            var delegacia = _mapper.Map<DelegaciaPoliciaCivil>(model);
            repository.Update(delegacia);
        }

        public List<DelegaciaPoliciaCivilModel> ConsultarTodos()
        {
            var delegacias = repository.GetAll();
            return _mapper.Map<List<DelegaciaPoliciaCivilModel>>(delegacias);
        }

        public DelegaciaPoliciaCivilModel ConsultarPorId(int id)
        {
            var delegacia = repository.GetById(id);
            return _mapper.Map<DelegaciaPoliciaCivilModel>(delegacia);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarDelegacias(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarDelegacias()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
