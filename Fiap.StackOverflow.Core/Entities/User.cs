using Fiap.StackOverflow.Core.Entities.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class User : EntityBase
    {
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