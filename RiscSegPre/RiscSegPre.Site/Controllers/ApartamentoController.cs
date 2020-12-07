using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System.Collections.Generic;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class ApartamentoController : Controller
    {
        private readonly IPredioRepository predioRepository;
        private readonly IApartamentoRepository apartamentoRepository;

        public ApartamentoController(IPredioRepository predioRepository, IApartamentoRepository apartamentoRepository)
        {
            this.predioRepository = predioRepository;
            this.apartamentoRepository = apartamentoRepository;
        }

        public ActionResult Index()
        {
            return View(apartamentoRepository.GetAll().Include(x => x.id_predioNavigation));
        }

        public ActionResult Create()
        {
            ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Apartamento apartamento)
        {
            try
            {
                apartamentoRepository.Insert(apartamento);
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
            var apartamento =  apartamentoRepository.GetById(id);

            ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(apartamento.id_predio);
            return View(apartamentoRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Apartamento apartamento)
        {
            try
            {
                apartamentoRepository.Update(apartamento);
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
                var objeto = apartamentoRepository.GetById(id);
                var result = string.Empty;

                if (objeto != null)
                    apartamentoRepository.Delete(objeto);

                else
                    result = "Error";

                return Json(new { data = result });
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> CarregarPredios(int id = 0)
        {
            if (id > 0)
                return new SelectList(predioRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(predioRepository.GetDictionary(), "Key", "Value");
        }
    }
}