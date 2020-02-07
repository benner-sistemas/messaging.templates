using IdentityModel.Client;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Sistema.Origem
{
    class Program
    {
        private static HttpClient _client = new HttpClient();

        public static void Main(string[] args)
        {
            var passwordRequest = new PasswordTokenRequest
            {
                Address = "http://bnu-vtec012:7600/auth/realms/master/protocol/openid-connect/token",
                ClientId = "producer-api",
                ClientSecret = "54835680-02b3-4477-a5bc-a5b3cafe223d",
                UserName = "usuario.123",
                Password = "benner",
                Scope = "openid profile email updated_at groups",
            };

            var passwordResponse = _client.RequestPasswordTokenAsync(passwordRequest).Result;

            var random = new Random();

            try
            {
                for (int index = 0; index < 10000; ++index)
                {
                    var request = new
                    {
                        Url = "http://localhost:5004/api/contabilizacao",
                        Body = new
                        {
                            RequestID = Guid.NewGuid(),
                            IDEmpresa = $"{random.Next(0, 10_000)}-msg_index:{index}",
                            IDFilial = random.Next(0, 10_000),
                            DataEmissao = new DateTime(1980, 1, 1).AddDays(random.Next(0, 11_000)),
                            DataEntrada = new DateTime(1980, 1, 1).AddDays(random.Next(0, 11_000)),
                            TipoRegistro = random.Next(0, 10_000),
                            //Tag = "sucesso"
                            //Tag = "erro-aleatorio-de-infra"
                            Tag = "erro-msg-invalida"
                        },
                    };
                    _client.SetBearerToken(passwordResponse.AccessToken);
                    var httpResponse = _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body)).Result;

                    Console.WriteLine($"Mensagem {request.Body.RequestID} índice {index} enviada com sucesso");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }

    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}