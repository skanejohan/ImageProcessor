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
        /// Start processing of a new image, from an image loaded from the given file.
        /// </summary>
        public ImageProcessor StartFromSourceFile(string file)
        {
            getImageFunc = () => Image.Load(file);
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
            return GetModifiedImage();
        }

        /// <summary>
        /// Generate and save the resulting image to the given file.
        /// </summary>
        public void Save(string fileName)
        {
            using var image = GetModifiedImage();
            image.Save(fileName);
        }

        internal void AddOperation(Action<IImageProcessingContext> operation)
        {
            operations.Add(operation);
        }

        private Image GetModifiedImage()
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

        private Func<Image> getImageFunc = () => throw new NullReferenceException("No Start method has been called");

        private readonly List<Action<IImageProcessingContext>> operations = new();
    }
}