using ImageProcessorLib;
using ImageProcessorLib.ImageProcessorExtensions;
using SixLabors.Fonts;
using SixLabors.ImageSharp;

namespace GenerateLogo
{
    public class GenerateLogo
    {
        public static void Main()
        {
            var patternColor = Color.Black;
            var shadowColor = Color.LightSkyBlue;

            var pattern = ImageProcessor.StartFromScratch(80, 70)
                .WithSolidRectangle(0, 0, 10, 70, patternColor)
                .WithSolidRectangle(10, 0, 60, 10, patternColor)
                .WithSolidRectangle(60, 10, 10, 40, patternColor)
                .WithSolidRectangle(40, 40, 20, 10, patternColor)
                .WithSolidRectangle(40, 20, 10, 20, patternColor)
                .WithSolidRectangle(20, 20, 20, 10, patternColor)
                .WithSolidRectangle(20, 30, 10, 40, patternColor)
                .WithSolidRectangle(30, 60, 50, 10, patternColor)
                .Get();

            var repeatedPattern = ImageProcessor.StartFromScratch(640, 70)
                .WithImage(pattern, 0, 0)
                .WithImage(pattern, 80, 0)
                .WithImage(pattern, 160, 0)
                .WithImage(pattern, 240, 0)
                .WithImage(pattern, 320, 0)
                .WithImage(pattern, 400, 0)
                .WithImage(pattern, 480, 0)
                .WithImage(pattern, 560, 0)
                .Get();

            var completePattern = ImageProcessor.StartFromScratch(640, 110)
                .WithSolidRectangle(0, 0, 640, 10, patternColor)
                .WithImage(repeatedPattern, 0, 20)
                .WithSolidRectangle(0, 100, 640, 10, patternColor)
                .Get();

            ImageProcessor.StartFromSourceFile("img_water.jpg", ensureTransparency: true)
                .CroppedTo(0, 0, 640, 380)
                .WithImage(completePattern, 0, 10)
                .WithText("MEANDER", 316, 186, shadowColor, "Arial", 110, HorizontalAlignment.Center, VerticalAlignment.Center)
                .WithText("MEANDER", 324, 186, shadowColor, "Arial", 110, HorizontalAlignment.Center, VerticalAlignment.Center)
                .WithText("MEANDER", 316, 194, shadowColor, "Arial", 110, HorizontalAlignment.Center, VerticalAlignment.Center)
                .WithText("MEANDER", 324, 194, shadowColor, "Arial", 110, HorizontalAlignment.Center, VerticalAlignment.Center)
                .WithText("MEANDER", 320, 190, patternColor, "Arial", 110, HorizontalAlignment.Center, VerticalAlignment.Center)
                .WithImage(completePattern, 0, 260)
                .WithRoundedCorners(25)
                .Get().Save("logo.png");
        }
    }
}