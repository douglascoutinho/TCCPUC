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
    public class BairroService : IBairroService
    {
        private readonly IBairroRepository repository;
        private readonly IMapper _mapper;

        public BairroService(IBairroRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(BairroModel model)
        {
            var bairro = _mapper.Map<Bairro>(model);
            repository.Insert(bairro);
        }

        public List<BairroModel> ConsultarTodos()
        {
            var bairros = repository.GetAll();
            return _mapper.Map<List<BairroModel>>(bairros);
        }

        public void Atualizar(BairroModel model)
        {
            var bairro = _mapper.Map<Bairro>(model);
            repository.Update(bairro);
        }

        public BairroModel ConsultarPorId(int id)
        {
            var bairro = repository.GetById(id);
            return _mapper.Map<BairroModel>(bairro);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarBairros(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarBairros()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public bool ExisteBatalhao(int id_batalhao)
        {
            return repository.GetAll(x => x.id_batalhao == id_batalhao).Any();
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
