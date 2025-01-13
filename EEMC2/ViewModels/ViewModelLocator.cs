using EEMC2.Services.Models;
using EEMC2.Services.Repositories.Course;
using EEMC2.Services.Services.Course;
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

        public static MainWindowVM MainWindowVM => _serviceProvider.GetService<MainWindowVM>();
        public static CoursesListVM CoursesListVM => _serviceProvider.GetService<CoursesListVM>();

        private static void InitFileRepositories(IServiceCollection services)
        {
            services.AddSingleton<ICourseRepository, CourseFileRepository>(_ =>
            {
                return new CourseFileRepository(Environment.CurrentDirectory, $"{nameof(Course)}.json");
            });
        }

        private static void InitServices(IServiceCollection services)
        {
            services.AddSingleton<ICourseService, CourseService>();
        }

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IServiceProvider, ServiceProvider>(_ => _serviceProvider);

            InitFileRepositories(services);
            InitServices(services);

            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<CoursesListVM>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
