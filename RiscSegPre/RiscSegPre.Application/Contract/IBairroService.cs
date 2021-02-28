using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IBairroService : IDisposable
    {
        void Cadastrar(BairroModel model);
        List<BairroModel> ConsultarTodos();
        void Atualizar(BairroModel model);
        BairroModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarBairros(int selecionado);
        IEnumerable<SelectListItem> CarregarBairros();
        bool ExisteBatalhao(int id_batalhao);
    }
}
