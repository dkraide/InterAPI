using InterAPI.Model.FBoleto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelResponse
{
    public class RetornoBoleto
    {
        public int totalPages { get; set; }
        public int totalElements { get; set; }
        public bool last { get; set; }
        public bool first { get; set; }
        public int size { get; set; }
        public int numberOfElements { get; set; }
        public List<Boleto> content { get; set; }
    }
}
