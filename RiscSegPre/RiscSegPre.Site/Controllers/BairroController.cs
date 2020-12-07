using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class BairroController : Controller
    {
        private readonly IBairroRepository bairroRepository;
        private readonly IDelegaciaPoliciaCivilRepository delegaciaPoliciaCivilRepository;
        private readonly IBatalhaoPoliciaMilitarRepository batalhaoPoliciaMilitarRepository;
        private readonly IRiscoRepository riscoRepository;

        public BairroController(IBairroRepository bairroRepository, IDelegaciaPoliciaCivilRepository delegaciaPoliciaCivilRepository, IBatalhaoPoliciaMilitarRepository batalhaoPoliciaMilitarRepository, IRiscoRepository riscoRepository)
        {
            this.bairroRepository = bairroRepository;
            this.delegaciaPoliciaCivilRepository = delegaciaPoliciaCivilRepository;
            this.batalhaoPoliciaMilitarRepository = batalhaoPoliciaMilitarRepository;
            this.riscoRepository = riscoRepository;
        }

        public ActionResult Index()
        {

            var bairros = bairroRepository.GetAll()
                .Include(x => x.id_delegaciaNavigation)
                .Include(x => x.id_batalhaoNavigation)
                .Include(x => x.id_riscoNavigation);

            return View(bairros);
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
        public ActionResult Create(Bairro bairro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bairroRepository.Insert(bairro);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.ItensDelegacias = CarregarDelegacias(id);
            ViewBag.ItensBatalhoes = CarregarBatalhoes(id);
            ViewBag.ItensRiscos = CarregarRiscos(id);
            return View(bairroRepository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bairro bairro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bairroRepository.Update(bairro);
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
                var objeto = bairroRepository.GetById(id);
                var result = string.Empty;

                if (objeto != null)
                    bairroRepository.Delete(objeto);

                else
                    result = "Error";

                return Json(new { data = result });
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> CarregarDelegacias(int id = 0)
        {
            if (id > 0)
                return new SelectList(delegaciaPoliciaCivilRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(delegaciaPoliciaCivilRepository.GetDictionary(), "Key", "Value");
        }

        private IEnumerable<SelectListItem> CarregarBatalhoes(int id = 0)
        {
            if (id > 0)
                return new SelectList(batalhaoPoliciaMilitarRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(batalhaoPoliciaMilitarRepository.GetDictionary(), "Key", "Value");
        }

        private IEnumerable<SelectListItem> CarregarRiscos(int id = 0)
        {
            if (id > 0)
                return new SelectList(riscoRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(riscoRepository.GetDictionary(), "Key", "Value");
        }
    }
}
