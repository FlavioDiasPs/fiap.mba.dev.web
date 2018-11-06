using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    public class Question
    {
        public string Title { get; set; }
        public Content Content { get; set; }
        public List<Content> ContentHistory { get; set; }
        public List<Comment> Comments { get; set; }
        public Tag Tags { get; set; }
        public User User { get; set; }

    }
}
