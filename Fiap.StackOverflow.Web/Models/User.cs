
using System;

namespace Fiap.StackOverflow.Web.Models
{
    public class User
    {
        private long UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserDetail UserDetail { get; set; }
    }
}
