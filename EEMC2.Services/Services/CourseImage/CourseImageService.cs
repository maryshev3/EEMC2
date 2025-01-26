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
            _courseImageRepository.Add(courseImage);
        }

        public IEnumerable<CourseImageFromModel> Get()
        {
            return _courseImageRepository.Get();
        }

        public void Remove(CourseImageFromModel courseImage)
        {
            _courseImageRepository.Remove(courseImage);
        }

        public void Update(CourseImageFromModel courseImage)
        {
            _courseImageRepository.Update(courseImage);
        }
    }
}
