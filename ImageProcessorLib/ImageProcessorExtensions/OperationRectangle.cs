using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageProcessorLib.ImageProcessorExtensions;

public static class OperationRectangle
{
    /// <summary>
    /// Add a filled rectangle with given parameters.
    /// </summary>
    public static ImageProcessor WithSolidRectangle(this ImageProcessor imageProcessor, int x, int y, int w, int h, Color color)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, x, y, w, h, color); });
        return imageProcessor;
    }

    /// <summary>
    /// Add a non-filled rectangle with given parameters.
    /// </summary>
    public static ImageProcessor WithRectangle(this ImageProcessor imageProcessor, int x, int y, int w, int h, int lineWidth, Color color)
    {
        imageProcessor.WithSolidRectangle(x, y, w, lineWidth, color); // Top
        imageProcessor.WithSolidRectangle(x, y, lineWidth, h, color); // Left
        imageProcessor.WithSolidRectangle(x, y + h - lineWidth, w, lineWidth, color); // Bottom
        imageProcessor.WithSolidRectangle(x + w - lineWidth, y, lineWidth, h, color); // Right
        return imageProcessor;
    }

    /// <summary>
    /// Remove a rectangle with given parameters.
    /// </summary>
    public static ImageProcessor WithoutSolidRectangle(this ImageProcessor imageProcessor, int x, int y, int w, int h)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, x, y, w, h, Color.Black, true); });
        return imageProcessor;
    }

    private static void Apply(IImageProcessingContext ctx, int x, int y, int w, int h, Color color, bool delete = false)
    {
        ctx.SetStandardGraphicsOptions(delete);
        ctx.Fill(color, new Rectangle(x, y, w, h));
        ctx.SetStandardGraphicsOptions();
    }
}
