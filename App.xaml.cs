using Microsoft.Extensions.DependencyInjection;
using QNAGen.Workflows;
using System;
using System.Windows;
using WorkflowCore.Interface;

namespace QNAGen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var workflowHost = ServiceProvider.GetRequiredService<IWorkflowHost>();
            workflowHost.RegisterWorkflow<SQLGenerationWorkflow, SQLGenerationData>();
            workflowHost.Start();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddWorkflow();

            // Add any other services your application needs
            services.AddSingleton<MainWindow>();
        }
    }
}
