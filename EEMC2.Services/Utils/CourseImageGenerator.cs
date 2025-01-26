using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseImage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageGeneratorUtil = EEMC2.ImageGenerator.ImageGenerator;

namespace EEMC2.Services.Utils
{
    public class CourseImageGenerator
    {
        private readonly ICourseImageService _courseImageService;
        private readonly ImageGeneratorUtil _imageGenerator;
        private readonly string _imagesBasePath;

        public CourseImageGenerator(
            ICourseImageService courseImageService,
            ImageGeneratorUtil imageGenerator,
            string imagesBasePath
        ) 
        {
            _courseImageService = courseImageService;
            _imageGenerator = imageGenerator;
            _imagesBasePath = imagesBasePath;

            EnsureImageBasePathExist(_imagesBasePath);
        }

        private void EnsureImageBasePathExist(string imageBasePath) =>
            Directory.CreateDirectory(imageBasePath);

        private string GenerateImagePath(Guid courseImageId) =>
            Path.Join(_imagesBasePath, courseImageId.ToString());

        public CourseImage GenerateImageAndSave(Guid courseId)
        {
            var courseImage = new CourseImage();

            courseImage.CourseId = courseId;
            courseImage.ImagePath = GenerateImagePath(courseImage.Id);

            _imageGenerator.Generate(courseImage.ImagePath);

            _courseImageService.Add(courseImage);

            return courseImage;
        }
    }
}
