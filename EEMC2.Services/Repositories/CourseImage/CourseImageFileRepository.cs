using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseImageFromModel = EEMC2.Services.Models.CourseImage;

namespace EEMC2.Services.Repositories.CourseImage
{
    public class CourseImageFileRepository : FileRepositoryBase<CourseImageFromModel>, ICourseImageRepository
    {
        public CourseImageFileRepository(string baseFilePath, string courseImageFileName) : base(baseFilePath, courseImageFileName)
        {
        }

        public override void Add(CourseImageFromModel courseImage)
        {
            List<CourseImageFromModel> currentCourseImagesList = Get();

            if (currentCourseImagesList.Any(currentCourseImage => currentCourseImage.Id == courseImage.Id))
            {
                throw new ArgumentException($"При добавлении картинки курса произошла ошибка. В файле с картинками курса \"{courseImage.Id}\" уже существует. Сохранение невозможно.");
            }

            Save(currentCourseImagesList.Append(courseImage));
        }

        public override void Remove(CourseImageFromModel courseImage)
        {
            List<CourseImageFromModel> currentCourseImagesList = Get();

            if (!currentCourseImagesList.Any(currentCourseImage => currentCourseImage.Id == courseImage.Id))
            {
                throw new ArgumentException($"При удалении картинки курса произошла ошибка. В файле с картинками курса \"{courseImage.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentCourseImagesList.Where(currentCourseImage => currentCourseImage.Id != courseImage.Id));
        }

        public override void Update(CourseImageFromModel courseImage)
        {
            List<CourseImageFromModel> currentCourseImagesList = Get();

            CourseImageFromModel currentCourseForUpdate = currentCourseImagesList.FirstOrDefault(currentCourse => currentCourse.Id == courseImage.Id);

            if (currentCourseForUpdate == default)
            {
                throw new ArgumentException($"При обновлении картинки курса произошла ошибка. В файле с картинками курса \"{courseImage.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentCourseImagesList.Where(currentCourseImage => currentCourseImage != currentCourseForUpdate).Append(courseImage));
        }
    }
}
