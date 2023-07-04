using InterAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Utils
{
    public static class ConstApi
    {
        public static AccessToken Token { get; set; }
        public static X509Certificate2 certificate2 { get; set; }
    }
}
