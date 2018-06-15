using AS.ProjetoCompleto.Application.Interfaces;
using AS.ProjetoCompleto.Application.Services;
using AS.ProjetoCompleto.Application.ViewModels;
using AS.ProjetoCompleto.Infra.CrossCutting.AspNetFilters;
using AS.ProjetoCompleto.UI.Web.Models;
using System;
using System.Web.Mvc;

namespace AS.ProjetoCompleto.UI.Web.Controllers
{
    //esta camada só recebe método (da view) e invoca a ClienteAppService

    [Authorize]//bloqueia todas as actions da controller
    [RoutePrefix("area-adm/gestao-clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController()
        {
            _clienteAppService = new ClienteAppService();
        }

        [ClaimsAuthorize("Gestao cliente","LT")]
        [Route("listar-todos")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [ClaimsAuthorize("Gestao cliente","DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var cliente = _clienteAppService.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [ClaimsAuthorize("Gestao cliente","IN")]
        [Route("criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ClaimsAuthorize("Gestao cliente","IN")]
        [ValidateAntiForgeryToken]
        [Route("criar-novo")]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Adicionar(clienteEnderecoViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteEnderecoViewModel);
        }

        [ClaimsAuthorize("Gestao cliente","ED")]
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [HttpPost]
        [ClaimsAuthorize("Gestao cliente","ED")]
        [Route("{id:guid}/editar")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Gestao cliente","EX")]
        [Authorize(Roles ="Admin, Coord")]
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var clienteViewModel = _clienteAppService.ObterPorId(id);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("Gestao cliente","EX")]
        [Authorize(Roles ="Admin, Coord")]
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCofirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
