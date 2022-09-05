using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoApiSpotify.Entitys
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }

        public override string ToString()
        {
            return $"Token de acceso: {access_token[..10]}\nTipo de token: {token_type}\nExpira en: {expires_in}";
        }
    }
}
