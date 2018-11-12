namespace Fiap.StackOverflow.Web.Models
{
    public class QuestionTagModel
    {
        public QuestionModel Question { get; set; }
        public int QuestionId { get; set; }
        public TagModel Tag { get; set; }
        public int TagId { get; set; }
    }
}
