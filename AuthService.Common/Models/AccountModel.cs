using System;
using System.Collections.Generic;

namespace AuthService.Common.Models
{
    public class AccountModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<ActionModel> Actions { get; set; }
    }
}
