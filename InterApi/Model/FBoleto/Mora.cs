using System;
namespace InterAPI.Model
{
    public class Mora
    {
        public string codigoMora { get; set; }
        public DateTime? data { get; set; }
        public decimal taxa { get; set; }
        public decimal valor { get; set; }

        public bool ValidaMora()
        {
            if (string.IsNullOrEmpty(codigoMora))
                throw new Exception("codigoMora nao deve ser nulo");

            if (codigoMora != "VALORDIA" && codigoMora != "TAXAMENSAL" &&
                codigoMora != "ISENTO")
                throw new Exception("codigoMora invalido");

            if (codigoMora == "TAXAMENSAL" && taxa <= 0)
                throw new Exception("Taxa invalida para o codigoMora TAXAMENSAL");

            if (codigoMora == "TAXAMENSAL" && valor <= 0)
                throw new Exception("Valor invalida para o codigoMora TAXAMENSAL");

            if (codigoMora == "ISENTO" && valor != 0)
                throw new Exception("Valor deve ser zero para o codigoMora ISENTO");

            return true;
        }

    }
}
