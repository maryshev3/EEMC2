using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace EEMC2.ImageGenerator
{
    public class ImageGenerator
    {
        private uint _width;
        private uint _height;

        public ImageGenerator(uint width, uint height) 
        {
            _width = width;
            _height = height;
        }

        private Color GetRandomColor(Random random) =>
            Color.FromArgb(
                random.Next(256),
                random.Next(256),
                random.Next(256)
            );

        private LinearGradientMode GetRandomLinearGradientMode(Random random) =>
            (LinearGradientMode)random.Next(4);

        private (Color startColor, Color endColor, LinearGradientMode linearGradientMode) GenerateRandomGradientParams()
        {
            Random random = new();

            return (
                GetRandomColor(random),
                GetRandomColor(random),
                GetRandomLinearGradientMode(random)
            );
        }

        public void Generate(string filePathToSave)
        {
            using Bitmap bitmap = new(
                (int)_width,
                (int)_height
            );

            (Color startColor, Color endColor, LinearGradientMode linearGradientMode) gradientParams = GenerateRandomGradientParams();
            GradientFiller gradientFiller = new(
                gradientParams.startColor,
                gradientParams.endColor,
                gradientParams.linearGradientMode
            );
            gradientFiller.FillBitmap(bitmap);

            bitmap.Save(filePathToSave);
        }
    }
}
