using Fiap.StackOverflow.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.StackOverflow.Core.Entities
{
    public class QuestionTag : EntityBase
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
    public class TagCloud : EntityBase
    {
        public string TagName { get; set; }
        public int TagId { get; set; }
        public int Count { get; set; }
    }
}
