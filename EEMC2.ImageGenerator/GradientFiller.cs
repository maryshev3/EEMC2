using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ImageGenerator
{
    public class GradientFiller
    {
        private readonly Color _startColor;
        private readonly Color _endColor;
        private readonly LinearGradientMode _linearGradientMode;

        public GradientFiller(Color startColor, Color endColor, LinearGradientMode linearGradientMode) 
        {
            _startColor = startColor;
            _endColor = endColor;
            _linearGradientMode = linearGradientMode;
        }

        public void FillBitmap(Bitmap bitmap)
        {
            using Graphics graphics = Graphics.FromImage(bitmap);

            Rectangle rectangle = new(
                0,
                0,
                bitmap.Width,
                bitmap.Height
            );

            using LinearGradientBrush brush = new LinearGradientBrush(
                rectangle,
                _startColor,
                _endColor,
                _linearGradientMode
            );

            graphics.FillRectangle(
                brush,
                rectangle
            );
        }
    }
}
