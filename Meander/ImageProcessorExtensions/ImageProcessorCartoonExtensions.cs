using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace ImageProcessorLib.ImageProcessorExtensions
{
    public static class ImageProcessorCartoonExtensions
    {
        /// <summary>
        /// Generate and return a "cartoonified" version of the image, without performing any edge detection.
        /// The imageSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image.
        /// </summary>
        public static Image GetCartoonified(this ImageProcessor imageProcessor, float imageSigma)
        {
            return imageProcessor.GetCartoonified(null, imageSigma, 0);
        }

        /// <summary>
        /// Generate and return a "cartoonified" version of the image, using the specified kernel for edge detection.
        /// The imageSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image.
        /// The edgeSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image
        /// that will be used for edge detection.
        /// </summary>
        public static Image GetCartoonified(this ImageProcessor imageProcessor, EdgeDetectorKernel kernel, 
            float imageSigma, float edgeSigma)
        {
            return imageProcessor.GetCartoonified(ctx => ctx.DetectEdges(kernel), imageSigma, edgeSigma);
        }

        /// <summary>
        /// Generate and return a "cartoonified" version of the image, using the specified kernel for edge detection.
        /// The imageSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image.
        /// The edgeSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image
        /// that will be used for edge detection.
        /// </summary>
        public static Image GetCartoonified(this ImageProcessor imageProcessor, EdgeDetector2DKernel kernel, 
            float imageSigma, float edgeSigma)
        {
            return imageProcessor.GetCartoonified(ctx => ctx.DetectEdges(kernel), imageSigma, edgeSigma);
        }

        /// <summary>
        /// Generate and return a "cartoonified" version of the image, using the specified kernel for edge detection.
        /// The imageSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image.
        /// The edgeSigma parameter indicates the sigma value to use when performing a Gaussian blur on the image
        /// that will be used for edge detection.
        /// </summary>
        public static Image GetCartoonified(this ImageProcessor imageProcessor, EdgeDetectorCompassKernel kernel, 
            float imageSigma, float edgeSigma)
        {
            return imageProcessor.GetCartoonified(ctx => ctx.DetectEdges(kernel), imageSigma, edgeSigma);
        }

        internal static Image GetCartoonified(this ImageProcessor imageProcessor, Action<IImageProcessingContext>? detectEdges,
            float imageSigma, float edgeSigma)
        {
            var originalImage = imageProcessor.Get();

            var image = ImageProcessor.StartFromImage(originalImage)
                .WithMutation(ctx => ctx.GaussianBlur(imageSigma))
                .Get();

            if (detectEdges == null)
            {
                return image;
            }

            var edgeImage = ImageProcessor.StartFromImage(originalImage)
                .WithMutation(ctx => ctx.GaussianBlur(edgeSigma))
                .GetEdges(detectEdges);

            return ImageProcessor.StartFromImage(image)
                .WithImage(edgeImage)
                .Get();
        }
    }
}
