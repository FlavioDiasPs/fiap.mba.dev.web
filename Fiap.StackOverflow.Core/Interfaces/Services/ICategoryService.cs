using System.Collections.Generic;
using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;

namespace Fiap.StackOverflow.Core.Interfaces.Services
{
    public interface ICategoryService : IServiceBase<Category>
    {
        Category GetCompletedById(int id);
    }
}
