using InterAPI.Model;
using InterAPI.ModelResponse;
using InterAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Service
{
    public class SPixVencimento
    {
        const string BASEURL = @"https://cdpj.partners.bancointer.com.br/pix/v2/cobv";

        /// <summary>
        /// Criar um pix com vencimento
        /// </summary>
        /// <param name="envio">objeto a ser criado</param>
        /// <param name="contaCorrente">conta corrente opcional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PixVencimento Put(PixVencimento envio, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(envio.txid))
                throw new Exception("Campo pxid obrigatorio para essa requisicao.");

            var client = new RestClient($"{BASEURL}/{envio.txid}");
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

            return JsonConvert.DeserializeObject<PixVencimento>(response.Content);
        }

        /// <summary>
        /// Atualizar/Revisar um pix com vencimento
        /// </summary>
        /// <param name="envio">objeto com as revisoes</param>
        /// <param name="contaCorrente">campo opcional </param>
        /// <returns>Pix atualizado</returns>
        /// <exception cref="Exception"></exception>
        public static PixVencimento Patch(PixVencimento envio, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(envio.txid))
                throw new Exception("Campo pxid obrigatorio para essa requisicao.");

            var client = new RestClient($"{BASEURL}/{envio.txid}");
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

            return JsonConvert.DeserializeObject<PixVencimento>(response.Content);
        }

        /// <summary>
        /// Buscar um Pix com Vencimento
        /// </summary>
        /// <param name="envio">objeto com as revisoes</param>
        /// <param name="contaCorrente">campo opcional </param>
        /// <returns>Pix atualizado</returns>
        /// <exception cref="Exception"></exception>
        public static PixVencimento Get(string txid, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(txid))
                throw new Exception("Campo txid obrigatorio para essa requisicao.");

            var client = new RestClient($"{BASEURL}/{txid}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.GET);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                request.AddHeader("x-conta-corrente", contaCorrente);
            }
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<PixVencimento>(response.Content);
        }

        /// <summary>
        /// Buscar varios Pix com Vencimento
        /// </summary>
        /// <param name="envio">objeto com as revisoes</param>
        /// <param name="contaCorrente">campo opcional </param>
        /// <returns>Pix atualizado</returns>
        /// <exception cref="Exception"></exception>
        public static List<PixVencimento> Get(PixGetParametro parametros,  string contaCorrente = null)
        {

            var client = new RestClient($"{BASEURL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var restrequest = new RestRequest(Method.GET);
            restrequest.AddQueryParameter("inicio", parametros.inicio.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("fim", parametros.fim.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("locationPresente", parametros.locationPresente.ToString());
            restrequest.AddQueryParameter("status", parametros.status);
            if (parametros.paginacao != null)
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

            var res = JsonConvert.DeserializeObject<ListPixVencimentoResponse>(response.Content);
            return res.cobs;
        }
    }
}
