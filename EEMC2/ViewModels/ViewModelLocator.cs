using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    class ViewModelLocator
    {
        public static ServiceProvider _serviceProvider;

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IServiceProvider, ServiceProvider>(_ => _serviceProvider);

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
