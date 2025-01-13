using EEMC2.Services.Repositories.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFromModel = EEMC2.Services.Models.Course;

namespace EEMC2.Services.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseFromModel> Get()
        {
            return _courseRepository.Get();
        }

        public void Add(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = _courseRepository.Get();

            if (currentCoursesList.Any(currentCourse => currentCourse.Name == course.Name))
            {
                throw new ArgumentException($"При добавлении курса произошла ошибка. Курс с именем \"{course.Name}\" уже существует.");
            }

            _courseRepository.Add(course);
        }

        public void Remove(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = _courseRepository.Get();

            if (!currentCoursesList.Any(currentCourse => currentCourse.Name == course.Name))
            {
                throw new ArgumentException($"При удалении курса произошла ошибка. Курс с именем \"{course.Name}\" не существует.");
            }

            _courseRepository.Remove(course);
        }

        public void Update(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = _courseRepository.Get();

            CourseFromModel currentCourseForUpdate = currentCoursesList.FirstOrDefault(currentCourse => currentCourse.Id == course.Id);

            if (currentCourseForUpdate == default)
            {
                throw new ArgumentException($"При обновлении курса произошла ошибка. Курс с именем \"{course.Name}\" не существует.");
            }

            _courseRepository.Update(course);
        }
    }
}
