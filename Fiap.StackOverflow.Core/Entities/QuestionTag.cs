using Fiap.StackOverflow.Core.Entities.Base;

namespace Fiap.StackOverflow.Core.Entities
{
    public class QuestionTag : EntityBase
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
