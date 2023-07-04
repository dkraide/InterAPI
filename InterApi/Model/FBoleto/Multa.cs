using System;
using System.CodeDom;

namespace InterAPI.Model
{
    public class Multa
    {
        public string codigoMulta { get; set; }
        public DateTime? data { get; set; }
        public decimal taxa { get; set; }
        public decimal valor { get; set; }

        public bool ValidaMulta()
        {
            if (string.IsNullOrEmpty(codigoMulta))
                throw new Exception("codigoMulta nao deve ser nulo");

            if (codigoMulta != "NAOTEMMULTA" && codigoMulta != "VALORFIXO" &&
                codigoMulta != "PERCENTUAL")
                throw new Exception("codigoMulta invalido");

            if (codigoMulta == "PERCENTUAL" && taxa <= 0)
                throw new Exception("Taxa invalida para o codigoMulta PERCENTUAL");

            if (codigoMulta == "NAOTEMMULTA" && taxa != 0)
                throw new Exception("Taxa deve ser zero para o codigoMulta NAOTEMMULTA");

            if (codigoMulta == "VALORFIXO" && valor <= 0)
                throw new Exception("Valor invalida para o codigoMulta VALORFIXO");

            if (codigoMulta == "NAOTEMMULTA" && valor != 0)
                throw new Exception("Valor deve ser zero para o codigoMulta NAOTEMMULTA");

            return true;
        }


    }
}
