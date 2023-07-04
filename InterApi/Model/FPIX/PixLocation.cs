using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model
{
    public class PixLocation
    {
        public int Id { get; set; }
        public string txid { get; set; }
        public string location { get; set; }
        public string tipoCob { get; set; }
        public DateTime criacao { get; set; }
    }
}
