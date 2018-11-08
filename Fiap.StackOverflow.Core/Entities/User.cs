using Fiap.StackOverflow.Core.Entities.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class User : EntityBase
    {
        public User(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

        protected User()
        {

        }
        public string Name{ get; set;}
        public string Password{ get;set;}
        public string Email{ get;set; }
        //public UserDetail UserDetail { get; set; }

        public IEnumerable<Question> Questions { get; set; }
    }
}