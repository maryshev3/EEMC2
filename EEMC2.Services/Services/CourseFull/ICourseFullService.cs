using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFullFromModel = EEMC2.Services.Models.CourseFull;

namespace EEMC2.Services.Services.CourseFull
{
    public interface ICourseFullService
    {
        public CourseFullFromModel Get();
    }
}
