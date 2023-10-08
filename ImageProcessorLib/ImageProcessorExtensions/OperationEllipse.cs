using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageProcessorLib.ImageProcessorExtensions;

public static class OperationEllipse
{
    /// <summary>
    /// Add a circle with given parameters.
    /// </summary>
    public static ImageProcessor WithCircle(this ImageProcessor imageProcessor, float cx, float cy, float radius, Color color)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, radius, radius, color); });
        return imageProcessor;
    }

    /// <summary>
    /// Remove a circle with given parameters.
    /// </summary>
    public static ImageProcessor WithoutCircle(this ImageProcessor imageProcessor, float cx, float cy, float radius)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, radius, radius, Color.Black, true); });
        return imageProcessor;
    }

    /// <summary>
    /// Add an ellipse with given parameters.
    /// </summary>
    public static ImageProcessor WithEllipse(this ImageProcessor imageProcessor, float cx, float cy, float rx, float ry, Color color)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, rx, ry, color); });
        return imageProcessor;
    }

    /// <summary>
    /// Remove an ellipse with given parameters.
    /// </summary>
    public static ImageProcessor WithoutEllipse(this ImageProcessor imageProcessor, float cx, float cy, float rx, float ry)
    {
        imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, rx, ry, Color.Black, true); });
        return imageProcessor;
    }

    private static void Apply(IImageProcessingContext ctx, float cx, float cy, float rx, float ry, Color color, bool delete = false)
    {
        ctx.SetStandardGraphicsOptions(delete);
        ctx.Fill(color, new EllipsePolygon(cx, cy, 2 * rx, 2 * ry));
        ctx.SetStandardGraphicsOptions();
    }
}
