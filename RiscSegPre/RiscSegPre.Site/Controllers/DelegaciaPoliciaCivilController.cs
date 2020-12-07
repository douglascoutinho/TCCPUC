using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Linq;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class DelegaciaPoliciaCivilController : Controller
    {

        private readonly IDelegaciaPoliciaCivilRepository delegaciaPoliciaCivilRepository;
        private readonly IBairroRepository bairroRepository;

        public DelegaciaPoliciaCivilController(IDelegaciaPoliciaCivilRepository delegaciaPoliciaCivilRepository, IBairroRepository bairroRepository)
        {
            this.delegaciaPoliciaCivilRepository = delegaciaPoliciaCivilRepository;
            this.bairroRepository = bairroRepository;
        }

        public ActionResult Index()
        {
            return View(delegaciaPoliciaCivilRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DelegaciaPoliciaCivil delegaciaPoliciaCivil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    delegaciaPoliciaCivilRepository.Insert(delegaciaPoliciaCivil);
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
            return View(delegaciaPoliciaCivilRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DelegaciaPoliciaCivil delegaciaPoliciaCivil)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    delegaciaPoliciaCivilRepository.Update(delegaciaPoliciaCivil);
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
                var objetoVinculado = bairroRepository.GetAll(x => x.id_delegacia == id).Any();

                var objeto = delegaciaPoliciaCivilRepository.GetById(id);
                var result = string.Empty;

                if (objetoVinculado)
                    result = "1";

                else if (objeto != null)
                    delegaciaPoliciaCivilRepository.Delete(objeto);

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
