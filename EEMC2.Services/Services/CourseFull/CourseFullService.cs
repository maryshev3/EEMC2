using EEMC2.Services.Models;
using EEMC2.Services.Services.Course;
using EEMC2.Services.Services.CourseImage;
using EEMC2.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFullFromModel = EEMC2.Services.Models.CourseFull;
using CourseImageFromModel = EEMC2.Services.Models.CourseImage;
using ImageGeneratorUtil = EEMC2.ImageGenerator.ImageGenerator;

namespace EEMC2.Services.Services.CourseFull
{
    public class CourseFullService : ICourseFullService
    {
        private readonly ICourseService _courseService;
        private readonly ICourseImageService _courseImageService;
        private readonly CourseImageGenerator _courseImageGenerator;

        public CourseFullService(
            ICourseService courseService,
            ICourseImageService courseImageService,
            CourseImageGenerator courseImageGenerator
        )
        {
            _courseService = courseService;
            _courseImageService = courseImageService;
            _courseImageGenerator = courseImageGenerator;
        }

        public IEnumerable<CourseFullFromModel> Get()
        {
            var courses = _courseService.Get();

            var coursesIdToImage = _courseImageService
                .Get()
                .ToDictionary(x => x.CourseId);

            var courseFulls = courses.Select(course => new CourseFullFromModel() 
            {
                Course = course,
                CourseImage = coursesIdToImage.TryGetValue(course.Id, out CourseImageFromModel existingCourseImage)
                    ? existingCourseImage
                    : _courseImageGenerator.GenerateImageAndSave(course.Id)
            }).ToList();

            return courseFulls;
        }
    }
}
