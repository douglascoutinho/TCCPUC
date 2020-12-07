using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Linq;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class BatalhaoPoliciaMilitarController : Controller
    {
        private readonly IBatalhaoPoliciaMilitarRepository batalhaoPoliciaMilitarRepository;
        private readonly IBairroRepository bairroRepository;

        public BatalhaoPoliciaMilitarController(IBatalhaoPoliciaMilitarRepository batalhaoPoliciaMilitarRepository, IBairroRepository bairroRepository)
        {
            this.batalhaoPoliciaMilitarRepository = batalhaoPoliciaMilitarRepository;
            this.bairroRepository = bairroRepository;
        }

        public ActionResult Index()
        {
            return View(batalhaoPoliciaMilitarRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BatalhaoPoliciaMilitar batalhaoPoliciaMilitar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    batalhaoPoliciaMilitarRepository.Insert(batalhaoPoliciaMilitar);
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
            return View(batalhaoPoliciaMilitarRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BatalhaoPoliciaMilitar batalhaoPoliciaMilitar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    batalhaoPoliciaMilitarRepository.Update(batalhaoPoliciaMilitar);
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
                var objetoVinculado = bairroRepository.GetAll(x => x.id_batalhao == id).Any();

                var objeto = batalhaoPoliciaMilitarRepository.GetById(id);
                var result = string.Empty;

                if (objetoVinculado)
                    result = "1";

                else if (objeto != null)
                    batalhaoPoliciaMilitarRepository.Delete(objeto);

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
