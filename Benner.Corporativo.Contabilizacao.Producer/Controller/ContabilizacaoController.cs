using Benner.Corporativo.Contabilizacao.Models;
using Benner.Enterprise.Integration.Messaging;
using Benner.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace Benner.Corporativo.Contabilizacao.Producer.Controller
{
    /// <summary>
    /// API para recebimento de contabilização
    /// </summary>
    [Route("api/contabilizacao")]
    [ApiController]
    public class ContabilizacaoController : MessagingController
    {
        protected override string QueueName { get => "fila-contabilizacao"; }

        /// <summary>
        /// Aqui é necessário enviar isso, isso e aquilo, e o comportamento será x, y, z
        /// </summary>
        /// <param name="request">Uma solicitação de contabilização</param>
        /// <returns>Um novo EnterpriseIntegrationResponse</returns>
        /// <response code="201">Returna um ticket bem legal</response>
        // POST api/contabilizacao
        [HttpPost]
        [ProducesResponseType(typeof(IEnterpriseIntegrationResponse), 201)]
        public ActionResult<IEnterpriseIntegrationResponse> Post([FromBody] ContabilizacaoRequest request)
        {
            return base.Enqueue(request as IEnterpriseIntegrationRequest);
        }
    }
}