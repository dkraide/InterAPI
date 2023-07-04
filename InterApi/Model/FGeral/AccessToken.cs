using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterAPI.Model
{
    public class AccessToken
    {
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public int Expires_in { get; set; }
        public DateTime Expire { get; set; }
        public string Scope { get; set; }
    }
}
