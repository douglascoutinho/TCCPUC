using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Models;
using RiscSegPre.Site.Extentions.Menssagem;
using System;
using System.Collections.Generic;

namespace RiscSegPre.Site.Controllers
{
    [Authorize]
    public class InspecaoController : Controller
    {
        private readonly IInspecaoService inspecaoService;
        private readonly IPredioService predioService;
        private readonly IApartamentoService apartamentoService;
        private readonly IBairroService bairroService;
        private readonly IClienteService clienteService;

        public InspecaoController(IInspecaoService inspecaoService, IPredioService predioService, IApartamentoService apartamentoService, IBairroService bairroService, IClienteService clienteService)
        {
            this.inspecaoService = inspecaoService;
            this.predioService = predioService;
            this.apartamentoService = apartamentoService;
            this.bairroService = bairroService;
            this.clienteService = clienteService;
        }

        public IActionResult Index()
        {
            try
            {
                return View(inspecaoService.ConsultarTodos());
            }
            catch (Exception e)
            {

                return View(e.Message);
            }
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
        public ActionResult Create(InspecaoModel inspecao, IFormFile fotoApartamento, IFormFile fotoPredio)
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
                    inspecao = inspecaoService.GerarNota(inspecao);

                    inspecao.fotoApartamento = "FA" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoApartamento.ContentType.Split("/")[1];
                    inspecao.fotoPredio = "FP" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoPredio.ContentType.Split("/")[1];

                    inspecaoService.Cadastrar(inspecao);
                    this.ShowMessage(Mensagens.msgCadastroSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.ItensPredios = (IEnumerable<SelectListItem>)CarregarPredios(inspecao.id_predio);
                ViewBag.ItensApartamentos = (IEnumerable<SelectListItem>)CarregarApartamentos(inspecao.id_select == 0 ? inspecao.id_apartamento : inspecao.id_select);
                ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros(inspecao.id_bairro);
                ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes(inspecao.id_cliente);

                inspecao.fotoApartamento = fotoApartamento == null ? string.Empty : fotoApartamento.FileName;
                inspecao.fotoPredio = fotoPredio == null ? string.Empty : fotoPredio.FileName;

                this.ShowMessage("Existe campo(s) que devem ser preenchidos!", ToastrDialogType.Info);

                return View(inspecao);

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
                var inspecao = inspecaoService.ConsultarPorId(id);

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
        public ActionResult Edit(InspecaoModel inspecao, IFormFile fotoApartamento, IFormFile fotoPredio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _inspecao = inspecaoService.ConsultarPorId(inspecao.id_inspecao);

                    if (fotoApartamento == null)
                        inspecao.fotoApartamento = _inspecao.fotoApartamento;

                    else inspecao.fotoApartamento = inspecao.fotoApartamento = "FA" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoApartamento.ContentType.Split("/")[1];

                    if (fotoPredio == null)
                        inspecao.fotoPredio = _inspecao.fotoPredio;

                    else inspecao.fotoPredio = inspecao.fotoPredio = "FP" + DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "").Replace("PM", "").Replace("AM", "") + "." + fotoPredio.ContentType.Split("/")[1];

                    inspecao = inspecaoService.GerarNota(inspecao);
                    inspecaoService.Atualizar(inspecao);
                    this.ShowMessage(Mensagens.msgAlteracaoSucesso, ToastrDialogType.Sucess);
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewData["ItensPredios"] = (IEnumerable<SelectListItem>)CarregarPredios(inspecao.id_predio);
                    ViewBag.ItensApartamentos = (IEnumerable<SelectListItem>)CarregarApartamentos(inspecao.id_apartamento);
                    ViewBag.ItensBairros = (IEnumerable<SelectListItem>)CarregarBairros(inspecao.id_bairro);
                    ViewBag.ItensClientes = (IEnumerable<SelectListItem>)CarregarClientes(inspecao.id_cliente);

                    inspecao.fotoApartamento = fotoApartamento.FileName;
                    inspecao.fotoPredio = fotoPredio.FileName;

                    this.ShowMessage("Existe campo(s) que devem ser preenchidos!", ToastrDialogType.Info);

                    return View(inspecao);
                }
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var existe = inspecaoService.ConsultarPorId(id);

                if (existe != null)
                    return Json(new { data = inspecaoService.Excluir(id) });

                else return Json(new { data = "1" });
            }
            catch
            {
                return Json(new { data = "Error" });
            }
        }

        [HttpGet]
        public JsonResult GetSelectApartamento(int id)
        {
            var itens = apartamentoService.ConsultarPorPredio(id);
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
                return predioService.CarregarPredios(id);
            return predioService.CarregarPredios();
        }

        private IEnumerable<SelectListItem> CarregarApartamentos(int id = 0)
        {
            if (id > 0)
                return apartamentoService.CarregarApartamentos(id);
            return apartamentoService.CarregarApartamentos();
        }

        private IEnumerable<SelectListItem> CarregarBairros(int id = 0)
        {
            if (id > 0)
                return bairroService.CarregarBairros(id);
            return bairroService.CarregarBairros();
        }

        private IEnumerable<SelectListItem> CarregarClientes(int id = 0)
        {
            if (id > 0)
                return clienteService.CarregarClientes(id);
            return clienteService.CarregarClientes();
        }
    }
}
