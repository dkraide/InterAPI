using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;

namespace InterAPI.Utils
{
    public  class Helpers
    {
        public static X509Certificate2 GetCertificate2(byte[] certFile, string password)
        {
            try
            {
                return new X509Certificate2(certFile, password);

            }
            catch
            {
                return null;
            }
        }
        public static string GetOnlyNumbers(string text)
        {
            return new String(text.Where(Char.IsDigit).ToArray());
        }
        public static string ValidarCnpjCpf(string cnpjCpf)
        {
            if(string.IsNullOrEmpty(cnpjCpf))
                return null;

            string formatted = GetOnlyNumbers(cnpjCpf);
            if (formatted.Length != 11 && formatted.Length != 15)
                return null;

            return formatted;
        }
    }
}
