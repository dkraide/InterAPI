using InterAPI.Model.PIX;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InterAPI.Model
{
    public class Pix
    {
        /// <summary>
        ///string[24..35] characters
        ///O campo txid determina o identificador da transação.
        ///O txid é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade. O txid, no contexto de representação de uma cobrança, é único por CPF/CNPJ do usuário recebedor.
        ///pattern: [a-zA-Z0-9]{ 26,35}
        /// </summary>
        public string txid { get; set; }

        public PixCalendario calendario { get; set; }
        /// <summary>
        /// Os campos aninhados sob o objeto devedor são opcionais e 
        /// identificam a pessoa ou a instituição a 
        /// quem a cobrança está endereçada.
        /// Não identifica, necessariamente, quem irá efetivamente realizar o pagamento.
        ///Não é permitido que o campo devedor.cpf e campo devedor.cnpj estejam preenchidos ao mesmo tempo.Se o campo devedor.nome está preenchido, então deve existir ou um devedor.cpf ou um campo devedor.cnpj preenchido.
        /// </summary>
        public PixDevedor devedor { get; set; }

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
        public PixValor valor { get; set; }

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

        internal string toCreate()
        {
            var obj = new
            {
                calendario = new
                {
                    this.calendario.expiracao,
                },
                devedor = new
                {
                   this.devedor.cnpj,
                   this.devedor.cpf,
                   this.devedor.nome
                },
                loc = new
                {
                    loc.tipoCob
                },
                valor = new
                {
                   this.valor.original,
                   this.valor.modalidadeAlteracao,
                   this.valor.retirada
                },
                this.chave,
                this.solicitacaoPagador,
                this.infoAdicionais
            };
            return JsonConvert.SerializeObject(obj);
        }
    }
    public class PixCalendario
    {
        /// <summary>
        /// Tempo de vida da cobrança, especificado em segundos a 
        /// partir da data de criação (Calendario.criacao)
        /// </summary>
        public int expiracao { get; set; }

        /// <summary>
        /// (Data de Criação)
        /// </summary>
        public DateTime criacao { get; set; }
    }
    public class PixDevedor
    {
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string nome { get; set; }
    }
    public class Pixloc
    {
        /// <summary>
        /// Identificador da location a ser informada na criação da cobrança 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Tipo String URL
        /// Localização do Payload a ser informada na criação da cobrança.
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// enum(Tipo de Cobranca)
        /// Valores permitidos: "cob" / "cobv"
        /// </summary>
        public string tipoCob { get; set; }

        /// <summary>
        /// Data e hora em que a location foi criada. Respeita RFC 3339.
        /// </summary>
        public DateTime criacao { get; set; }
    }
    public class PixValor
    {
        /// <summary>
        /// string (Valor) \d{1,10}\.\d{2}
        /// Valor original da cobrança.
        /// </summary>
        public string original { get; set; }
        /// <summary>
        /// Integer <int32> (Modalidade de alteração) [ 0 .. 1 ]
        ///Default: 0
        ///Trata-se de um campo que determina se o valor final do documento pode ser alterado pelo pagador.
        ///Na ausência desse campo, assume-se que não se pode alterar o valor do documento de cobrança, ou seja, assume-se o valor 0. 
        ///Se o campo estiver presente e com valor 1, então está determinado que o valor final da cobrança pode ter seu valor alterado pelo pagador.
        /// </summary>
        public int modalidadeAlteracao { get; set; }

        /// <summary>
        /// É uma estrutura opcional relacionada ao conceito de recebimento de numerário. Apenas um agrupamento por vez é permitido, quando há saque não há troco e vice-versa.
        ///Quando uma cobrança imediata tem uma estrutura de retirada ela deixa de ser considerada Pix comum e passa à categoria de Pix Saque ou Pix Troco.
        ///Para que o preenchimento do objeto retirada seja considerado válido as seguintes regras se aplicam:
        ///os campos modalidadeAgente e prestadorDoServicoDeSaque são de preenchimento obrigatório;
        ///quando o saque estiver presente a cobrança deve respeitar as seguintes condições:
        ///O campo valor.original deve ser preenchido com valor igual a 0.00 (zero);
        ///O campo valor.modalidadeAlteracao deve possuir o valor 0 (zero) explicitamente, ou implicitamente(pelo não preenchimento).
        ///quando o troco estiver presente a cobrança deve respeitar as seguintes condições:
        ///O campo valor.original deve ser preenchido com valor maior que 0.00 (zero);
        ///O campo valor.modalidadeAlteracao deve possuir o valor 0 (zero) explicitamente, ou implicitamente(pelo não preenchimento).
        ///IMPORTANTE: Quando usados o saque ou troco não será permitida a alteração do valor.original recebido.Na presença de saque ou troco o recebimento do campo valor.modalidadeAlteracao com valor 1 (um) é considerado erro.
        /// </summary>
        public PixValorRetirada retirada { get; set; }


    }
    public class PixValorRetirada
    {
        /// <summary>
        /// Informações relacionadas ao saque
        /// </summary>
        public PixValorRetiradaTipo saque { get; set; }

        /// <summary>
        /// Informações relacionadas ao troco
        /// </summary>
        public PixValorRetiradaTipo troco { get; set; }
    }
    public class PixValorRetiradaTipo
    {
        /// <summary>
        /// string (Valor) \d{1,10}\.\d{2}
        /// Valor 
        /// </summary>
        public string valor { get; set; }

        /// <summary>
        /// 	
        /// integer<int32>(Modalidade de alteração) [ 0 .. 1 ]
        /// Default: 0
        /// Modalidade de alteração de valor.
        /// Quando não preenchido o valor assumido é o 0 (zero).
        /// </summary>
        public int modalidadeAlteracao { get; set; }

        /// <summary>
        /// Modalidade do Agente... PERMITE 3 TIPOS
        /// AGTEC - Agente Estabelecimento Comercial
        /// AGTOT - Agente Outra Espécie de Pessoa Jurídica ou Correspondente no País
        /// AGPSS - Agente Facilitador de Serviço de Saque
        /// </summary>
        public string modalidadeAgente { get; set; }

        /// <summary>
        /// ISPB do Facilitador de Serviço
        /// </summary>
        public string prestadorDoServicoDeSaque { get; set; }

    }
    public class PixInfoAdicional
    {
        /// <summary>
        /// Nome do campo.
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Dados do campo.
        /// </summary>
        public string valor { get; set; }

    }
  
}
