using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Site.Extentions.Menssagem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class InspecaoController : Controller
    {
        private readonly IInspecaoRepository inspecaoRepository;
        private readonly IPredioRepository predioRepository;
        private readonly IApartamentoRepository apartamentoRepository;
        private readonly IBairroRepository bairroRepository;
        private readonly IClienteRepository clienteRepository;

        public InspecaoController(IInspecaoRepository inspecaoRepository, IPredioRepository predioRepository, IApartamentoRepository apartamentoRepository, IBairroRepository bairroRepository, IClienteRepository clienteRepository)
        {
            this.inspecaoRepository = inspecaoRepository;
            this.predioRepository = predioRepository;
            this.apartamentoRepository = apartamentoRepository;
            this.bairroRepository = bairroRepository;
            this.clienteRepository = clienteRepository;
        }

        public ActionResult Index()
        {
            var inspecoes = inspecaoRepository.GetAll()
                .Include(x => x.id_predioNavigation)
                .Include(x => x.id_apartamentoNavigation)
                .Include(x => x.id_bairroNavigation)
                .Include(x => x.id_clienteNavigation);

            return View(inspecoes);
        }

        public ActionResult Create()
        {
            ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios();
            ViewBag.ItensApartamentos = new List<SelectListItem>();
            ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros();
            ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inspecao inspecao, IFormFile fotoApartamento, IFormFile fotoPredio)
        {
            try
            {
                if (fotoApartamento == null)
                    ModelState.AddModelError("fotoApartamento", "Campo Obrigatorio.");

                if (fotoPredio == null)
                    ModelState.AddModelError("fotoPredio", "Campo Obrigatorio.");

                if (inspecao.id_apartamento == 0)
                    ModelState.AddModelError("id_apartamento", "Campo Obrigatorio.");

                if (inspecao.id_predio == 0)
                    ModelState.AddModelError("id_apartamento", "Campo Obrigatorio.");

                if (ModelState.IsValid)
                {
                    inspecao = CalcularNota.CalcularRisco(inspecao);

                    inspecao.fotoApartamento = "FA" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoApartamento.ContentType.Split("/")[1];
                    inspecao.fotoPredio = "FP" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoPredio.ContentType.Split("/")[1];

                    inspecaoRepository.Insert(inspecao);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }
                else
                 {
                    ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(inspecao.id_predio);
                    ViewBag.ItensApartamentos = (IEnumerable<SelectListItem>)CarregarApartamentos(inspecao.id_select == 0 ? inspecao.id_apartamento : inspecao.id_select);
                    ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros(inspecao.id_bairro);
                    ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes(inspecao.id_cliente);

                    inspecao.fotoApartamento = fotoApartamento == null ? string.Empty : fotoApartamento.FileName;
                    inspecao.fotoPredio = fotoPredio == null ? string.Empty : fotoPredio.FileName;

                    this.ShowMessage("Existe campo(s) que devem ser preenchidos!", ToastrDialogType.Info);

                    return View(inspecao);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var inspecao = inspecaoRepository.GetAll()
                                             .AsNoTracking()
                                             .Include(x => x.id_notaAvaliacaoProcedimentoNavigation)
                                             .Include(x => x.id_notaMeioProtecaoFisicoNavigation)
                                             .Include(x => x.id_notaMeioProtecaoTecnicoNavigation)
                                             .Include(x => x.id_notaMeioProtecaoHumanoNavigation)
                                             .Where(x => x.id_inspecao == id)
                                             .FirstOrDefault();

                ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(inspecao.id_predio);
                ViewBag.ItensApartamentos = (IEnumerable<SelectListItem>)CarregarApartamentos(inspecao.id_apartamento);
                ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros(inspecao.id_bairro);
                ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes(inspecao.id_cliente);
                return View(inspecao);
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Inspecao inspecao, IFormFile fotoApartamento, IFormFile fotoPredio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _inspecao = inspecaoRepository.GetAll()
                                                      .AsNoTracking()
                                                      .Where(x => x.id_inspecao == inspecao.id_inspecao)
                                                      .FirstOrDefault();

                    if (fotoApartamento == null)
                        inspecao.fotoApartamento = _inspecao.fotoApartamento;

                    else inspecao.fotoApartamento = inspecao.fotoApartamento = "FA" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM","").Replace("AM","") + "." + fotoApartamento.ContentType.Split("/")[1];

                    if (fotoPredio == null)
                        inspecao.fotoPredio = _inspecao.fotoPredio;

                    else inspecao.fotoPredio = inspecao.fotoPredio = "FP" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoPredio.ContentType.Split("/")[1];
                    
                    inspecao = CalcularNota.CalcularRisco(inspecao);
                    inspecaoRepository.Update(inspecao);
                    this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(inspecao.id_predio);
                    ViewBag.ItensApartamentos = (IEnumerable<SelectListItem>)CarregarApartamentos(inspecao.id_apartamento);
                    ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros(inspecao.id_bairro);
                    ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes(inspecao.id_cliente);

                    inspecao.fotoApartamento = fotoApartamento.FileName;
                    inspecao.fotoPredio = fotoPredio.FileName;

                    this.ShowMessage("Existe campo(s) que devem ser preenchidos!", ToastrDialogType.Info);

                    return View(inspecao);
                }
            }
            catch(Exception e)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var objeto = inspecaoRepository.GetById(id);
                var result = string.Empty;

                if (objeto != null)
                    inspecaoRepository.Delete(objeto);

                else
                    result = "Error";

                return Json(new { data = result });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public JsonResult GetSelectApartamento(int id)
        {
            var itens = apartamentoRepository.GetAll(x => x.id_predio == id);
            var Lista = new List<SelectListItem>();
            foreach (var Linha in itens)
            {
                Lista.Add(new SelectListItem()
                {
                    Value = Linha.id_apartamento.ToString(),
                    Text = Linha.nm_apartamento,
                    Selected = false
                });
            }
            return Json(Lista);
        }

        private IEnumerable<SelectListItem> CarregarPredios(int id = 0)
        {
            if (id > 0)
                return new SelectList(predioRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(predioRepository.GetDictionary(), "Key", "Value");
        }

        private IEnumerable<SelectListItem> CarregarApartamentos(int id = 0)
        {
            if (id > 0)
                return new SelectList(apartamentoRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(apartamentoRepository.GetDictionary(), "Key", "Value");
        }

        private IEnumerable<SelectListItem> CarregarBairros(int id = 0)
        {
            if (id > 0)
                return new SelectList(bairroRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(bairroRepository.GetDictionary(), "Key", "Value");
        }

        private IEnumerable<SelectListItem> CarregarClientes(int id = 0)
        {
            if (id > 0)
                return new SelectList(clienteRepository.GetDictionary(), "Key", "Value", id);
            return new SelectList(clienteRepository.GetDictionary(), "Key", "Value");
        }
    }
}
