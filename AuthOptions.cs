using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ReviewApi
{
    public class AuthOptions
    {
        public const string ISSUER = "ApiServer";
        public const string AUDIENCE = "ApiClient";
        const string KEY = "cA6Io@4Uf2Bg5DxM9$S0J4^SGBY@zUcJcf0GwX86W0Uhq1Fa8w";
        public const int LIFETIME = 5; //Minutes
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
