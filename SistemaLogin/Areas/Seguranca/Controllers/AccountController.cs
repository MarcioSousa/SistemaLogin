using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SistemaLogin.Areas.Seguranca.Data;
using SistemaLogin.Infraestrutura;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SistemaLogin.Areas.Seguranca.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login details, string returnUrl)
        {
            //LoginViewModel = Login
            if (ModelState.IsValid)
            {
                Usuario user = UserManager.Find(details.Nome, details.Senha);

                if (user == null)
                {
                    ModelState.AddModelError("", "Nome ou senha inválido(s).");
                }
                else
                {
                    ClaimsIdentity ident = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = false
                    }, ident);
                    if (returnUrl == null)
                    {
                        returnUrl = "../../Cadastros/Pessoas";
                    }
                    return RedirectToAction(returnUrl);
                }
            }
            return View(details);
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private GerenciadorUsuario UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<GerenciadorUsuario>();
            }
        }

    }
}