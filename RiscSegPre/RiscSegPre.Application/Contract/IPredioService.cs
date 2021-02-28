using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IPredioService : IDisposable
    {
        void Cadastrar(PredioModel model);
        List<PredioModel> ConsultarTodos();
        void Atualizar(PredioModel model);
        PredioModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarPredios(int selecionado);
        IEnumerable<SelectListItem> CarregarPredios();
    }
}
