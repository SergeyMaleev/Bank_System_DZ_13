using BankSystem.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    public static class Dependency
    {

        private static readonly ServiceProvider _provider;
        static Dependency()
        {

            var services = new ServiceCollection();


            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<EntryWindowViewModel>();

            services.AddSingleton<StaffLoginWindowViewModel>();
         
            services.AddSingleton<AdminBankWindowViewModel>();

            services.AddTransient<ClientWindowViewModel>(); // Обнавляется при каждом обращении

            services.AddSingleton<NavigationService>();

            _provider = services.BuildServiceProvider();


        }

        public static T Resolve<T>() => _provider.GetRequiredService<T>();
    }
}
