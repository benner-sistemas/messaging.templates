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
            RetryIntervalInMilliseconds = 5000,
            RetryLimit = 4,
        };

        public override void OnDeadMessage(string message, Exception exception)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
            if (request == null)
                throw new ArgumentNullException($"Request não é '{nameof(ContabilizacaoRequest)}'");

            //LogInformation("Executando regra de negócio de mensagem morta da contabilização. Requisição {request}", request.RequestID);
        }

        public override void OnInvalidMessage(string message, InvalidMessageException exception)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
            if (request == null)
                throw new ArgumentNullException($"Request não é '{nameof(ContabilizacaoRequest)}'");


            //LogInformation("Executando regra de negócio de mensagem inválida da contabilização. Requisição {request}", request.RequestID);
        }

        public override void OnMessage(string message)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);

            if (request.Tag == "erro-msg-invalida")
                throw new InvalidMessageException("A mensagem está inválida e precisa ser ajustada na origem");

            if (request.Tag == "erro-aleatorio-de-infra")
                throw new System.IO.FileNotFoundException("Arquivo aleatório não está disponível");

            if (request.Tag == "sucesso")
                LogInformation("A contabilização da requisição {request} foi processada com estrondoso sucesso", request.RequestID);
        }
    }
}