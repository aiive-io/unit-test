using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07.WebApi.IntegrationTest
{
    public class Startup
    {
        private IConfigurationRoot configuration;

        public void ConfigureHost(IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureHostConfiguration(builder => { })
            .ConfigureAppConfiguration((context, builder) =>
            {
                configuration = builder.AddJsonFile("appsettings.json")                           
                           .AddEnvironmentVariables()
                           .Build();
            });
            
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepositorio, FakePessoaRepository>();
        }

        public class FakePessoaRepository: IPessoaRepositorio
        {

        }
    }
}
