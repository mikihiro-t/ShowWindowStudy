using CommunityToolkit.Mvvm.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace ShowWindowStudy
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddTransient<IWindowService, WindowService>()
                .BuildServiceProvider());

            Ioc.Default.GetRequiredService<IWindowService>().ShowMainView();
        }
    }
}