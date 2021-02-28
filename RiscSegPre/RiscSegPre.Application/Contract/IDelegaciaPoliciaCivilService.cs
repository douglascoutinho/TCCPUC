using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IDelegaciaPoliciaCivilService : IDisposable
    {
        void Cadastrar(DelegaciaPoliciaCivilModel model);
        void Atualizar(DelegaciaPoliciaCivilModel model);
        List<DelegaciaPoliciaCivilModel> ConsultarTodos();
        DelegaciaPoliciaCivilModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarDelegacias(int selecionado);
        IEnumerable<SelectListItem> CarregarDelegacias();
    }
}
