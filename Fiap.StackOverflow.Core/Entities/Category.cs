using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities.Base;

namespace Fiap.StackOverflow.Core.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}
