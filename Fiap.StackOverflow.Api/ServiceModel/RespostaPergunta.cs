using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Api.ServiceModel
{
    public class AnswerModel
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
