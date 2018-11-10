using Fiap.StackOverflow.Core.Entities.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Author : EntityBase
    {
        public Author(string name, string identityId)
        {
            Name = name;
            IdentityId = identityId;
        }

        protected Author()
        {

        }
        public string Name { get; set; }
        //public IdentityUser IdentityUser { get; set; }
        public string IdentityId { get; set; }
        public int QuestionCount { get; set; }
        public int CommentCount { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}