using Fiap.StackOverflow.Core.Entities.Base;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Question : EntityBase
    {
        protected Question()
        {

        }
        //public Question()
        //{
        //    Tags = new List<string>();
        //}
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public List<string> Tags { get; set; }
        public List<Answer> Answers{ get; set; }
        public int ViewCount { get; set; }
    }
}