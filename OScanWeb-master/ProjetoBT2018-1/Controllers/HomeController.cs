using ProjetoBT2018_1.Models;
using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjetoBT2018_1.Controllers
{
    public class HomeController : Controller
    {
        private BcUsuario bcUsuario = new BcUsuario();
        HttpCookie cookie;

        // Aqui eu criei uma action que redireciona o usuario para tela de login.
        // Essa Action esta configurada como rota default caso o usuario não especifique o caminho na url.
        public ActionResult Login()
        {
            cookie = Request.Cookies["Login"];
            if (cookie != null)
            {
                return RedirectToAction("Index", "Usuario");
            }

            Usuario usuario = new Usuario();
            return View(usuario);
        }

        // Aqui eu crei uma action que ira receber os valores digitados pelo usuario no Form de login 
        // Essa action ira realizar a autenticação do usuario conforme nossa base de dados
        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            usuario = new BcUsuario().Autenticar(usuario.Email, usuario.Senha);

            if (usuario.Id != 0)
            {
                cookie = new HttpCookie("Login");
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Values.Set("User", usuario.Id.ToString());
                Response.SetCookie(cookie);

                return RedirectToAction("Index", "Usuario");
            }


            ModelState.AddModelError("", "E-mail e/ou senha invalida!");

            return View();
        }

        // Aqui eu criei uma action que ira redirecionar o usuario para tela de cadastro
        // Passando um objeto do tipo usuario vazio para preenchimento
        public ActionResult Cadastrar()
        {
            if(Request.Cookies["Login"] != null)
            {
                return RedirectToAction("Index", "Usuario");
            }
            
            return View(new Usuario());
        }


        // Aqui eu criei uma tarefa assincrona para cadastrar o usuario
        // Ela ira validar o objeto do tipo usuario recebido autencidando pelo banco de dados
        // Caso o usuario não exista no banco, ele será cadastrado
        [HttpPost]
        public async Task<ActionResult> Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (bcUsuario.SelectUsuario(usuario.Email).Id == 0)
                {
                    if (usuario.Senha == usuario.ConfSenha)
                    {
                        await new BcUsuario().Cadastrar(usuario);
                        return View("Login");
                    }

                    ModelState.AddModelError("ConfSenha", "Senhas divergentes!");
                }
                else
                {
                    ModelState.AddModelError("", "Usuário já cadastrado!");
                }
            }
            return View(usuario);
        }

        public ActionResult Logout()
        {
            cookie = Request.Cookies["Login"];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddHours(-0.30);
                Response.SetCookie(cookie);
            }

            return View("Login");
        }


        public ActionResult Login2()
        {

            return View();
        }

        //public string ValidateUser(string email, string senha)
        //{
        //    return new BcSistema().ValidaUser(email, senha) ? "1" : "0";
        //}
    }
}