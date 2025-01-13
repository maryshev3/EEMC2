using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFromModel = EEMC2.Services.Models.Course;

namespace EEMC2.Services.Services.Course
{
    public interface ICourseService
    {
        public IEnumerable<CourseFromModel> Get();
        public void Add(CourseFromModel course);
        public void Remove(CourseFromModel course);
        public void Update(CourseFromModel course);
    }
}
