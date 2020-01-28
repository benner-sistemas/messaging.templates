using Benner.Corporativo.Contabilizacao.Models;
using Benner.Listener;
using System;

namespace Benner.Corporativo.Contabilizacao.Consumer
{
    public class ContabilizacaoConsumer : EnterpriseIntegrationConsumerBase
    {
        public override IEnterpriseIntegrationSettings Settings => new EnterpriseIntegrationSettings()
        {
            QueueName = "fila-contabilizacao",
            RetryIntervalInMilliseconds = 1000,
            RetryLimit = 4,
        };

        public override void OnDeadMessage(string message, Exception exception)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
            if (request == null)
                throw new ArgumentNullException($"Request não é '{nameof(ContabilizacaoRequest)}'");

            // fazer algo com a request
            LogInformation("ContabilizacaoConsumer.OnDeadMessage {requestId}:", request.RequestID);
        }

        public override void OnInvalidMessage(string message, InvalidMessageException exception)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
            if (request == null)
                throw new ArgumentNullException($"Request não é '{nameof(ContabilizacaoRequest)}'");

           //LogInformation("PessoaConsumer.OnInvalidMessage {requestId}:", request.RequestID);
        }

        public override void OnMessage(string message)
        {
            var txtMsgInvalida = "mensagem-invalida";
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
            try
            {
                if (message == txtMsgInvalida)
                    throw new InvalidMessageException("Texto inválido!");

                if (request == null)
                    throw new ArgumentNullException($"Request não é '{nameof(request)}'");

                if (request.DataEmissao == null)
                    throw new InvalidMessageException("Data de Emissão deve ser informada!");

                if(request.DataEntrada == null)
                    throw new InvalidMessageException("Data de Entrada deve ser informada!");

                if (request.IDEmpresa == null)
                    throw new InvalidMessageException("Empresa deve ser inforada!");

                if (request.IDFilial == null)
                    throw new InvalidMessageException("Filial deve ser informada!");

                //LogInformation("ContabilizacaoConsumer.OnMessage {requestId}:", request.RequestID);

            }
            catch (Exception e)
            {
                LogError(e, "Erro OnMessage: {requestId}:", request?.RequestID);
                throw;
            }
        }
    }
}