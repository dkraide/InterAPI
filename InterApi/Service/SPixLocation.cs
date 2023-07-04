using InterAPI.Model;
using InterAPI.Model.PIX;
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
    public class SPixLocation
    {
        const string BASEURL = @"https://cdpj.partners.bancointer.com.br/pix/v2/loc";

        /// <summary>
        /// Criar location do payload
        /// </summary>
        /// <param name="tipoCob">Dados para geração da location.</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PixLocation Post(string tipoCob, string contaCorrente = null)
        {
            var client = new RestClient($"{BASEURL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.POST);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                request.AddHeader("x-conta-corrente", contaCorrente);
            }
            string env = JsonConvert.SerializeObject(new {tipoCob});
            request.AddParameter(
                "application/json",
                env,
                ParameterType.RequestBody);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.Created)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<PixLocation>(response.Content);
        }

        /// <summary>
        /// Endpoint para consultar locations cadastradas.
        /// </summary>
        /// <param name="parametros">parametros para busca</param>
        /// <param name="contaCorrente">opcional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<PixLocation> Get(PixLocationParametro parametros, string contaCorrente = null)
        {
            var client = new RestClient($"{BASEURL}");

            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };

            var restrequest = new RestRequest(Method.GET);
            restrequest.AddQueryParameter("inicio", parametros.inicio.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("fim", parametros.fim.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("txIdPresente", parametros.txtIdPresente.ToString());
            restrequest.AddQueryParameter("tipoCob", parametros.tipoCob);
            if (parametros.paginacao != null)
            {
                restrequest.AddQueryParameter("paginacao.paginaAtual", parametros.paginacao.paginaAtual.ToString());
                restrequest.AddQueryParameter("paginacao.itensPorPagina", parametros.paginacao.itensPorPagina.ToString());
            }
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }

            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res = JsonConvert.DeserializeObject<ListPixLocation>(response.Content);
            return res.loc;
        }

        public static PixLocation Get(string id, string contaCorrente = null)
        {

            if (string.IsNullOrEmpty(id))
                throw new Exception("id necessario");

            var client = new RestClient($"{BASEURL}/{id}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };

            var restrequest = new RestRequest(Method.GET);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }

            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res = JsonConvert.DeserializeObject<PixLocation>(response.Content);
            return res;
        }

        /// <summary>
        /// Endpoint utilizado para desvincular uma cobrança de uma location.
        ///Se executado com sucesso, a entidade loc não apresentará mais um txid, se apresentava anteriormente 
        ///à chamada.Adicionalmente, a entidade cob ou cobv associada ao txid desvinculado também 
        ///passará a não mais apresentar um location.
        ///Esta operação não altera o status da cob ou cobv em questão.
        /// </summary>
        /// <param name="id">Id da location cadastrada para servir um payload</param>
        /// <param name="contaCorrente">opcinal</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PixLocation Delete(string id, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("id necessario");

            var client = new RestClient($"{BASEURL}/{id}/txid");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };

            var restrequest = new RestRequest(Method.DELETE);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }

            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res = JsonConvert.DeserializeObject<PixLocation>(response.Content);
            return res;
        }
    }
}
