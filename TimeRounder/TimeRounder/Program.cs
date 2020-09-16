using Microsoft.Extensions.DependencyInjection;
using System;
using TimeRounder.Factories.TimeSpanRounder;
using TimeRounder.Helpers;
using TimeRounder.Interfaces.Helpers;

namespace TimeRounder
{
    class Program
    {
        
        #region Main
        static void Main(string[] args)
        {
            //obtaining service provider
            var serviceProvider = GetServiceProvider();
            //creating a scope for the application
            using (var scope = serviceProvider.CreateScope())
            {
                //Class which contains method to start the compute.
                scope.ServiceProvider.GetRequiredService<Startup>().Start();
            }
            //disposing service container
            DisposeServiceProvider(serviceProvider);
        }
        #endregion Main
        #region Methods
        /// <summary>
        /// Method used to register type into service container.
        /// </summary>
        private static ServiceProvider GetServiceProvider()
        {
            //instanciate service collection.
            var services = new ServiceCollection();
            //register types .
            services.AddSingleton<Startup>()
            .AddSingleton<IRoundHelper, RoundHelper>()
            .AddSingleton<TimeSpanRounderFactory>();
            //building service container.
            return services.BuildServiceProvider(true);
        }
        /// <summary>
        /// Used to dispose service container.
        /// </summary>
        /// <param name="serviceProvider"></param>
        private static void DisposeServiceProvider(ServiceProvider serviceProvider)
        {
            //if null nothing to dispose
            if (serviceProvider == null)
            {
                return;
            }
            //disposing service container
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
        #endregion
    }
}
