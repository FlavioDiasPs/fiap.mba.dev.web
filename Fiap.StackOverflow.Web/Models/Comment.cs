using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    public class Comment
    {
        public Content Content { get; set; }
        public List<Content> ContentHistory { get; set; }
        public User User { get; set; }
        public int FavoriteCount { get; set; }
        public int UsefullMarkCount { get; set; }        
    }
}
