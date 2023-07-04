using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelRequest
{
    public class BoletoGetPaginacao
    {
        /// <summary>
        /// Default 100
        /// </summary>
        public int itensPorPagina { get; set; }
        /// <summary>
        /// Default 0
        /// </summary>
        public int paginaAtual { get; set; }

        /// <summary>
        /// Default: "PAGADOR". Opcoes: "PAGADOR", "NOSSONUMERO", "SEUNUMERO", "DATASITUACAO",
        /// "DATAVENCIMENTO", "VALOR", "STATUS"
        /// </summary>
        public string ordenarPor { get; set; }

        /// <summary>
        /// Default: "ASC".
        /// Opcoes: "ASC" ou "DESC"
        /// </summary>
        public string tipoOrdenacao { get; set; }


    }
}
