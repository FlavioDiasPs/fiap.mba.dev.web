using Fiap.StackOverflow.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Answer : EntityBase
    {
        public Answer(int authorId, string description, int questionId)
        {
            AuthorId = authorId;
            Description = description;
            QuestionId = questionId;
        }

        protected Answer()
        {

        }
        public int Votes { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
