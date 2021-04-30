using System;
using BarcodeReader.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace BarcodeReader
{
    public partial class App : Application
    {
        static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider { get => _serviceProvider; }

        static App()
        {
            _serviceProvider =
                new ServiceCollection()
                .ConfigureServices()
                .BuildServiceProvider();
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }

    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            //services.AddSingleton<IMyService, MyService>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<BarcodeViewModel>();
            return services;
        }
    }
}
