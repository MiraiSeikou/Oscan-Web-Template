using Newtonsoft.Json;
using ProjetoBT2018_1.Models.Dominio;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBT2018_1.Models.Repositorios
{
    public class ApiRepositorio
    {
        HttpClient client;

        public ApiRepositorio()
        {
            client = new HttpClient();
            client.BaseAddress = new System.Uri("https://oscanwebapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string endPoint)
        {
            using (client)
            {
                return client.GetAsync(endPoint).Result;
            }
        }

        public async Task<HttpResponseMessage> Post(string endPoint, object obj)
        {
            var serializedProduto = JsonConvert.SerializeObject(obj);
            var content = new StringContent(serializedProduto, Encoding.UTF8, "application/json");

            using (client)
            {
                return await client.PostAsync(client.BaseAddress + endPoint, content);
            }
        }
    }
}