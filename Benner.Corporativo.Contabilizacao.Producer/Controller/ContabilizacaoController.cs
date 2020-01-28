using Benner.Corporativo.Contabilizacao.Models;
using Benner.Messaging;
using Benner.Messaging.Core;
using Microsoft.AspNetCore.Mvc;

namespace Benner.Corporativo.Contabilizacao.Producer.Controller
{
    [Route("api/contabilizacao")]
    [ApiController]
    public class ContabilizacaoController : MessagingController
    {
        protected override string QueueName { get => "fila-contabilizacao"; }

        // POST api/contabilizacao
        [HttpPost]
        public ActionResult<IEnterpriseIntegrationResponse> Post([FromBody] ContabilizacaoRequest request)
        {
            return base.Enqueue(request as IEnterpriseIntegrationRequest);
        }
    }
}