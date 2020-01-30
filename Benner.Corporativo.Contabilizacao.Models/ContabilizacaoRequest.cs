using Benner.Messaging;
using System;

namespace Benner.Corporativo.Contabilizacao.Models
{
    /// <summary>
    /// Representa uma requisição de documento financeiro para contabilizar, no módulo tal
    /// </summary>
    public class ContabilizacaoRequest : IEnterpriseIntegrationRequest
    {
        /// <summary>
        /// Identificador único da requisição
        /// </summary>
        public Guid? RequestID { get; set; }

        /// <summary>
        /// Identificador da empresa
        /// </summary>
        public string IDEmpresa { get; set; }

        /// <summary>
        /// Identificador da filial
        /// </summary>
        public string IDFilial { get; set; }

        /// <summary>
        /// Data de emissão da ocorrência
        /// </summary>
        public DateTime? DataEmissao { get; set; }

        /// <summary>
        /// Data de entrada
        /// </summary>
        public DateTime? DataEntrada { get; set; }

        /// <summary>
        /// Tipo de registro que influencia no comportamento xpto, onde o valor 1 faz isso e o valor 2 faz aquilo
        /// </summary>
        public int TipoRegistro { get; set; }

        /// <summary>
        /// Valor da ocorrência
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Propriedade que indica isso, isso e aquilo
        /// </summary>
        public string Tag { get; set; }
    }
}
