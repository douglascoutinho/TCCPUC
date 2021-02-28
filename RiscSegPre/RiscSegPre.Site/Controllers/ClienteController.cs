using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Linq;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteService clienteService;
        private readonly IInspecaoService inspecaoService;

        public ClienteController(IClienteService clienteService, IInspecaoService inspecaoService)
        {
            this.clienteService = clienteService;
            this.inspecaoService = inspecaoService;
        }

        public ActionResult Index()
        {
            try
            {
                return View(clienteService.ConsultarTodos());

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
        public ActionResult Create(ClienteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.Cadastrar(model);
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
            try
            {
                return View(clienteService.ConsultarPorId(id));

            }
            catch (System.Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteService.Atualizar(model);
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
                var existe = inspecaoService.ExisteCliente(id);

                if (!existe)
                    return Json(new { data = clienteService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return Json(new { data = "Error" });
            }
        }
    }
}
