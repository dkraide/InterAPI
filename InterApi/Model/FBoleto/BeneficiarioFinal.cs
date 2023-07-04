using InterAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model.FBoleto
{
    public class Pessoa
    {
        public string nome { get; set; }
        public string cnpjCpf { get; set; }
        public string tipoPessoa { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }

        public bool ValidaBeneficiario()
        {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("nome nao deve ser null");
            
            string valited = Helpers.ValidarCnpjCpf(cnpjCpf);
            if (string.IsNullOrEmpty(valited)) 
                throw new Exception("cnpjcpf invalido");

            if (string.IsNullOrEmpty(tipoPessoa))
                throw new Exception("tipoPessoa nao deve ser null");

            if (tipoPessoa != "JURIDICA" && tipoPessoa != "FISICA")
                throw new Exception("tipoPessoa invalido");

            if (string.IsNullOrEmpty(cep))
                throw new Exception("cep nao deve ser null");

            if (string.IsNullOrEmpty(endereco))
                throw new Exception("endereco nao deve ser null");

            if (string.IsNullOrEmpty(bairro))
                throw new Exception("bairro nao deve ser null");

            if (string.IsNullOrEmpty(cidade))
                throw new Exception("cidade nao deve ser null");

            if (string.IsNullOrEmpty(uf))
                throw new Exception("uf nao deve ser null");

            return true;

        }
    }
}
