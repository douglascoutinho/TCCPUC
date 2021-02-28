using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IClienteService : IDisposable
    {
        void Cadastrar(ClienteModel model);
        void Atualizar(ClienteModel model);
        List<ClienteModel> ConsultarTodos();
        ClienteModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarClientes(int selecionado);
        IEnumerable<SelectListItem> CarregarClientes();
    }
}
