using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public ActionResult Index()
        {
            var clientes = clienteRepository.GetAll();
            return View(clientes);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteRepository.Insert(cliente);
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
            var cliente = clienteRepository.GetById(id);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteRepository.Update(cliente);
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
                var objeto = clienteRepository.GetById(id);
                var result = string.Empty;

                if (objeto != null)
                    clienteRepository.Delete(objeto);

                else
                    result = "Error";

                return Json(new { data = result });
            }
            catch
            {
                return View();
            }
        }
    }
}
