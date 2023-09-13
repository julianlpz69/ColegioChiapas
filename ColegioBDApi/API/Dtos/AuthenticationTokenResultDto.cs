using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AuthenticationTokenResultDto
    {
        public string AccessTokoken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiry {get; set;}
    }
}