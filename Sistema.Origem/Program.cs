using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Sistema.Origem
{
    class Program
    {
        private readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {


            var request = new
            {
                Url = "/api/contabilizacao",
                Body = new
                {
                    RequestID = Guid.NewGuid(),
                    IDEmpresa = 0,
                    IDFilial = 0,
                    DataEmissao = new DateTime(1983, 3, 30),
                    DataEntrada = new DateTime(1983, 3, 30),
                    TipoRegistro = 0,
                    Tag = "sucesso"
                    //Tag = "erro-aleatorio-de-infra"
                    //Tag = "erro-msg-invalida"
                },
            };

            //var httpResponse = client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

        }
    }

    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}