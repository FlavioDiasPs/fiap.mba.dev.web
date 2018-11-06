using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.StackOverflow.Web.Models
{
    [Flags]
    public enum Tag
    {
        java = 1, 
        python = 2,
        csharp = 4,
        netcore = 8       
    }
}
