using ImageProcessorLib;
using ImageProcessorLib.ImageProcessorExtensions;
using SixLabors.ImageSharp;

namespace EdgeDetection
{
    internal class EdgeDetection
    {
        static void Main()
        {
            ImageProcessor.StartFromSourceFile("img_woman.jpg")
                .GetEdges()
                .Save("Woman.png");
        }
    }
}
