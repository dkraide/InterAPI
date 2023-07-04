using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model
{
    public class PixGetParametro
    {
        internal string txId;
        internal string txIdPresente;
        internal string devolucaoPresente;

        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string locationPresente { get; set; }
        public string status { get; set; }
        public int loteCobVId { get; set; }
        public PixGetParametroPaginacao paginacao { get; set; }

    }
    public class PixGetParametroPaginacao
    {
        public int paginaAtual { get; set; }
        public int itensPorPagina { get; set; }
        public int quantidadeDePaginas { get; set; }
        public int quantidadeTotalDeItens { get; set; }
    }
}
