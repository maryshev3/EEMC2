using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseImageFromModel = EEMC2.Services.Models.CourseImage;

namespace EEMC2.Services.Repositories.CourseImage
{
    public interface ICourseImageRepository : IRepository<CourseImageFromModel>
    {
    }
}
