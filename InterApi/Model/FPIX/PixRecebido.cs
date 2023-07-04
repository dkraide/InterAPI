using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model.PIX
{
    public class PixRecebido
    {
        /// <summary>
        /// = 32 characters [a-zA-Z0-9]{32}
        /// Id único para identificação do Pix Cobrança.
        /// </summary>
        public string endToEndId { get; set; }

        /// <summary>
        /// O campo txid determina o identificador da transação. O objetivo desse campo é ser um elemento que possibilite ao PSP do recebedor apresentar ao usuário recebedor a funcionalidade de conciliação de pagamentos.
        /// O txid é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade.O txid, no contexto de representação de uma cobrança, é único por CPF/CNPJ do usuário recebedor.
        /// </summary>
        public string txid { get; set; }

        /// <summary>
        /// \d{1,10}\.\d{2}
        /// Valor do Pix.
        /// </summary>
        public string valor { get; set; }

        /// <summary>
        /// <= 77 characters
        /// Formato do campo chave
        /// Campo chave do recebedor conforme atribuído na respectiva PACS008.
        /// Os tipos de chave podem ser: telefone, e-mail, cpf/cnpj ou EVP.
        /// O formato das chaves pode ser encontrado na seção "Formatação das chaves do DICT no BR Code" do Manual de Padrões para iniciação do Pix.
        /// </summary>
        public string chave { get; set; }

        /// <summary>
        /// Horário em que o Pix foi processado no PSP.
        /// </summary>
        public DateTime horario { get; set; }

        /// <summary>
        ///Informação livre do pagador
        /// </summary>
        public string infoPagador { get; set; }

        /// <summary>
        /// lista de possiveis devolucoes
        /// </summary>
        public List<PixRecebidoDevolucao> devolucoes { get; set; }

    }
    public class PixRecebidoDevolucao
    {
        /// <summary>
        /// [a-zA-Z0-9]{1,35} Id gerado pelo cliente para representar unicamente uma devolução.
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// [a-zA-Z0-9]{32} Identification que transita na PACS004.
        /// </summary>
        public string rtrId { get; set; }

        /// <summary>
        /// \d{1,10}\.\d{2} Valor a devolver.
        /// </summary>
        public string valor { get; set; }

        /// <summary>
        /// objeto do horario da devolucao
        /// </summary>
        public PixRecebidoDevolucaoHorario horario { get; set; }

        /// <summary>
        /// Status da devolução.
        /// Enum: "EM_PROCESSAMENTO" "DEVOLVIDO" "NAO_REALIZADO"
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// Campo opcional que pode ser utilizado pelo PSP recebedor para detalhar os motivos de a devolução ter atingido o status em questão. Pode ser utilizado, por exemplo, 
        /// para detalhar o motivo de a devolução não ter sido realizada.
        /// </summary>
        public string motivo { get; set; }

    }
    public class PixRecebidoDevolucaoHorario
    {
        /// <summary>
        /// Horário no qual a devolução foi solicitada no PSP.
        /// </summary>
        public DateTime solicitacao { get; set; }

        /// <summary>
        /// Horário no qual a devolução foi liquidada no PSP.
        /// </summary>
        public DateTime liquidacao { get; set; }
    }
}
