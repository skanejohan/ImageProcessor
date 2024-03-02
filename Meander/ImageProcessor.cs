using ImageProcessorLib.ImageExtensions;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace ImageProcessorLib
{
    public sealed class ImageProcessor
    {
        /// <summary>
        /// Start processing of a new image, from a blank canvas with given dimensions.
        /// </summary>
        public static ImageProcessor StartFromScratch(int width, int height)
        {
            return new ImageProcessor(() => new Image<Rgba32>(width, height));
        }

        /// <summary>
        /// Start processing of a new image, from an image loaded from the given file. If ensureTransparency
        /// is true, the operation will ensure that the image has an alpha channel. If you know that the image 
        /// already has an alpha channel, set ensureTransparency to false, since adding the alpha channel is
        /// slightly less efficient.
        /// </summary>
        public static ImageProcessor StartFromSourceFile(string file, bool ensureTransparency = false)
        {
            Func<Image> getImageFunc = ensureTransparency
                ? () =>
                    {
                        using var loadedImage = Image.Load(file);
                        var transparentImage = new Image<Rgba32>(loadedImage.Width, loadedImage.Height);
                        transparentImage.Mutate(ctx => ctx.DrawImage(loadedImage, 1.0f));
                        return transparentImage;
                    }
                : () => Image.Load(file);
            return new ImageProcessor(getImageFunc);
        }

        /// <summary>
        /// Start processing of a new image, from the supplied image. Note that the supplied 
        /// image will not be modified but processing will be done on a clone of it.
        /// </summary>
        public static ImageProcessor StartFromImage(Image image)
        {
            return new ImageProcessor(() => image.Clone(_ => { }));
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

        internal void AddOperation(Action<IImageProcessingContext> operation)
        {
            operations.Add(operation);
        }

        private ImageProcessor(Func<Image> getImageFunc)
        {
            this.getImageFunc = getImageFunc;
            operations.Clear();
        }

        private readonly List<Action<IImageProcessingContext>> operations = new();
        private readonly Func<Image> getImageFunc;
    }
}