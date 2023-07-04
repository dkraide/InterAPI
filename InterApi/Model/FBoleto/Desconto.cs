using System;
namespace InterAPI.Model
{
    public class Desconto
    {
        public string codigoDesconto { get; set; }
        public DateTime? data { get; set; }
        public decimal taxa { get; set; }
        public decimal valor { get; set; }

        public bool ValidaDesconto()
        {
            if (string.IsNullOrEmpty(codigoDesconto))
                throw new Exception("Se o objeto desconto for instanciado, o codigoDesconto deve ser preenchido");

            if (codigoDesconto != "NAOTEMDESCONTO" &&
                codigoDesconto != "VALORFIXODATAINFORMADA" &&
                codigoDesconto != "PERCENTUALDATAINFORMADA")
                throw new Exception("codigo desconto invalido");

            if (taxa != 0 &&codigoDesconto != "PERCENTUALDATAINFORMADA")
                throw new Exception("Taxa deve ser 0 para codigoDesconto diferente de PERCENTUALDATAINFORMADA");

            if (valor != 0 && codigoDesconto != "VALORFIXODATAINFORMADA")
                throw new Exception("Taxa deve ser 0 para codigoDesconto diferente de VALORFIXODATAINFORMADA");

            return true;

        }
    }
}
