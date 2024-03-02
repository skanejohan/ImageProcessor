using ImageProcessorLib;
using ImageProcessorLib.ImageProcessorExtensions;
using SixLabors.ImageSharp;

namespace PixelEffects
{
    internal class PixelEffects
    {
        static void Main()
        {
            ImageProcessor
                .StartFromSourceFile("img_london.jpg")
                .CroppedTo(220, 245, 30, 45)
                .GetExpandedToPixelSize(8)
                .Save("london.png");
        }
    }
}
