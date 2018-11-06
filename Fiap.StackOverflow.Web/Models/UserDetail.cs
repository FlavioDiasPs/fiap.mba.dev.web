using System;

namespace Fiap.StackOverflow.Web.Models
{
    public class UserDetail
    {
        public int QuestionsCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime FirsTimeLogged { get; set; }
        public DateTime LastTimeLogged { get; set; }
    }
}
