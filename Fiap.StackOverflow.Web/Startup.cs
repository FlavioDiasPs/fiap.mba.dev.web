
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Core.Services;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiap.StackOverflow.Web
{
    public class Startup
    {
        public static string ConnectionString { get; private set; }

        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("appSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {

            serviceCollection.AddDbContext<StackOverflowContext>(options => options.UseSqlServer(ConnectionString));

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddTransient<IQuestionService, QuestionService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IAnswerService, AnswerService>();

            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IQuestionRepository, QuestionRepository>();
            serviceCollection.AddTransient<IAnswerRepository, AnswerRepository>();

            serviceCollection.AddMvc();

        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

            if (hostingEnvironment.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();

            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                }
           );
        }
    }
}