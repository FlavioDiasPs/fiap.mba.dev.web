
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Core.Services;
using Fiap.StackOverflow.Infra.Data.Context;
using Fiap.StackOverflow.Infra.Data.Repositories;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.StackOverflow.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<StackOverflowContext, StackOverflowContext>();

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            
            serviceCollection.AddTransient<IQuestionService, QuestionService>();
            serviceCollection.AddTransient<IAnswerService, AnswerService>();

            serviceCollection.AddTransient<IQuestionRepository, QuestionRepository>();
            serviceCollection.AddTransient<IAnswerRepository, AnswerRepository>();

            serviceCollection.AddMvc();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();

            applicationBuilder.UseMvc(
                r =>
                {
                    r.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                }
           );
        }
    }
}