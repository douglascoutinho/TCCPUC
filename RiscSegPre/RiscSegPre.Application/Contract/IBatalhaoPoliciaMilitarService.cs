﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IBatalhaoPoliciaMilitarService : IDisposable
    {
        void Cadastrar(BatalhaoPoliciaMilitarModel model);
        void Atualizar(BatalhaoPoliciaMilitarModel model);
        List<BatalhaoPoliciaMilitarModel> ConsultarTodos();
        BatalhaoPoliciaMilitarModel ConsultarPorId(int id);
        string Excluir(int id);
        IEnumerable<SelectListItem> CarregarBatalhoes(int selecionado);
        IEnumerable<SelectListItem> CarregarBatalhoes();
    }
}
