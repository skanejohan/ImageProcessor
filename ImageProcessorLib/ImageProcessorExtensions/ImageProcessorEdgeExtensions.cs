using ImageProcessorLib.ImageExtensions;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace ImageProcessorLib.ImageProcessorExtensions
{
    public static class ImageProcessorEdgeExtensions
    {
        /// <summary>
        /// Generate and return an image containing edges, using the default "Sobel" kernel.
        /// The edges will be black, the rest of the image will be transparent.
        /// </summary>
        public static Image GetEdges(this ImageProcessor imageProcessor)
        {
            return imageProcessor.GetEdges(KnownEdgeDetectorKernels.Sobel);
        }

        /// <summary>
        /// Generate and return an image containing edges, using the specified kernel. 
        /// The edges will be black, the rest of the image will be transparent.
        /// </summary>
        public static Image GetEdges(this ImageProcessor imageProcessor, EdgeDetectorKernel kernel)
        {
            return imageProcessor.GetEdges(ctx => ctx.DetectEdges(kernel));
        }

        /// <summary>
        /// Generate and return an image containing edges, using the specified kernel. 
        /// The edges will be black, the rest of the image will be transparent.
        /// </summary>
        public static Image GetEdges(this ImageProcessor imageProcessor, EdgeDetector2DKernel kernel)
        {
            return imageProcessor.GetEdges(ctx => ctx.DetectEdges(kernel));
        }

        /// <summary>
        /// Generate and return an image containing edges, using the specified kernel. 
        /// The edges will be black, the rest of the image will be transparent.
        /// </summary>
        public static Image GetEdges(this ImageProcessor imageProcessor, EdgeDetectorCompassKernel kernel)
        {
            return imageProcessor.GetEdges(ctx => ctx.DetectEdges(kernel));
        }

        internal static Image GetEdges(this ImageProcessor imageProcessor, Action<IImageProcessingContext> detectEdges)
        {
            imageProcessor.AddOperation(detectEdges);
            imageProcessor.AddOperation(ctx => ctx.AdaptiveThreshold());
            return imageProcessor.Get()
                .WithTransparencySet(pixel => pixel.R == 0)
                .WithColorConverted(pixel => pixel.R == 255, Color.Black);
        }

    }
}
