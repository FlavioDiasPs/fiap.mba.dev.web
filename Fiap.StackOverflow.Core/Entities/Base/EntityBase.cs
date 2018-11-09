using System.ComponentModel.DataAnnotations;

namespace Fiap.StackOverflow.Core.Entities.Base
{
    public abstract class EntityBase
    {
        [Key, Required]
        public int Id { get; private set; }

    }
}
