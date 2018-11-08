using Fiap.StackOverflow.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        //public UserModel Author { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Tags { get; set; }

        //public List<AnswerModel> Answers { get; set; }

        public static explicit operator QuestionModel(Question question)
        {
            return new QuestionModel()
            {
                Author = question.Author.Name,
                AuthorId = question.AuthorId,
                Description = question.Description,
                Id = question.Id,
                Title = question.Title
            };
        }
    }
}
