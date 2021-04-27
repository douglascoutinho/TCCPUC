using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;
using System;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class BatalhaoPoliciaMilitarController : Controller
    {
        private readonly IBatalhaoPoliciaMilitarService batalhaoPoliciaMilitarService;
        private readonly ILocalService localService;

        public BatalhaoPoliciaMilitarController(IBatalhaoPoliciaMilitarService batalhaoPoliciaMilitarService, ILocalService localService)
        {
            this.batalhaoPoliciaMilitarService = batalhaoPoliciaMilitarService;
            this.localService = localService;
        }

        public ActionResult Index()
        {
            return View(batalhaoPoliciaMilitarService.ConsultarTodos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BatalhaoPoliciaMilitarModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    batalhaoPoliciaMilitarService.Cadastrar(model);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(batalhaoPoliciaMilitarService.ConsultarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BatalhaoPoliciaMilitarModel batalhaoPoliciaMilitar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    batalhaoPoliciaMilitarService.Atualizar(batalhaoPoliciaMilitar);
                    this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                return View();
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
                var existe = localService.ExisteBatalhao(id);

                if (!existe)
                    return Json(new { data = batalhaoPoliciaMilitarService.Excluir(id) });

                else return Json(new { data = "1" });

            }
            catch
            {
                return View();
            }
        }
    }
}
