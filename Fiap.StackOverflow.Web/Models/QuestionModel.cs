using Fiap.StackOverflow.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    public class QuestionModel
    {
        public QuestionModel()
        {
            Tags = new List<string>() { "C#", "JAVA", "RenatoGay"};
            Authors = new List<SelectListItem>();
            Vote = 10;
            Answers = new List<AnswerModel>()
            {
                new AnswerModel(1, "Description lala", 1),
                new AnswerModel(2, "teu haha", 2)
            };
            Views = 99;
            Category = "Net Core";
        }

        public int Id { get; set; }
        //public UserModel Author { get; set; }
        public string Author { get; set; }

        [Required(ErrorMessage = "Preencher campo AuthorId")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Preencher campo Title"), MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Preencher campo Description"), MaxLength(256)]
        public string Description { get; set; }

        public List<string> Tags { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public int Vote { get; set; }

        public List<AnswerModel> Answers { get; set; }

        public int Views { get; set; }

        public string Category { get; set; }

        public static explicit operator QuestionModel(Question question)
        {
            return new QuestionModel()
            {
                Author = question.Author.Name,
                AuthorId = question.AuthorId,
                Description = question.Description,
                Id = question.Id,
                Title = question.Title,
                Views = question.ViewCount                
            };
        }
    }
}
