using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class PredioController : Controller
    {
        private readonly IPredioService predioService;
        private readonly IApartamentoService apartamentoService;

        public PredioController(IPredioService predioService, IApartamentoService apartamentoService)
        {
            this.predioService = predioService;
            this.apartamentoService = apartamentoService;
        }

        public ActionResult Index()
        {
            try
            {
                return View(predioService.ConsultarTodos());
            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PredioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    predioService.Cadastrar(model);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                return View(model);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                return View(predioService.ConsultarPorId(id));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PredioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    predioService.Atualizar(model);
                    this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

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
                var existe = apartamentoService.ExisteApartamento(id);

                if (!existe)
                    return Json(new { data = predioService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return View();
            }
        }
    }
}
