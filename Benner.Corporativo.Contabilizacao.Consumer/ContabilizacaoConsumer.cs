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

        public override void OnDeadMessage(string message)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);
        
            throw new NotImplementedException();
        }
        
        public override void OnInvalidMessage(string message)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);

            throw new NotImplementedException();
        }
        
        public override void OnMessage(string message)
        {
            var request = DeserializeMessage<ContabilizacaoRequest>(message);

            throw new NotImplementedException();
        }
    }
}