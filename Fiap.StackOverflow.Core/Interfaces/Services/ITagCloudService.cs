using Fiap.StackOverflow.Core.Entities;
using Fiap.StackOverflow.Core.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Fiap.StackOverflow.Core.Interfaces.Services
{
    public interface ITagCloudService : IServiceBase<TagCloud>
    {
        List<Tuple<string, int, int>> GetTagCloud(int quantity);
    }
}
