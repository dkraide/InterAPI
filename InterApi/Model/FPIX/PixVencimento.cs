using InterAPI.Model.PIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model
{
    public class PixVencimento
    {
        /// <summary>
        ///string[24..35] characters
        ///O campo txid determina o identificador da transação.
        ///O txid é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade. O txid, no contexto de representação de uma cobrança, é único por CPF/CNPJ do usuário recebedor.
        ///pattern: [a-zA-Z0-9]{ 26,35}
        /// </summary>
        public string txid { get; set; }

        public PixVencimentoCalendario calendario { get; set; }
        /// <summary>
        /// Os campos aninhados sob o objeto devedor são opcionais e 
        /// identificam a pessoa ou a instituição a 
        /// quem a cobrança está endereçada.
        /// Não identifica, necessariamente, quem irá efetivamente realizar o pagamento.
        ///Não é permitido que o campo devedor.cpf e campo devedor.cnpj estejam preenchidos ao mesmo tempo.Se o campo devedor.nome está preenchido, então deve existir ou um devedor.cpf ou um campo devedor.cnpj preenchido.
        /// </summary>
        public PixVencimentoDevedor devedor { get; set; }

        /// <summary>
        /// informacoes do recebedor
        /// </summary>
        public PixVencimentoDevedor recebedor { get; set; }

        /// <summary>
        /// Identificador da localização do payload.
        /// </summary>
        public Pixloc loc { get; set; }

        /// <summary>
        /// String tipo URL
        /// Localização do Payload a ser informada na criação da cobrança.
        /// </summary>

        public string location { get; set; }

        /// <summary>
        /// Enum do Status da cobranca. Possiveis valores: 
        /// "ATIVA" "CONCLUIDA" "REMOVIDA_PELO_USUARIO_RECEBEDOR" 
        /// "REMOVIDA_PELO_PSP"
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// valores monetários referentes à cobrança.
        /// </summary>
        public PixVencimentoValor valor { get; set; }

        /// <summary>
        /// string (Chave DICT do recebedor) [ 1 .. 77 ] characters
        /// O campo chave determina a chave Pix do recebedor que será utilizada para a cobrança.
        /// Os tipos de chave podem ser: telefone, e-mail, cpf/cnpj ou EVP.
        /// O formato das chaves pode ser encontrado na seção "Formatação das chaves do DICT no BR Code" do Manual de Padrões para iniciação do Pix.
        /// </summary>
        public string chave { get; set; }

        /// <summary>
        /// O campo solicitacaoPagador determina um texto a ser apresentado ao pagador para que ele possa digitar uma informação correlata, em formato livre, a ser enviada ao recebedor. 
        /// Esse texto está limitado a 140 caracteres.
        /// </summary>
        public string solicitacaoPagador { get; set; }

        /// <summary>
        /// Cada respectiva informação adicional contida na lista (nome e valor)
        /// deve ser apresentada ao pagador.
        ///  Array maximo de 50.
        /// </summary>
        public List<PixInfoAdicional> infoAdicionais { get; set; }

        /// <summary>
        /// Denota a revisão da cobrança. Sempre começa em zero. Sempre varia em acréscimos de 1.
        /// O incremento em uma cobrança deve ocorrer sempre que um objeto da cobrança em questão for alterado.O campo loc é uma exceção a esta regra.
        /// Se em uma determinada alteração em uma cobrança, o único campo alterado for o campo loc, então esta operação não incrementa a revisão da cobrança.
        /// O campo loc não ocasiona uma alteração na cobrança em si.Não é necessário armazenar histórico das alterações do campo loc para uma determinada cobrança.Para os outros campos da cobrança, registra-se histórico.
        /// </summary>
        public int revisao { get; set; }

        /// <summary>
        /// Este campo retorna o valor do Pix Copia e Cola correspondente à cobrança. 
        /// Trata-se da sequência de caracteres que representa o BR Code.
        /// </summary>
        public string pixCopiaECola { get; set; }

        /// <summary>
        /// Lista de pix recebido
        /// </summary>
        public List<PixRecebido> pix { get; set; }



    }
    public class PixVencimentoDevedor : PixDevedor
    {
        public string logradouro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
    }
    public class PixVencimentoCalendario
    {
        /// <summary>
        /// data da Criacao do pix.
        /// </summary>
        public DateTime criacao { get; set; }

        /// <summary>
        /// Trata-se de uma data, no formato YYYY-MM-DD, segundo ISO 8601. É a data de vencimento da cobrança. A cobrança pode ser honrada até esse dia, inclusive, em qualquer horário do dia.
        /// </summary>
        public string dataVencimento { get; set; }

        /// <summary>
        /// Trata-se da quantidade de dias corridos após calendario.dataDeVencimento, em que a cobrança poderá ser paga.
        /// </summary>

        public int validadeAposVencimento { get; set; }
    }
    public class PixVencimentoValor
    {
        /// <summary>
        /// string (Valor) \d{1,10}\.\d{2}
        /// Valor original da cobrança.
        /// </summary>
        public string original { get; set; }

        /// <summary>
        /// Multa aplicada à cobrança
        /// </summary>
        public PixVencVMulJurAbaDesc multa { get; set; }

        /// <summary>
        /// Juros aplicado à cobrança
        /// </summary>
        public PixVencVMulJurAbaDesc juros { get; set; }

        /// <summary>
        /// Abatimento aplicado à cobrança
        /// </summary>
        public PixVencVMulJurAbaDesc abatimento { get; set; }

        /// <summary>
        /// Desconto aplicado à cobrança
        /// </summary>
        public PixVencDesconto desconto { get; set; }

    }
    public class PixVencVMulJurAbaDesc
    {
        public int modalidade { get; set; }
        public string valorPerc { get; set; }
    }
    public class PixVencDesconto
    {
        public int modalidade { get; set; }
        public string valorPerc { get; set; }
        public List<PixVencDescontoData> descontoDataFixa { get; set; }
    }
    public class PixVencDescontoData
    {
        /// <summary>
        /// Descontos por pagamento antecipado, com data fixa. Matriz com até três elementos, sendo que cada elemento é composto por um par "data e valorPerc", para estabelecer descontos percentuais ou absolutos, até aquela data de pagamento. Trata-se de uma data, no formato YYYY-MM-DD, segundo ISO 8601. 
        /// A data de desconto obrigatoriamente deverá ser menor que a data de vencimento da cobrança.
        /// </summary>
        public string data { get; set; }
        public string valorPerc { get; set; }
    }
}
