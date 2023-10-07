namespace ImageProcessorLib
{
    public static class OperationResize
    {
        /// <summary>
        /// Resize the image to the given dimensions.
        /// </summary>
        public static ImageProcessor ResizedTo(this ImageProcessor imageProcessor, int width, int height)
        {
            imageProcessor.AddOperation(ctx => ctx.Resize(width, height));
            return imageProcessor;
        }
    }
}
