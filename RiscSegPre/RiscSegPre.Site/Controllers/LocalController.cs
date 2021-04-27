using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class LocalController : Controller
    {
        private readonly ILocalService localService;
        private readonly IInspecaoService inspecaoService;
        private readonly IDelegaciaPoliciaCivilService policiaCivilService;
        private readonly IBatalhaoPoliciaMilitarService policiaMilitarService;
        private readonly IRiscoService riscoService;

        public LocalController(ILocalService localService, IInspecaoService inspecaoService, IDelegaciaPoliciaCivilService policiaCivilService, IBatalhaoPoliciaMilitarService policiaMilitarService, IRiscoService riscoService)
        {
            this.localService = localService;
            this.inspecaoService = inspecaoService;
            this.policiaCivilService = policiaCivilService;
            this.policiaMilitarService = policiaMilitarService;
            this.riscoService = riscoService;
        }

        public ActionResult Index()
        {
            return View(localService.ConsultarTodos());
        }

        public ActionResult Create()
        {
            ViewBag.ItensDelegacias = CarregarDelegacias();
            ViewBag.ItensBatalhoes = CarregarBatalhoes();
            ViewBag.ItensRiscos = CarregarRiscos();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.dt_atualizacao = null;
                    localService.Cadastrar(model);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ItensDelegacias = CarregarDelegacias(model.id_delegacia);
                ViewBag.ItensBatalhoes = CarregarBatalhoes(model.id_batalhao);
                ViewBag.ItensRiscos = CarregarRiscos(model.id_risco);

                return View(model);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var local = localService.ConsultarPorId(id);

            ViewBag.ItensDelegacias = CarregarDelegacias(local.id_delegacia);
            ViewBag.ItensBatalhoes = CarregarBatalhoes(local.id_batalhao);
            ViewBag.ItensRiscos = CarregarRiscos(local.id_risco);

            return View(local);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.dt_atualizacao = DateTime.Now;
                    localService.Atualizar(model);
                    this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ItensDelegacias = CarregarDelegacias(model.id_delegacia);
                ViewBag.ItensBatalhoes = CarregarBatalhoes(model.id_batalhao);
                ViewBag.ItensRiscos = CarregarRiscos(model.id_risco);

                return View(model);
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
                bool existe = inspecaoService.ExisteLocal(id);

                if (!existe)
                    return Json(new { data = localService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return Json(new { data = "Error" });
            }

        }

        private IEnumerable<SelectListItem> CarregarDelegacias(int id = 0)
        {
            if (id > 0)
                return policiaCivilService.CarregarDelegacias(id);
            return policiaCivilService.CarregarDelegacias();
        }

        private IEnumerable<SelectListItem> CarregarBatalhoes(int id = 0)
        {
            if (id > 0)
                return policiaMilitarService.CarregarBatalhoes(id);
            return policiaMilitarService.CarregarBatalhoes();
        }

        private IEnumerable<SelectListItem> CarregarRiscos(int id = 0)
        {
            if (id > 0)
                return riscoService.CarregarRiscos(id);
            return riscoService.CarregarRiscos();
        }
    }
}
