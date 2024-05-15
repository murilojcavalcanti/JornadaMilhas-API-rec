using JornadaMilhas.Dados;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Integration.Test.API
{
    public class JornadaMilhasWebApplicationFactory:WebApplicationFactory<Program>
    {

        //configura um host para tests
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<JornadaMilhasContext>));

                services.AddDbContext<JornadaMilhasContext>(opts=>opts.UseLazyLoadingProxies()
                .UseSqlServer("Server = localhost\\sqlexpress; Initial Catalog =JornadaMilhasV3Tests; Integrated Security = True; Encrypt =False"));
            });
            base.ConfigureWebHost(builder);
        }
    }
}
