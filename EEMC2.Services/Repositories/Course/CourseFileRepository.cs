using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseFromModel = EEMC2.Services.Models.Course;
using Newtonsoft.Json;

namespace EEMC2.Services.Repositories.Course
{
    public class CourseFileRepository : FileRepositoryBase<CourseFromModel>, ICourseRepository
    {
        public CourseFileRepository(string baseFilePath, string courseFileName) : base(baseFilePath, courseFileName)
        {
        }

        public override void Add(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = Get();

            if (currentCoursesList.Any(currentCourse => currentCourse.Id == course.Id))
            {
                throw new ArgumentException($"При добавлении курса произошла ошибка. В файле с курсами \"{course.Id}\" уже существует. Сохранение невозможно.");
            }

            Save(currentCoursesList.Append(course));
        }

        public override void Remove(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = Get();

            if (!currentCoursesList.Any(currentCourse => currentCourse.Id == course.Id))
            {
                throw new ArgumentException($"При удалении курса произошла ошибка. В файле с курсами \"{course.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentCoursesList.Where(currentCourse => currentCourse.Id != course.Id));
        }

        public override void Update(CourseFromModel course)
        {
            List<CourseFromModel> currentCoursesList = Get();

            CourseFromModel currentCourseForUpdate = currentCoursesList.FirstOrDefault(currentCourse => currentCourse.Id == course.Id);

            if (currentCourseForUpdate == default)
            {
                throw new ArgumentException($"При обновлении курса произошла ошибка. В файле с курсами \"{course.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentCoursesList.Where(currentCourse => currentCourse != currentCourseForUpdate).Append(course));
        }
    }
}
