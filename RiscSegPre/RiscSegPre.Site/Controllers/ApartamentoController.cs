using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Collections.Generic;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class ApartamentoController : Controller
    {
        private readonly IApartamentoService apartamentoService;
        private readonly IPredioService predioService;
        private readonly IInspecaoService inspecaoService;

        public ApartamentoController(IApartamentoService apartamentoService, IPredioService predioService, IInspecaoService inspecaoService)
        {
            this.apartamentoService = apartamentoService;
            this.predioService = predioService;
            this.inspecaoService = inspecaoService;
        }

        public ActionResult Index()
        {
            try
            {
                return View(apartamentoService.ConsultarTodos());
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        public ActionResult Create()
        {
            ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApartamentoModel model)
        {
            try
            {
                apartamentoService.Cadastrar(model);
                this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var apartamento = apartamentoService.ConsultarPorId(id);

            ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(apartamento.id_predio);
            return View(apartamentoService.ConsultarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApartamentoModel model)
        {
            try
            {
                apartamentoService.Atualizar(model);
                this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var existe = inspecaoService.ExisteApartamento(id);

                if (!existe)
                    return Json(new { data = apartamentoService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return Json(new { data = "Error" });
            }
        }

        private IEnumerable<SelectListItem> CarregarPredios(int id = 0)
        {
            if (id > 0)
                return predioService.CarregarPredios(id);
            return predioService.CarregarPredios();
        }
    }
}