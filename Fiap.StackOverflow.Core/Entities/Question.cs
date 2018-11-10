using Fiap.StackOverflow.Core.Entities.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Question : EntityBase
    {
        protected Question()
        {

        }
        public Question(int authorId, string title, string description)
        {
            AuthorId = authorId;
            Title = title;
            Description = description;
            Answers = new List<Answer>();
            ViewCount = 0;
            //Tags = new List<string>();
        }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public List<string> Tags { get; set; }
        public List<Answer> Answers{ get; set; }
        public int ViewCount { get; set; }
    }
}