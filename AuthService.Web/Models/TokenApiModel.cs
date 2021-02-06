using System;

namespace AuthService.Web.Models
{
    public class TokenApiModel
    {
        public string Token { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
