using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Linq;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class PredioController : Controller
    {

        private readonly IPredioRepository predioRepository;
        private readonly IApartamentoRepository apartamentoRepository;

        public PredioController(IPredioRepository predioRepository, IApartamentoRepository apartamentoRepository)
        {
            this.predioRepository = predioRepository;
            this.apartamentoRepository = apartamentoRepository;
        }

        public ActionResult Index()
        {
            var predios = predioRepository.GetAll();
            return View(predios);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Predio predio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    predioRepository.Insert(predio);
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
            var predio = predioRepository.GetById(id);
            return View(predio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Predio predio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    predioRepository.Update(predio);
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
               var objetoVinculado =  apartamentoRepository.GetAll(x => x.id_predio == id).Any();

                var objeto = predioRepository.GetById(id);
                var result = string.Empty;

                if (objetoVinculado)
                    result = "1";

                else if (objeto != null)
                    predioRepository.Delete(objeto);

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
