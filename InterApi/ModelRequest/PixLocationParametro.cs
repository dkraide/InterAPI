using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model.PIX
{
    public class PixLocationParametro
    {
        public DateTime inicio { get; set; }
        public DateTime fim { get; set; }
        public bool txtIdPresente { get; set; }
        public string tipoCob { get; set; }
        public PixLocationPaginacao paginacao { get; set; }
    }
    public class PixLocationPaginacao
    {
        public int paginaAtual { get; set; }
        public int itensPorPagina { get; set; }
        public int quantidadeDePaginas { get; set; }
        public int quantidadeTotalDeItens { get; set; }
    }
}
