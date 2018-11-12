
using AutoMapper;
using Fiap.StackOverflow.Core.Interfaces.Repositories;
using Fiap.StackOverflow.Core.Interfaces.Services;
using Fiap.StackOverflow.Core.Services;
using Fiap.StackOverflow.Infra.Data.EntityFramework;
using Fiap.StackOverflow.Infra.Data.Repositories;
using Fiap.StackOverflow.Infra.Data.Transactions;
using Fiap.StackOverflow.Infra.Data.IdentityExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using Fiap.StackOverflow.Web.Attributes;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

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
            serviceCollection.AddAutoMapper();            

            serviceCollection.AddDbContext<StackOverflowContext>(options => options.UseSqlServer(ConnectionString));

            //serviceCollection.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<StackOverflowContext>();
            serviceCollection.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<StackOverflowContext>()
                .AddDefaultUI();
                //.AddDefaultTokenProviders();
            //serviceCollection.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, AppClaimsPrincipalFactory>();
            
            serviceCollection.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                options.User.RequireUniqueEmail = true;
            });

            serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();

            serviceCollection.AddTransient<IQuestionService, QuestionService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<ITagService, TagService>();
            serviceCollection.AddTransient<IQuestionTagService, QuestionTagService>();
            serviceCollection.AddTransient<IAuthorService, AuthorService>();
            serviceCollection.AddTransient<IAnswerService, AnswerService>();

            serviceCollection.AddTransient<IQuestionRepository, QuestionRepository>();
            serviceCollection.AddTransient<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddTransient<ITagRepository, TagRepository>();
            serviceCollection.AddTransient<IQuestionTagRepository, QuestionTagRepository>();
            serviceCollection.AddTransient<IAuthorRepository, AuthorRepository>();
            serviceCollection.AddTransient<IAnswerRepository, AnswerRepository>();

            var apiAssembly = typeof(Fiap.StackOverflow.Api.Startup).GetTypeInfo().Assembly;
            var part = new AssemblyPart(apiAssembly);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment hostingEnvironment)
        {
            ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];

            if (hostingEnvironment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Question}/{action=Index}/{id?}");
                }
           );


        }
    }
}