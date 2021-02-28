using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Domain.IRepositories;
using System.Collections.Generic;

namespace RiscSegPre.Application.Services
{
    public class RiscoService : IRiscoService
    {
        private readonly IRiscoRepository repository;

        public RiscoService(IRiscoRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SelectListItem> CarregarRiscos(int selecionado)
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value", selecionado);
        }

        public IEnumerable<SelectListItem> CarregarRiscos()
        {
            return new SelectList(repository.GetDictionary(), "Key", "Value");
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
