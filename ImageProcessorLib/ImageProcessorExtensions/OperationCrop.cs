namespace ImageProcessorLib.ImageProcessorExtensions;

public static class OperationCrop
{
    /// <summary>
    /// Crop the image according to the given dimensions.
    /// </summary>
    public static ImageProcessor CroppedTo(this ImageProcessor imageProcessor, int left, int top, int width, int height)
    {
        imageProcessor.AddOperation(ctx =>
        {
            var size = ctx.GetCurrentSize();
            var l = Math.Max(0, left);
            var t = Math.Max(0, top);
            var w = Math.Min(width, size.Width - l);
            var h = Math.Min(height, size.Height - t);
            ctx.Crop(new Rectangle(l, t, w, h));
        });
        return imageProcessor;
    }
}
