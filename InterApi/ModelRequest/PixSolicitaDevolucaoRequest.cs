using InterAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelRequest
{
    public class PixSolicitaDevolucaoRequest
    {
        /// <summary>
        /// Id único para identificação do Pix Cobrança.
        /// </summary>
        public string e2eId { get; set; }

        /// <summary>
        /// Id gerado pelo cliente para representar unicamente uma devolução.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// \d{1,10}\.\d{2}
        /// Valor solicitado para devolução.A soma dos valores de todas as devolucões não podem ultrapassar o valor total do Pix.
        /// </summary>
        public string valor { get; set; }

        /// <summary>
        /// Default: "ORIGINAL"
        /// Enum: "ORIGINAL" "RETIRADA"
        /// </summary>
        public string natureza { get; set; }

        /// <summary>
        /// opcional, determina um texto a ser apresentado ao pagador contendo informações sobre a devolução. Esse texto será preenchido, na pacs.004, pelo PSP do recebedor, no campo RemittanceInformation. O tamanho do campo na pacs.004 está limitado a 140 caracteres.
        /// </summary>
        public string descricao { get; set; }

    }
}
