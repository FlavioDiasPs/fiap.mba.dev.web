using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    public class AnswerModel
    {
        public AnswerModel(int authorId, string description, int questionId)
        {
            AuthorId = authorId;
            Description = description;
            QuestionId = questionId;
        }

        protected AnswerModel()
        {

        }
        public int Votes { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public int Id { get; set; }
    }
}
