using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseImageFromModel = EEMC2.Services.Models.CourseImage;

namespace EEMC2.Services.Services.CourseImage
{
    public interface ICourseImageService
    {
        public IEnumerable<CourseImageFromModel> Get();
        public void Add(CourseImageFromModel course);
        public void Remove(CourseImageFromModel course);
        public void Update(CourseImageFromModel course);
    }
}
