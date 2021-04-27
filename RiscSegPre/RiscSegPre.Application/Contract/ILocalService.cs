using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface ILocalService : IDisposable
    {
        void Cadastrar(LocalModel model);
        void Atualizar(LocalModel model);
        List<LocalModel> ConsultarTodos();
        LocalModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarLocais(int selecionado);
        IEnumerable<SelectListItem> CarregarLocais();
        bool ExisteBatalhao(int id_batalhao);
        bool ExisteDelegacia(int id_delegacia);
    }
}
