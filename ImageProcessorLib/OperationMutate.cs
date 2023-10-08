namespace ImageProcessorLib
{
    public static class OperationMutate
    {
        /// <summary>
        /// Perform a general operation by supplying the underlying action on IImageProcessingContext.
        /// </summary>
        public static ImageProcessor WithMutation(this ImageProcessor imageProcessor, Action<IImageProcessingContext> action)
        {
            imageProcessor.AddOperation(action);
            return imageProcessor;
        }
    }
}
