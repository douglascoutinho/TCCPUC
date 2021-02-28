using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IApartamentoService : IDisposable
    {
        void Cadastrar(ApartamentoModel model);
        void Atualizar(ApartamentoModel model);
        List<ApartamentoModel> ConsultarTodos();
        ApartamentoModel ConsultarPorId(int id);
        List<ApartamentoModel> ConsultarPorPredio(int id_predio);
        string Excluir(int id);
        bool ExistePredio(int id_predio);
        IEnumerable<SelectListItem> CarregarApartamentos(int selecionado);
        IEnumerable<SelectListItem> CarregarApartamentos();
    }
}
