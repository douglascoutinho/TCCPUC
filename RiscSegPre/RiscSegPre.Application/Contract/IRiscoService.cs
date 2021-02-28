using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Application.Contract
{
    public interface IRiscoService : IDisposable
    {
        IEnumerable<SelectListItem> CarregarRiscos(int selecionado);
        IEnumerable<SelectListItem> CarregarRiscos();
    }
}
