using ProjetoBT2018_1.Models.Dominio;
using ProjetoBT2018_1.Models.Repositorios;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjetoBT2018_1.Models
{
    public class BcUsuario 
    {
        public Usuario Autenticar(string email, string senha)
        {
            var response = new ApiRepositorio().Get(string.Format("api/Usuarios/{0}/{1}", email, senha));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Usuario>().Result;
            }

            return new Usuario();
        }

        public Usuario SelectUsuario(string email)
        {
            var response = new ApiRepositorio().Get(string.Format("api/Usuarios/{0}", email));
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Usuario>().Result;
            }

            return new Usuario();
        }

        public async Task Cadastrar(Usuario usuario)
        {
            await new ApiRepositorio().Post("api/Usuarios", usuario);
        }
    }
}