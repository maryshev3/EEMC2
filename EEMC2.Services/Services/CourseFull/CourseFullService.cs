using EEMC2.Services.Services.Course;
using EEMC2.Services.Services.CourseImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFullFromModel = EEMC2.Services.Models.CourseFull;

namespace EEMC2.Services.Services.CourseFull
{
    public class CourseFullService : ICourseFullService
    {
        private readonly ICourseService _courseService;
        private readonly ICourseImageService _courseImageService;

        public CourseFullService(ICourseService courseService, ICourseImageService courseImageService)
        {
            _courseService = courseService;
            _courseImageService = courseImageService;
        }

        public IEnumerable<CourseFullFromModel> Get()
        {
            var courses = _courseService.Get();

            var courseImages = _courseImageService.Get();


        }
    }
}
