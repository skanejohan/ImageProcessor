using ImageProcessorLib.ImageExtensions;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace ImageProcessorLib
{
    public sealed class ImageProcessor
    {
        /// <summary>
        /// Start processing of a new image, from a blank canvas with given dimensions.
        /// </summary>
        public ImageProcessor StartFromScratch(int width, int height)
        {
            getImageFunc = () => new Image<Rgba32>(width, height);
            operations.Clear();
            return this;
        }

        /// <summary>
        /// Start processing of a new image, from an image loaded from the given file. If ensureTransparency
        /// is true, the operation will ensure that the image has an alpha channel. If you know that the image 
        /// already has an alpha channel, set ensureTransparency to false, since adding the alpha channel is
        /// slightly less efficient.
        /// </summary>
        public ImageProcessor StartFromSourceFile(string file, bool ensureTransparency = false)
        {
            getImageFunc = ensureTransparency
            ? () =>
                {
                    using var loadedImage = Image.Load(file);
                    var transparentImage = new Image<Rgba32>(loadedImage.Width, loadedImage.Height);
                    transparentImage.Mutate(ctx => ctx.DrawImage(loadedImage, 1.0f));
                    return transparentImage;
                }
            : () => Image.Load(file);
            operations.Clear();
            return this;
        }

        /// <summary>
        /// Start processing of a new image, from the supplied image. Note that the supplied 
        /// image will not be modified but processing will be done on a clone of it.
        /// </summary>
        public ImageProcessor StartFromImage(Image image)
        {
            getImageFunc = () => image.Clone(_ => { });
            operations.Clear();
            return this;
        }

        /// <summary>
        /// Generate and return the resulting image.
        /// </summary>
        public Image Get()
        {
            using var src = getImageFunc();
            return src.Clone(ApplyOperations);

            void ApplyOperations(IImageProcessingContext ctx)
            {
                foreach (var op in operations)
                {
                    op(ctx);
                }
            }
        }

        public Image GetEdges()
        {
            return GetEdges(KnownEdgeDetectorKernels.Sobel);
        }

        public Image GetEdges(EdgeDetector2DKernel kernel)
        {
            AddOperation(ctx => ctx.DetectEdges(kernel));
            AddOperation(ctx => ctx.AdaptiveThreshold());
            return Get()
                .WithTransparencySet(pixel => pixel.R == 0)
                .WithColorConverted(pixel => pixel.R == 255, Color.Black);
        }

        internal void AddOperation(Action<IImageProcessingContext> operation)
        {
            operations.Add(operation);
        }

        private Func<Image> getImageFunc = () => throw new NullReferenceException("No Start method has been called");

        private readonly List<Action<IImageProcessingContext>> operations = new();
    }
}