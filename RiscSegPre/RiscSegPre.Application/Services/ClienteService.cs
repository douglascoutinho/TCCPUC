using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;

namespace RiscSegPre.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public void Cadastrar(ClienteModel model)
        {
            var cliente = _mapper.Map<Cliente>(model);
            repository.Insert(cliente);
        }

        public void Atualizar(ClienteModel model)
        {
            var cliente = _mapper.Map<Cliente>(model);
            repository.Update(cliente);
        }

        public List<ClienteModel> ConsultarTodos()
        {
            var clientes = repository.GetAll();
            return _mapper.Map<List<ClienteModel>>(clientes);
        }

        public ClienteModel ConsultarPorId(int id)
        {
            var cliente = repository.GetById(id);
            return _mapper.Map<ClienteModel>(cliente);
        }

        public string Excluir(int id)
        {
            var objeto = repository.GetById(id);

            if (objeto != null)
                repository.Delete(objeto);

            else return "Error";

            return string.Empty;
        }

        public IEnumerable<SelectListItem> CarregarClientes(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarClientes()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
