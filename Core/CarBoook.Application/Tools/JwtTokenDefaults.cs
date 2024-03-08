using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBoook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "1CAR18B74OO51K34PRO9J1E3K3T828T4E5S9T30"; // Ranodom : "A34F86311146B26952AF4A332A12A"
        public const int Expire = 3; // min
    }
}
