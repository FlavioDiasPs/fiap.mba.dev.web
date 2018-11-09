using Fiap.StackOverflow.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Author : EntityBase
    {
        protected Author()
        {

        }
        public int QuestionCount { get; set; }
        public int CommentCount { get; set; }
        public Guid IdentityId { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}