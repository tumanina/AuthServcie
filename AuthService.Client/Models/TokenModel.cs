using System;

namespace AuthService.Client.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
