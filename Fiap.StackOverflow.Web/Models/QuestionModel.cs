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
            Tags = new List<TagModel>();
            Authors = new List<SelectListItem>();
            Categories = new List<SelectListItem>();
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
        public AuthorModel Author { get; set; }

        [Required(ErrorMessage = "Preencher campo AuthorId")]        
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Preencher campo Categoria")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Preencher campo Title"), MaxLength(100)]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Preencher campo Description"), MaxLength(256)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public int Vote { get; set; }

        public string SelectedTags { get; set; }
        public List<QuestionTagModel> QuestionTags { get; set; }
        public List<TagModel> Tags { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<AnswerModel> Answers { get; set; }

        public int ViewCount { get; set; }

        public string Category { get; set; }
    }
}
