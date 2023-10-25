using SistemaLogin.Areas.Cadastros.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaLogin.Areas.Cadastros.Controllers
{
    [Authorize]
    public class PessoasController : Controller
    {
        private static IList<Pessoa> pessoas =
            new List<Pessoa>()
            {
                new Pessoa()
                {
                    PessoaId = 1,
                    Nome = "Marcio"
                },
                new Pessoa()
                {
                    PessoaId = 2,
                    Nome = "Ana"
                }
            };

        // GET: Cadastros/Pessoas
        public ActionResult Index()
        {
            return View(pessoas);
        }
    }
}