using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineAkademi.Utils.Helpers
{
    public static class ServiceActivator
    {
        internal static IServiceProvider _serviceProvider = null;

        /// <summary>
        /// Configure ServiceActivator with full serviceProvider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Configure(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Create a scope where use this ServiceActivator
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static TService GetService<TService>()
        {
            if(_serviceProvider!=null)
            {
                return _serviceProvider.GetRequiredService<TService>();
            }      
            else
            {
                var scope = _serviceProvider.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                return scope.ServiceProvider.GetRequiredService<TService>();
            }
        }
    }
}
