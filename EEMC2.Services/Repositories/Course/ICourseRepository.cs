using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFromModel = EEMC2.Services.Models.Course;

namespace EEMC2.Services.Repositories.Course
{
    public interface ICourseRepository
    {
        public List<CourseFromModel> Get();
        public void Remove(CourseFromModel course);
        public void Add(CourseFromModel course);
        public void Update(CourseFromModel course);
    }
}
