using InterAPI.Model;
using InterAPI.Model.PIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.ModelResponse
{
    public class ListPixLocation
    {
        public PixLocationParametro  parametros { get; set; }
        public List<PixLocation>  loc { get; set; }
    }

    public class ListPixLocationLoc
    {
        public ListPixLocationLocAllOf AllOf { get; set; }
    }
    public class ListPixLocationLocAllOf
    {
        public List<string> sref { get; set; }
    }
}
