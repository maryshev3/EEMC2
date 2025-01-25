using EEMC2.Services.Services.Course;
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

        public CourseFullService(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public CourseFullFromModel Get()
        {
            throw new NotImplementedException();
        }
    }
}
