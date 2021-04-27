using RiscSegPre.Application.Models;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IInspecaoService : IDisposable
    {
        void Cadastrar(InspecaoModel model);
        void Atualizar(InspecaoModel model);
        List<InspecaoModel> ConsultarTodos();
        InspecaoModel ConsultarPorId(int id);
        string Excluir(int id);
        InspecaoModel GerarNota(InspecaoModel model);
        bool ExisteLocal(int id_local);
        bool ExisteCliente(int id_cliente);
        bool ExisteApartamento(int id_apartamento);
    }
}