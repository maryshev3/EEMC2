using EEMC2.Services.Models;
using EEMC2.Services.Repositories.CourseImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseImageFromModel = EEMC2.Services.Models.CourseImage;

namespace EEMC2.Services.Services.CourseImage
{
    public class CourseImageService : ICourseImageService
    {
        private readonly ICourseImageRepository _courseImageRepository;

        public CourseImageService(ICourseImageRepository courseImageRepository)
        {
            _courseImageRepository = courseImageRepository;
        }

        public void Add(CourseImageFromModel courseImage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseImageFromModel> Get()
        {
            throw new NotImplementedException();
        }

        public void Remove(CourseImageFromModel courseImage)
        {
            throw new NotImplementedException();
        }

        public void Update(CourseImageFromModel courseImage)
        {
            throw new NotImplementedException();
        }
    }
}
