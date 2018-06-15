using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AS.ProjetoCompleto.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "Ocorreu um erro";
            ViewBag.Mensagem = "Ocorreu um erro, ente novamente ou contate o administrador.";
            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.Mensagem = "Não existe página para URL informada";
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Acesso Negado!";
            ViewBag.Mensagem = "Você não tem permissão para executar este comando.";
            return View("Error");
        }
    }
}