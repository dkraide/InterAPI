using InterAPI.Model;
using InterAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace InterAPI.Service
{
    public class SOAuth
    {
        public static string MessageError;
        public static AccessToken GetToken(byte[] certFile, string logger)
        {
            try
            {
                var client = new RestClient("https://cdpj.partners.bancointer.com.br/oauth/v2/token");
                X509Certificate2 certificate = Helpers.GetCertificate2(certFile, "123456");
                client.ClientCertificates = new X509CertificateCollection() { certificate};
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
               // ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded",
                    "grant_type=client_credentials&" +
                    "client_id=bbc38eaa-0884-490f-aa55-b65395f32ef3&" +
                    "client_secret=244e6d24-a97f-4f5e-a4b7-dfa72ba67ae7&" +
                    "scope=boleto-cobranca.read boleto-cobranca.write cob.write cob.read"
                    , ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                if(response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"{response.StatusCode} - {response.ErrorException} - {response.ErrorMessage}");

                AccessToken token =  JsonConvert.DeserializeObject<AccessToken>(response.Content);
                token.Expire = DateTime.Now.AddSeconds(token.Expires_in);
                ConstApi.Token = token;
                return token;
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = new StreamWriter(logger))
                {
                    sw.WriteLine(ex.ToString());
                }
                MessageError = ex.Message;
            }
            return null;
        }
        /// <summary>
        ///  Funcao inicializar o certificado na memoria. Primeira funcao que deve ser
        ///  chamada sempre.
        /// </summary>
        /// <param name="certFile">Arquivo certificado</param>
        /// <param name="password">Senha certificado</param>
        /// <returns></returns>
        public static bool SetCertificate(byte[] certFile, string password)
        {
            var x =  new X509Certificate2(certFile, password);
            if(x != null)
            {
                ConstApi.certificate2 = x;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Funcao para comecar a usar qualquer parte do projeto. 
        /// Chamar depois de SetCertificado
        /// </summary>
        /// <param name="clientId">cclientId forneceido pelo Inter</param>
        /// <param name="clientSecret">clienteSecret fornecido pelo Inter</param>
        /// <param name="scopes">acessos que o token tera separado por espaco
        /// extrato.read - Consulta de Extrato e Saldo
        /// boleto-cobranca.read - Consulta de boletos e exportação para PDF
        /// boleto-cobranca.write - Emissão e cancelamento de boletos
        /// pagamento-boleto.write - Pagamento de titulo com código de barras
        /// pagamento-boleto.read - Obter dados completos do titulo a partir do código de barras ou da linha digitável
        /// pagamento-darf.write - Pagamento de DARF sem código de barras
        /// cob.write - Alteração de cobranças imediatas
        /// cob.read - Consulta de cobranças imediatas
        /// pix.write - Alteração de pix
        /// pix.read - Consulta de pix
        /// webhook.read - Consulta do webhook
        /// webhook.write - Alteração do webhook
        /// payloadlocation.write - Alteração de payloads
        /// payloadlocation.read - Consulta de payloads
        /// 
        /// </param>
        /// <returns>Retorna true se token gerado com sucesso.</returns>
        /// <exception cref="Exception"></exception>
        public static bool SetToken(string clientId, string clientSecret, string scopes)
        {
            if (ConstApi.certificate2 == null)
                throw new Exception("CERTIFICADO NAO INICIALIZADO");

            var client = new RestClient("https://cdpj.partners.bancointer.com.br/oauth/v2/token");
            client.ClientCertificates = new X509CertificateCollection() { ConstApi.certificate2 };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter(
                "application/x-www-form-urlencoded",
                $"grant_type=client_credentials&" +
                $"client_id={clientId}&" +
                $"client_secret={clientSecret}&" +
                $"scope={scopes}"
                , ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception($"{response.StatusCode} - {response.ErrorException} - {response.ErrorMessage}");

            AccessToken token = JsonConvert.DeserializeObject<AccessToken>(response.Content);
            token.Expire = DateTime.Now.AddSeconds(token.Expires_in);
            ConstApi.Token = token;
            return true;
        }
    }
}
