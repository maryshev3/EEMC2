using EEMC2.AppStart;
using EEMC2.Services.Models;
using EEMC2.Services.Repositories.Course;
using EEMC2.Services.Repositories.CourseImage;
using EEMC2.Services.Repositories.Section;
using EEMC2.Services.Repositories.Theme;
using EEMC2.Services.Services.Course;
using EEMC2.Services.Services.CourseFull;
using EEMC2.Services.Services.CourseImage;
using EEMC2.Services.Services.Section;
using EEMC2.Services.Services.SectionFull;
using EEMC2.Services.Services.Theme;
using EEMC2.Services.Utils;
using EEMC2.Utils;
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
    public class ViewModelLocator
    {
        private const uint _imageWidth = 600;
        private const uint _imageHeight = 356;

        public static ServiceProvider _serviceProvider;

        public static MainWindowVM MainWindowVM => _serviceProvider.GetService<MainWindowVM>();
        public static CoursesListVM CoursesListVM => _serviceProvider.GetService<CoursesListVM>();
        public static AddCourseVM AddCourseVM => _serviceProvider.GetService<AddCourseVM>();

        private static void InitFileRepositories(IServiceCollection services, string filesBasePath)
        {
            services.AddSingleton<ICourseRepository, CourseFileRepository>(_ =>
            {
                return new CourseFileRepository(filesBasePath, $"{nameof(Course)}.json");
            });

            services.AddSingleton<ICourseImageRepository, CourseImageFileRepository>(_ =>
            {
                return new CourseImageFileRepository(filesBasePath, $"{nameof(CourseImage)}.json");
            });

            services.AddSingleton<ISectionRepository, SectionFileRepository>(_ =>
            {
                return new SectionFileRepository(filesBasePath, $"{nameof(Section)}.json");
            });

            services.AddSingleton<IThemeRepository, ThemeFileRepository>(_ =>
            {
                return new ThemeFileRepository(filesBasePath, $"{nameof(Theme)}.json");
            });
        }

        private static void InitServices(IServiceCollection services)
        {
            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<ICourseImageService, CourseImageService>();
            services.AddSingleton<ISectionService, SectionService>();
            services.AddSingleton<IThemeService, ThemeService>();
        }

        private static void InitFullServices(IServiceCollection services)
        {
            services.AddSingleton<ISectionFullService, SectionFullService>();
            services.AddSingleton<ICourseFullService, CourseFullService>();
        }

        public static void Init()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IServiceProvider, ServiceProvider>(_ => _serviceProvider);

            services.AddSingleton<ImageGeneratorUtil>(_ => new ImageGeneratorUtil(_imageWidth, _imageHeight));

            var fileStorageConstructorResult = new FileStorageConstructor().Construct();

            InitFileRepositories(services, fileStorageConstructorResult.RepositoryFilesPath);

            InitServices(services);

            services.AddSingleton<CourseImageGenerator>(sp => new CourseImageGenerator(
                    courseImageService: sp.GetService<ICourseImageService>(),
                    imageGenerator: sp.GetService<ImageGeneratorUtil>(),
                    imagesBasePath: fileStorageConstructorResult.ImagesPath
                )
            );

            InitFullServices(services);

            services.AddSingleton<AppState>();
            services.AddSingleton<WindowService>();

            services.AddTransient<AddCourseVM>();
            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<CoursesListVM>();

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
