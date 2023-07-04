using InterAPI.Model;
using InterAPI.ModelResponse;
using InterAPI.Utils;
using Microsoft.Win32;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace InterAPI.Service
{
    public class SPixImediato
    {
        const string BASEURRL = @"https://cdpj.partners.bancointer.com.br/pix/v2/cob";


        /// <summary>
        /// Endpoint para atualizar cobrança imediata.
        /// </summary>
        /// <param name="envio">objeto a ser atualizado</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns>Pix atualizado</returns>
        /// <exception cref="Exception"></exception>
        public static Pix Patch(Pix envio, string contaCorrente = null)
        {

            if (envio == null)
                throw new Exception("Objeto pix nulo ou invalido.");

            if (envio.txid == null)
                throw new Exception("txid obrigatorio.");


            var client = new RestClient($"{BASEURRL}/{envio.txid}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.PATCH);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                request.AddHeader("x-conta-corrente", contaCorrente);
            }
            string env = JsonConvert.SerializeObject(envio);
            request.AddParameter(
                "application/json",
                env,
                ParameterType.RequestBody);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<Pix>(response.Content);

        }


        /// <summary>
        /// Retornar a Cobranca Imediata pelo TxId
        /// </summary>
        /// <param name="txid">O campo txid determina o identificador da transação.
        /// O txid é criado exclusivamente pelo usuário recebedor e está sob sua responsabilidade.O txid, no contexto de representação de uma cobrança, é único por CPF/CNPJ do usuário recebedor.
        ///pattern: [a-zA-Z0-9]{ 26,35}</param>
        /// <param name="certificate">
        /// Certificado do arquivo Digital</param>
        /// <returns></returns>
        public static Pix Get(string txid)
        {
            var client = new RestClient($"{BASEURRL}/{txid}");
            
             client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2};

            var restrequest = new RestRequest(Method.GET);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<Pix>(response.Content);

        }


        /// <summary>
        /// Retorna uma lista de objeto de Pix com base nos parametros fornecidos
        /// </summary>
        /// <param name="inicio">Data de início</param>
        /// <param name="fim">Data de fim</param>
        /// <param name="cpf">Filtro pelo CPF do devedor. Não pode ser utilizado ao mesmo tempo que o CNPJ.</param>
        /// <param name="cnpj">Filtro pelo CNPJ do devedor. Não pode ser utilizado ao mesmo tempo que o CPF.</param>
        /// <param name="locationPresente">boolean</param>
        /// <param name="status">Enum: "ATIVA" "CONCLUIDA" "REMOVIDA_PELO_USUARIO_RECEBEDOR" "REMOVIDA_PELO_PSP"</param>
        /// <param name="paginaAtual">Página a ser retornada pela consulta. Se não for informada, o PSP assumirá que será 0.</param>
        /// <param name="itensPorPagina">Quantidade máxima de registros retornados em cada página. Apenas a última página pode conter uma quantidade menor de registros.</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Pix> Get(PixGetParametro parametros,string contaCorrente = null)
        {
            var client = new RestClient($"{BASEURRL}");

            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };

            var restrequest = new RestRequest(Method.GET);
            restrequest.AddQueryParameter("inicio", parametros.inicio.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("fim", parametros.fim.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("locationPresente", parametros.locationPresente);
            restrequest.AddQueryParameter("status", parametros.status);
            if(parametros.paginacao != null)
            {
                restrequest.AddQueryParameter("paginacao.paginaAtual", parametros.paginacao.paginaAtual.ToString());
                restrequest.AddQueryParameter("paginacao.itensPorPagina", parametros.paginacao.itensPorPagina.ToString());
            }
            

            if (!string.IsNullOrEmpty(parametros.cpf))
                restrequest.AddQueryParameter("cpf", parametros.cpf);
            if (!string.IsNullOrEmpty(parametros.cnpj))
                restrequest.AddQueryParameter("cnpj", parametros.cnpj);

            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }

            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res =  JsonConvert.DeserializeObject<ListPixImediatoResponse>(response.Content);
            return res.cobs;
        }
        /// <summary>
        /// Endpoint para criar uma cobrança imediata, neste caso, o txid é definido pelo PSP.
        /// </summary>
        /// <param name="contaCorrrente">Conta corrente que será utilizada na operação. 
        /// Necessário somente quando a aplicação estiver associada a
        /// mais de uma conta corrente.</param>
        /// <returns></returns>
        public static Pix Post(Pix envio, string contaCorrente)
        {
            var client = new RestClient($"{BASEURRL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.POST);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                request.AddHeader("x-conta-corrente", contaCorrente);
            }
            string env = envio.toCreate();
            request.AddParameter(
                "application/json",
                env,
                ParameterType.RequestBody);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<Pix>(response.Content);
        }


        /// <summary>
        /// Criar cobranca imediata com txid gerado pelo usuario recebedor.
        /// </summary>
        /// <param name="envio">Objeto Pix a ser enviado</param>
        /// <param name="contaCorrrente">[OPCIONAL] Conta corrente que será utilizada na operação. 
        /// Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns>Retorna o objeto pix criado.</returns>
        /// <exception cref="Exception"></exception>
        public static Pix Put(Pix envio, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(envio.txid))
                throw new Exception("Campo pxid obrigatorio para essa requisicao.");

            var client = new RestClient($"{BASEURRL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.PUT);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                request.AddHeader("x-conta-corrente", contaCorrente);
            }
            string env = JsonConvert.SerializeObject(envio);
            request.AddParameter(
                "application/json",
                env,
                ParameterType.RequestBody);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<Pix>(response.Content);
        }
    }
}
