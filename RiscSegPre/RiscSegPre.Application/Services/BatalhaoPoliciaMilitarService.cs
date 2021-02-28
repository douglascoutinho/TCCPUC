using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;

namespace RiscSegPre.Application.Services
{
    public class BatalhaoPoliciaMilitarService : IBatalhaoPoliciaMilitarService
    {
        private readonly IBatalhaoPoliciaMilitarRepository repository;
        private readonly IMapper _mapper;

        public BatalhaoPoliciaMilitarService(IBatalhaoPoliciaMilitarRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(BatalhaoPoliciaMilitarModel model)
        {
            var batalhao = _mapper.Map<BatalhaoPoliciaMilitar>(model);
            repository.Insert(batalhao);
        }

        public void Atualizar(BatalhaoPoliciaMilitarModel model)
        {
            var batalhao = _mapper.Map<BatalhaoPoliciaMilitar>(model);
            repository.Update(batalhao);
        }

        public List<BatalhaoPoliciaMilitarModel> ConsultarTodos()
        {
            var batalhoes = repository.GetAll();
            return _mapper.Map<List<BatalhaoPoliciaMilitarModel>>(batalhoes);
        }

        public BatalhaoPoliciaMilitarModel ConsultarPorId(int id)
        {
            var batalhao = repository.GetById(id);
            return _mapper.Map<BatalhaoPoliciaMilitarModel>(batalhao);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarBatalhoes(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarBatalhoes()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
