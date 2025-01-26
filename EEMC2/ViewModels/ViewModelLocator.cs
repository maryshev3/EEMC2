using EEMC2.Services.Models;
using EEMC2.Services.Repositories.Course;
using EEMC2.Services.Services.Course;
using EEMC2.Services.Services.CourseImage;
using EEMC2.Services.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGeneratorUtil = EEMC2.ImageGenerator.ImageGenerator;

namespace EEMC2.ViewModels
{
    class ViewModelLocator
    {
        private const uint _imageWidth = 600;
        private const uint _imageHeight = 356;

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

            services.AddSingleton<ImageGeneratorUtil>(_ => new ImageGeneratorUtil(_imageWidth, _imageHeight));

            InitFileRepositories(services);
            InitServices(services);
            services.AddSingleton<CourseImageGenerator>(sp => new CourseImageGenerator(
                    courseImageService: sp.GetService<ICourseImageService>(),
                    imageGenerator: sp.GetService<ImageGeneratorUtil>(),
                    imagesBasePath: Path.Join(Environment.CurrentDirectory, "Images")
                )
            );

            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<CoursesListVM>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
