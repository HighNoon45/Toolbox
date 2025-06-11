using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using Toolbox.Infrastructure;
using Toolbox.Infrastructure.Mappings.Toolbox.Infrastructure.Mappings;

namespace Toolbox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            // Add DbContext
            services.AddDbContext<ToolboxDbContext>();

            // Add HttpClient
            services.AddSingleton<HttpClient>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(OllamaMappingProfile));

            // Add Services
            services.AddScoped<OllamaService>();
            services.AddTransient<ChatViewModel>();

            ServiceProvider = services.BuildServiceProvider();

            base.OnStartup(e);
        }
    }

}
