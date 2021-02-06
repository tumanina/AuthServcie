using System;

namespace AuthService.Common.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
