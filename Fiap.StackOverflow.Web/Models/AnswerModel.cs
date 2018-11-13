using Fiap.StackOverflow.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Votes { get; set; }
        public AuthorModel Author { get; set; }
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Preencher campo Description"), MaxLength(2048)]
        public string Description { get; set; }
        public int QuestionId { get; set; }
        public int Id { get; set; }        
    }
}
