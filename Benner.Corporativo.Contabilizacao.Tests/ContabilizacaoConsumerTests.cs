using Benner.Corporativo.Contabilizacao.Consumer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Benner.Corporativo.Contabilizacao.Tests
{
    [TestClass]
    public class ContabilizacaoConsumerTests
    {
        [TestMethod]
        public void ConsumerSettingsDevemEstarDevidamentePreenchidos()
        {
            var consumer = new ContabilizacaoConsumer();
            Assert.IsNotNull(consumer.Settings);
            Assert.AreEqual("fila-contabilizacao", consumer.Settings.QueueName);
            Assert.AreEqual(1000, consumer.Settings.RetryIntervalInMilliseconds);
            Assert.AreEqual(4, consumer.Settings.RetryLimit);
        }

        [TestMethod]
        public void TestarComportamentoDoOnMessage()
        {
            var consumer = new ContabilizacaoConsumer();
            var message = string.Empty;

            Assert.ThrowsException<NotImplementedException>(() => consumer.OnMessage(message));
        }

        [TestMethod]
        public void TestarComportamentoDoOnDeadMessage()
        {
            var consumer = new ContabilizacaoConsumer();
            var message = string.Empty;

            Assert.ThrowsException<NotImplementedException>(() => consumer.OnMessage(message));
        }

        [TestMethod]
        public void TestarComportamentoDoOnInvalidMessage()
        {
            var consumer = new ContabilizacaoConsumer();
            var message = string.Empty;

            Assert.ThrowsException<NotImplementedException>(() => consumer.OnMessage(message));
        }
    }
}