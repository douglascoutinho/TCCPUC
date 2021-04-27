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
    public class LocalService : ILocalService
    {
        private readonly ILocalRepository repository;
        private readonly IMapper _mapper;

        public LocalService(ILocalRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(LocalModel model)
        {
            var local = _mapper.Map<Local>(model);
            repository.Insert(local);
        }
        public void Atualizar(LocalModel model)
        {
            var local = _mapper.Map<Local>(model);
            repository.Update(local);
        }

        public List<LocalModel> ConsultarTodos()
        {
            var locais = repository.GetAll();
            return _mapper.Map<List<LocalModel>>(locais);
        }
        
        public LocalModel ConsultarPorId(int id)
        {
            var local = repository.GetById(id);
            return _mapper.Map<LocalModel>(local);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarLocais(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarLocais()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public bool ExisteBatalhao(int id_batalhao)
        {
            return repository.GetAll(x => x.id_batalhao == id_batalhao).Any();
        }

        public bool ExisteDelegacia(int id_delegacia)
        {
            return repository.GetAll(x => x.id_delegacia == id_delegacia).Any();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
