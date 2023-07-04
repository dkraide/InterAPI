using InterAPI.Model;
using InterAPI.Model.PIX;
using InterAPI.ModelRequest;
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
    public class SPix
    {
        const string BASEURL = @"https://cdpj.partners.bancointer.com.br/pix/v2/pix";

        /// <summary>
        /// Endpoint para consultar um pix através de um determinado EndToEndId.
        /// </summary>
        /// <param name="e2eId">Id fim a fim da transação</param>
        /// <param name="contaCorrente">opcional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PixRecebido ConsultarPix(string e2eId, string contaCorrente)
        {
            if(e2eId == null)
            {
                throw new Exception("e2eId obrigatorio.");
            }
            var client = new RestClient($"{BASEURL}/{e2eId}");
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

            var res = JsonConvert.DeserializeObject<PixRecebido>(response.Content);
            return res;
        }

        /// <summary>
        /// Endpoint para consultar um pix por um período específico, de acordo com os parâmetros informados.
        /// </summary>
        /// <param name="parametros">Parametros disponiveis</param>
        /// <param name="contaCorrente">opcional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<PixRecebido> ConsultarPixRecebidos(PixGetParametro parametros, string contaCorrente)
        {
            var client = new RestClient($"{BASEURL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var restrequest = new RestRequest(Method.GET);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }

            restrequest.AddQueryParameter("inicio", parametros.inicio.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("fim", parametros.fim.ToString("yyyy-MM-ddTHH:mm:ssZ"));
            restrequest.AddQueryParameter("txId", parametros.txId);
            restrequest.AddQueryParameter("txIdPresente", parametros.txIdPresente);
            restrequest.AddQueryParameter("devolucaoPresente", parametros.devolucaoPresente);
            if (parametros.paginacao != null)
            {
                restrequest.AddQueryParameter("paginacao.paginaAtual", parametros.paginacao.paginaAtual.ToString());
                restrequest.AddQueryParameter("paginacao.itensPorPagina", parametros.paginacao.itensPorPagina.ToString());
            }


            if (!string.IsNullOrEmpty(parametros.cpf))
                restrequest.AddQueryParameter("cpf", parametros.cpf);
            if (!string.IsNullOrEmpty(parametros.cnpj))
                restrequest.AddQueryParameter("cnpj", parametros.cnpj);



            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res = JsonConvert.DeserializeObject <List<PixRecebido>>(response.Content);
            return res;
        }


        /// <summary>
        /// Endpoint para solicitar uma devolução através de um E2EID do Pix e do ID da devolução.
        /// </summary>
        /// <param name="parametro">parametros necessarios</param>
        /// <param name="contaCorrente">opcional</param>
        /// <returns></returns>
        public static PixRecebidoDevolucao SolicitarDevolucao(PixSolicitaDevolucaoRequest parametro,  string contaCorrente)
        {
            if (parametro == null ||
                string.IsNullOrEmpty(parametro.e2eId) ||
                string.IsNullOrEmpty(parametro.id))
                throw new Exception("Campos obrigatorios nao preenchidos!");

            var client = new RestClient($"{BASEURL}/{parametro.e2eId}/devolucao/{parametro.id}");

            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };

            var restrequest = new RestRequest(Method.PUT);
            if (!string.IsNullOrEmpty(contaCorrente))
            {
                restrequest.AddHeader("x-conta-corrente", contaCorrente);
            }
            var env = new
            {
                parametro.valor,
                parametro.natureza,
                parametro.descricao
            };

            restrequest.AddParameter(
                "application/json",
                env,
                ParameterType.RequestBody);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            IRestResponse response = client.Execute(restrequest);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            var res = JsonConvert.DeserializeObject<PixRecebidoDevolucao>(response.Content);
            return res;
        }

        /// <summary>
        /// Endpoint para consultar uma devolução através de um E2EID do Pix e do ID da devolução.
        /// </summary>
        /// <param name="e2eId">Id fim a fim da transação</param>
        /// <param name="id">Id da Devolução</param>
        /// <param name="contaCorrente">opcional</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static PixRecebidoDevolucao ConsultarDevolucao(string e2eId, string id, string contaCorrente)
        {
            if (e2eId == null)
            {
                throw new Exception("e2eId obrigatorio.");
            }
            var client = new RestClient($"{BASEURL}/{e2eId}/devolucao/{id}");
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

            var res = JsonConvert.DeserializeObject<PixRecebidoDevolucao>(response.Content);
            return res;
        }


    }
}
