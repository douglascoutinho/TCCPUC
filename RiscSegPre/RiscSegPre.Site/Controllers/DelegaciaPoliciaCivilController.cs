using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class DelegaciaPoliciaCivilController : Controller
    {

        private readonly IDelegaciaPoliciaCivilService policiaCivilService;
        private readonly ILocalService localService;

        public DelegaciaPoliciaCivilController(IDelegaciaPoliciaCivilService policiaCivilService, ILocalService localService)
        {
            this.policiaCivilService = policiaCivilService;
            this.localService = localService;
        }

        public ActionResult Index()
        {
            return View(policiaCivilService.ConsultarTodos());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DelegaciaPoliciaCivilModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    policiaCivilService.Cadastrar(model);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(policiaCivilService.ConsultarPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DelegaciaPoliciaCivilModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    policiaCivilService.Atualizar(model);
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
                var existe = localService.ExisteDelegacia(id);

                if (!existe)
                    return Json(new { data = policiaCivilService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return View();
            }
        }
    }
}
