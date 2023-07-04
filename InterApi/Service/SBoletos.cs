using InterAPI.Model.FBoleto;
using InterAPI.ModelRequest;
using InterAPI.ModelResponse;
using InterAPI.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Service
{
    public static class SBoletos
    {
        const string BASEURL = @"https://cdpj.partners.bancointer.com.br/cobranca/v2/boletos";

        /// <summary>
        /// Retorna uma Lista de Boletos de acordo com os parametros
        /// </summary>
        /// <param name="Parametros">Parametros para busca</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        public static RetornoBoleto GetBoletos(BoletoGetParametro Parametros, string contaCorrente = null)
        {
            if (Parametros == null)
                throw new Exception("Objeto parametro deve ser configurado");

            var client = new RestClient($"{BASEURL}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var restrequest = new RestRequest(Method.GET);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            if (!string.IsNullOrEmpty(contaCorrente))
                restrequest.AddHeader("x-conta-corrente", contaCorrente);

            restrequest.AddQueryParameter("dataInicial", Parametros.dataInicial.ToString("yyyy-MM-dd"));
            restrequest.AddQueryParameter("dataFinal", Parametros.dataFinal.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrEmpty(Parametros.filtrarDataPor))
                restrequest.AddQueryParameter("filtrarDataPor", Parametros.filtrarDataPor);

            if (!string.IsNullOrEmpty(Parametros.situacao))
                restrequest.AddQueryParameter("situacao", Parametros.situacao);

            if (!string.IsNullOrEmpty(Parametros.nome))
                restrequest.AddQueryParameter("nome", Parametros.nome);

            if (!string.IsNullOrEmpty(Parametros.email))
                restrequest.AddQueryParameter("email", Parametros.email);

            if (!string.IsNullOrEmpty(Parametros.cpfCnpj))
                restrequest.AddQueryParameter("cpfCnpj", Parametros.cpfCnpj);

            if (Parametros.Paginacao != null)
            {
                if (Parametros.Paginacao.itensPorPagina != 100)
                    restrequest.AddQueryParameter("itensPorPagina", Parametros.Paginacao.itensPorPagina.ToString());

                if (Parametros.Paginacao.paginaAtual != 0)
                    restrequest.AddQueryParameter("paginaAtual", Parametros.Paginacao.paginaAtual.ToString());

                if (!string.IsNullOrWhiteSpace(Parametros.Paginacao.ordenarPor) &&
                    Parametros.Paginacao.ordenarPor.ToUpper() != "PAGADOR")
                    restrequest.AddQueryParameter("ordenarPor", Parametros.Paginacao.ordenarPor);

                if (!string.IsNullOrWhiteSpace(Parametros.Paginacao.tipoOrdenacao) &&
                    Parametros.Paginacao.tipoOrdenacao.ToUpper() != "ASC")
                    restrequest.AddQueryParameter("tipoOrdenacao", Parametros.Paginacao.tipoOrdenacao);
            }


            IRestResponse response = client.Execute(restrequest);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");
            return JsonConvert.DeserializeObject<RetornoBoleto>(response.Content);
        }

        /// <summary>
        /// Retorna um boleto detalhado pelo nossoNumero
        /// </summary>
        /// <param name="nossoNumero">nossoNumero do boleto</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Boleto GetBoleto(string nossoNumero, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(nossoNumero))
                throw new Exception("nossoNumero Obrigatorio");

            var client = new RestClient($"{BASEURL}/{nossoNumero}");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
           
            var restrequest = new RestRequest(Method.GET);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            if (!string.IsNullOrEmpty(contaCorrente))
                restrequest.AddHeader("x-conta-corrente", contaCorrente);

            IRestResponse response = client.Execute(restrequest);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<Boleto>(response.Content);
        }

        /// <summary>
        /// Utilizado para recuperar o sumário de uma coleção de Boletos por um período específico, de acordo com os parâmetros informados.
        /// </summary>
        /// <param name="Parametros">Parametros para busca</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static RetornoBoletoSumario GetSumario(BoletoGetParametro Parametros, string contaCorrente = null)
        {
            if (Parametros == null)
                throw new Exception("Objeto parametro deve ser configurado");

            var client = new RestClient($"{BASEURL}/sumario");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var restrequest = new RestRequest(Method.GET);
            restrequest.AddHeader("Accept", "application/json");
            restrequest.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            if (!string.IsNullOrEmpty(contaCorrente))
                restrequest.AddHeader("x-conta-corrente", contaCorrente);

            restrequest.AddQueryParameter("dataInicial", Parametros.dataInicial.ToString("yyyy-MM-dd"));
            restrequest.AddQueryParameter("dataFinal", Parametros.dataFinal.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrEmpty(Parametros.filtrarDataPor))
                restrequest.AddQueryParameter("filtrarDataPor", Parametros.filtrarDataPor);

            if (!string.IsNullOrEmpty(Parametros.situacao))
                restrequest.AddQueryParameter("situacao", Parametros.situacao);

            if (!string.IsNullOrEmpty(Parametros.nome))
                restrequest.AddQueryParameter("nome", Parametros.nome);

            if (!string.IsNullOrEmpty(Parametros.email))
                restrequest.AddQueryParameter("email", Parametros.email);

            if (!string.IsNullOrEmpty(Parametros.cpfCnpj))
                restrequest.AddQueryParameter("cpfCnpj", Parametros.cpfCnpj);

            IRestResponse response = client.Execute(restrequest);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<RetornoBoletoSumario>(response.Content);
        }

        /// <summary>
        /// Funcao responsavel por criar o boleto
        /// </summary>
        /// <param name="boleto">Objeto a ser criado</param>
        /// <returns></returns>
        public static RetornoEnvioBoleto CreateBoleto(Boleto boleto, string contaCorrente = null)
        {
            var client = new RestClient(BASEURL);
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            request.AddParameter("application/json",
                          boleto.GetToCreate(),
                ParameterType.RequestBody);

            if (!string.IsNullOrEmpty(contaCorrente))
                request.AddHeader("x-conta-corrente", contaCorrente);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<RetornoEnvioBoleto>(response.Content);
        }

        /// <summary>
        /// Recupera um boleto em pdf(string) de acordo com o parâmetro nossoNumero informado.
        /// </summary>
        /// <param name="nossoNumero">nossoNumero do boleto</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static RetornoBoletoImpressao GetBoletoPDF(string nossoNumero, string contaCorrente = null)
        {
            if (string.IsNullOrEmpty(nossoNumero))
                throw new Exception("nossoNumero Obrigatorio");


            var client = new RestClient($"{BASEURL}/{nossoNumero}/pdf");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");
            if (!string.IsNullOrEmpty(contaCorrente))
                request.AddHeader("x-conta-corrente", contaCorrente);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return JsonConvert.DeserializeObject<RetornoBoletoImpressao>(response.Content);
        }

        /// <summary>
        /// Realiza o cancelamento de um boleto.
        /// </summary>
        /// <param name="motivo">ACERTOS, APEDIDODOCLIENTE, PAGODIRETOAOCLIENTE ou SUBSTITUICAO</param>
        /// <param name="nossoNumero">nossoNumero do boleto</param>
        /// <param name="contaCorrente">Conta corrente que será utilizada na operação. Necessário somente quando a aplicação estiver associada a mais de uma conta corrente.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CancelarBoleto(string motivo, string nossoNumero, string contaCorrente)
        {
            if (string.IsNullOrEmpty(nossoNumero))
                throw new Exception("nossoNumero Obrigatorio");

            if (string.IsNullOrEmpty(motivo))
                throw new Exception("motivo Obrigatorio");


            var client = new RestClient($"{BASEURL}/{nossoNumero}/cancelar");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {ConstApi.Token.Access_token}");

            request.AddParameter("application/json",
                            new {motivoCancelamento = motivo},
                  ParameterType.RequestBody);

            if (!string.IsNullOrEmpty(contaCorrente))
                request.AddHeader("x-conta-corrente", contaCorrente);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.NoContent)
                throw new Exception($"{response.StatusCode} - {response.StatusDescription}");

            return true;
        }
    }
}
