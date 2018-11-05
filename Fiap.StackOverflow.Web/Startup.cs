using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Fiap.StackOverflow.Web
{
    public class Startup
    {
        public void Confgure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            applicationBuilder.Run(async (contexto) =>
            {
                await contexto.Response.WriteAsync("Teste");
            });
        }
    }
}