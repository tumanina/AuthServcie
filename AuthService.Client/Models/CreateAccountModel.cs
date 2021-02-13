using System;
using System.Collections.Generic;

namespace AuthService.Client.Models
{
    public class CreateAccountModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public IEnumerable<Guid> actionIds { get; set; }
        
    }
}
