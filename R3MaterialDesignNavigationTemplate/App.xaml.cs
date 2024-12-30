using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using R3MaterialDesignNavigationTemplate.Models;
using R3MaterialDesignNavigationTemplate.Services;
using R3MaterialDesignNavigationTemplate.ViewModels;
using R3MaterialDesignNavigationTemplate.Views;
using System.IO;
using System.Reflection;
using System.Windows;

namespace R3MaterialDesignNavigationTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost _host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration(c => { c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!); })
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<ApplicationHostService>();
                services.AddSingleton<AppConfig>(AppConfig.Load());
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<SampleBox>();
                services.AddSingleton<SampleBoxViewModel>();
                services.AddSingleton<ColorToolBox>();
                services.AddSingleton<ColorToolBoxViewModel>();
                services.AddSingleton<ThemeSettings>();
                services.AddSingleton<ThemeSettingsViewModel>();
            }).Build();

        internal FlowDirection InitialFlowDirection { get; set; }
        internal BaseTheme InitialTheme { get; set; }

        public static T? GetService<T>()
            where T : class
        {
            return _host.Services.GetService(typeof(T)) as T;
        }

        public static object? GetService(Type contentType)
        {
            return _host.Services.GetService(contentType);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.InitialTheme = BaseTheme.Inherit;
            this.InitialFlowDirection = FlowDirection.LeftToRight;
            InitTheme();
            _host.Start();
        }

        private void InitTheme()
        {
            var conf = App.GetService<AppConfig>()!;
            var paletteHelper = new PaletteHelper();
            paletteHelper.SetConfig(conf.Theme);
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            var config = App.GetService<AppConfig>()!;
            config.Theme = paletteHelper.GetConfig();
            config.Save();
            await _host.StopAsync();

            _host.Dispose();
        }
    }
}