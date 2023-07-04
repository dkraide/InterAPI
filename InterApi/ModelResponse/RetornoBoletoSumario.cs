using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelResponse
{
    public class RetornoBoletoSumario
    {
        public RetornoBoletoSumarioItem pagos { get; set; }
        public RetornoBoletoSumarioItem abertos { get; set; }
        public RetornoBoletoSumarioItem vencidos { get; set; }
        public RetornoBoletoSumarioItem cancelados { get; set; }
        public RetornoBoletoSumarioItem expirados { get; set; }

    }

    public class RetornoBoletoSumarioItem
    {
        public int quantidade { get; set; }
        public int valor { get; set; }
    }
}
