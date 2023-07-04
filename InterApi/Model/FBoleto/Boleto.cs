using InterAPI.Service;
using InterAPI.Utils;
using System;
using System.Globalization;

namespace InterAPI.Model.FBoleto
{
    public class Boleto
    {
        public string nomeBeneficiario { get; set; }
        public string cnpjCpfBeneficiario { get; set; }
        public string tipoPessoaBeneficiario { get; set; }
        public string contaCorrente { get; set; }
        public string nossoNumero { get; set; }
        public string seuNumero { get; set; }
        public string situacao { get; set; }
        public DateTime dataHoraSituacao { get; set; }
        public DateTime dataVencimento { get; set; }
        public decimal valorNominal { get; set; }
        public decimal valorAbatimento { get; set; }
        public DateTime dataEmissao { get; set; }
        public DateTime dataLimite { get; set; }
        public string codigoEspecie { get; set; }
        public string codigoBarras { get; set; }
        public string linhaDigitavel { get; set; }
        public string origem { get; set; }
        public int numDiasAgenda { get; set; }
        public Pagador pagador { get; set; }
        public Mensagem mensagem { get; set; }
        public Desconto desconto1 { get; set; }
        public Desconto desconto2 { get; set; }
        public Desconto desconto3 { get; set; }
        public Multa multa { get; set; }
        public Mora mora { get; set; }

        public Pessoa beneficiarioFinal { get; set; }


        public object GetToCreate()
        {
            string pagadorCnpj = Helpers.ValidarCnpjCpf(pagador.cpfCnpj);
            if (string.IsNullOrEmpty(pagadorCnpj))
                throw new Exception($"Cnpj/Cpf({pagadorCnpj}) do pagador invalido");

            if (seuNumero.Length > 15)
                throw new Exception($"Seu numero({seuNumero}) deve ter no maximo 15 caracteres");

            if (valorNominal < 2.5m)
                throw new Exception($"Valor nominal({valorNominal}) deve ser maior que R$2.50");
            
            if (numDiasAgenda < 0 || numDiasAgenda > 60)
                throw new Exception($"NumdiasAgenda({numDiasAgenda}) deve ser entre 0 e 60");
            
            if (pagador == null)
                throw new Exception("Objeto pagador nao deve ser nulo");
            
            if (pagador.tipoPessoa != "FISICA" &&
                pagador.tipoPessoa != "JURIDICA")
                throw new Exception($"Pagador.TipoPessoa({pagador.tipoPessoa}) deve ser FISICA ou JURIDICA");

            if (pagador.nome == null || pagador.nome.Length < 1 || pagador.nome.Length > 100)
                throw new Exception($"Pagador.Nome({pagador.nome?.Length}) deve ter um tamanho entre 1 e 100.");

            if (pagador.endereco == null || pagador.endereco.Length < 1 || pagador.endereco.Length > 100)
                throw new Exception($"Pagador.endereco({pagador.endereco?.Length}) deve ter um tamanho entre 1 e 100.");

            if (pagador.cidade == null || pagador.cidade.Length < 1 || pagador.cidade.Length > 60)
                throw new Exception($"Pagador.cidade({pagador.cidade?.Length}) deve ter um tamanho entre 1 e 60.");

            if (pagador.uf == null ||  pagador.endereco.Length < 2)
                throw new Exception($"Pagador.uf({pagador.uf}) deve ter um tamanho de 2.");

            string formattedCep = Helpers.GetOnlyNumbers(pagador.cep);
            if (pagador.cep == null || pagador.endereco.Length < 2)
                throw new Exception($"Pagador.cep({formattedCep}) deve ter um tamanho de 8.");

            if(desconto1 != null)
                desconto1.ValidaDesconto();
            if (desconto2 != null)
                desconto2.ValidaDesconto();
            if (desconto3 != null)
                desconto3.ValidaDesconto();

            if (multa != null)
                multa.ValidaMulta();

            if (mora != null)
                mora.ValidaMora();

            if (beneficiarioFinal != null)
                beneficiarioFinal.ValidaBeneficiario();




            var obj =  new
            {
                seuNumero,
                valorNominal,
                dataVencimento = dataVencimento.ToString("yyyy-MM-DD"),
                numDiasAgenda,
                pagador = new
                {
                    cpfCnpj = pagadorCnpj,
                    pagador.tipoPessoa,
                    pagador.nome,
                    pagador.endereco,
                    pagador.numero,
                    pagador.complemento,
                    pagador.bairro,
                    pagador.cidade,
                    pagador.uf,
                    cep = formattedCep,
                    pagador.email,
                    pagador.ddd,
                    pagador.telefone
                },
                mensagem  = mensagem == null ? null as object : new
                {
                    mensagem.linha1,
                    mensagem.linha2,
                    mensagem.linha3,
                    mensagem.linha4,
                    mensagem.linha5,
                },
                desconto1 = GetDesconto(desconto1),
                desconto2 = GetDesconto(desconto2),
                desconto3 = GetDesconto(desconto3),
                mora = mora == null ? null as object : new
                {
                    mora.taxa,
                    mora.valor,
                    mora.data,
                    mora.codigoMora
                },
                multa = multa == null ? null as object : new
                {
                    multa.taxa,
                    multa.valor,
                    multa.data,
                    multa.codigoMulta
                },
                beneficiarioFinal = beneficiarioFinal == null ? null as object : new
                {
                    beneficiarioFinal.uf,
                    beneficiarioFinal.cnpjCpf,
                    beneficiarioFinal.cidade,
                    beneficiarioFinal.tipoPessoa,
                    beneficiarioFinal.cep,
                    beneficiarioFinal.endereco,
                    beneficiarioFinal.nome,
                }
            };
            return obj;
        }

        private object GetDesconto(Desconto d)
        {
            if (d == null)
                return null;

            return new
            {
                d.taxa,
                d.valor,
                d.codigoDesconto,
                d.data
            };

        }


    }
}