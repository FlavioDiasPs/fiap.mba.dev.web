﻿using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Fiap.StackOverflow.Web.Areas.Identity.IdentityHostingStartup))]
namespace Fiap.StackOverflow.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}