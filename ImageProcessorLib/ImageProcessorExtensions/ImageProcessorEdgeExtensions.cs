using ImageProcessorLib.ImageExtensions;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace ImageProcessorLib.ImageProcessorExtensions
{
    public static class ImageProcessorEdgeExtensions
    {
        public static Image GetEdges(this ImageProcessor imageProcessor)
        {
            return imageProcessor.GetEdges(KnownEdgeDetectorKernels.Sobel);
        }

        public static Image GetEdges(this ImageProcessor imageProcessor, EdgeDetector2DKernel kernel)
        {
            imageProcessor.AddOperation(ctx => ctx.DetectEdges(kernel));
            imageProcessor.AddOperation(ctx => ctx.AdaptiveThreshold());
            return imageProcessor.Get()
                .WithTransparencySet(pixel => pixel.R == 0)
                .WithColorConverted(pixel => pixel.R == 255, Color.Black);
        }


    }
}
