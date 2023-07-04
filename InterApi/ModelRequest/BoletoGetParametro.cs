using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelRequest
{
    public class BoletoGetParametro
    {
        /// <summary>
        /// Data inicial, em acordo com o campo "filtrarDataPor"
        /// </summary>
        public DateTime dataInicial { get; set; }

        /// <summary>
        /// Data final, em acordo com o campo "filtrarDataPor"
        /// </summary>
        public DateTime dataFinal { get; set; }

        /// <summary>
        /// Default: "VENCIMENTO". "EMISSAO", "SITUACAO", "EXPIRADO", "VENCIDO", "EMABERTO", "PAGO"
        /// ,"CANCELADO"
        /// </summary>
        public string filtrarDataPor { get; set; }

        /// <summary>
        /// Filtro pela situação da cobrança. "EXPIRADO", "VENCIDO", "EMABERTO", "PAGO", "CANCELADO",
        /// Obs: No caso de filtrar por mais de uma situação, as situações devem ser separadas por vírgula.
        /// </summary>
        public string situacao { get; set; }

        /// <summary>
        /// Filtro pelo nome do pagador
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Filtro pelo email do pagador
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Campo para informar o cpf ou cnpj do pagador
        /// </summary>
        public string cpfCnpj { get; set; }
        public BoletoGetPaginacao Paginacao { get; set; }

    }
}
