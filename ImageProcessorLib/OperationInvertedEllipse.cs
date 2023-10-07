using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageProcessorLib
{
    public static class OperationInvertedEllipse
    {
        public static ImageProcessor WithInvertedCircle(this ImageProcessor imageProcessor, float cx, float cy, float radius, Color color)
        {
            imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, radius, radius, color); });
            return imageProcessor;
        }

        public static ImageProcessor WithoutInvertedCircle(this ImageProcessor imageProcessor, float cx, float cy, float radius)
        {
            imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, radius, radius, Color.Black, true); });
            return imageProcessor;
        }

        public static ImageProcessor WithInvertedEllipse(this ImageProcessor imageProcessor, float cx, float cy, float rx, float ry, Color color)
        {
            imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, rx, ry, color); });
            return imageProcessor;
        }

        public static ImageProcessor WithoutInvertedEllipse(this ImageProcessor imageProcessor, float cx, float cy, float rx, float ry)
        {
            imageProcessor.AddOperation(ctx => { Apply(ctx, cx, cy, rx, ry, Color.Black, true); });
            return imageProcessor;
        }

        private static void Apply(IImageProcessingContext ctx, float cx, float cy, float rx, float ry, Color color, bool delete = false)
        {
            ctx.SetStandardGraphicsOptions(delete);

            var size = ctx.GetCurrentSize();

            var upperLeft = new RectangularPolygon(0, 0, cx, cy);
            var lowerLeft = new RectangularPolygon(0, cy, cx, size.Height - cy);
            var upperRight = new RectangularPolygon(cx, 0, size.Width - cx, cy);
            var lowerRight = new RectangularPolygon(cx, cy, size.Width - cx, size.Height - cy);
            var ellipse = new EllipsePolygon(cx, cy, 2 * rx, 2 * ry);

            ctx.Fill(color, upperLeft.Clip(ellipse));
            ctx.Fill(color, lowerLeft.Clip(ellipse));
            ctx.Fill(color, lowerRight.Clip(ellipse));
            ctx.Fill(color, upperRight.Clip(ellipse));

            ctx.SetStandardGraphicsOptions();
        }
    }
}
