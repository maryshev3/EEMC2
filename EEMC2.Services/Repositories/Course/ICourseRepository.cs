using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFromModel = EEMC2.Services.Models.Course;

namespace EEMC2.Services.Repositories.Course
{
    public interface ICourseRepository : IRepository<CourseFromModel>
    {
    }
}
