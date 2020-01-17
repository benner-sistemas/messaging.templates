using Benner.Messaging;
using System;

namespace Benner.Corporativo.Contabilizacao.Models
{
    public class ContabilizacaoRequest : IEnterpriseIntegrationResquest
    {
        public Guid? RequestID { get; set; }

        public string IDEmpresa { get; set; }

        public string IDFilial { get; set; }

        public DateTime? DataEmissao { get; set; }

        public DateTime? DataEntrada { get; set; }

        public int TipoRegistro { get; set; }

        public decimal Valor { get; set; }
    }
}
