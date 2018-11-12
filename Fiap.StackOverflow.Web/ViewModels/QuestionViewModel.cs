using Fiap.StackOverflow.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionModel Question { get; set; }
        public List<QuestionModel> Questions { get; set; }

        public string Tag { get; set; }
    }
}
