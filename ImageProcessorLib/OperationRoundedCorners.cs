using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageProcessorLib
{
    public static class OperationRoundedCorners
    {
        /// <summary>
        /// Apply rounded corners with given radius to the image.
        /// </summary>
        public static ImageProcessor WithRoundedCorners(this ImageProcessor imageProcessor, float radius)
        {
            imageProcessor.AddOperation(ctx => 
            {
                var size = ctx.GetCurrentSize();
                IPathCollection corners = BuildCorners(size.Width, size.Height, radius);
                ctx.SetStandardGraphicsOptions(delete: true);
                foreach (IPath path in corners)
                {
                    ctx.Fill(Color.Red, path); // Color doesn't matter
                }
                ctx.SetStandardGraphicsOptions();
            });
            return imageProcessor;
        }

        private static IPathCollection BuildCorners(int w, int h, float r)
        {
            var rect = new RectangularPolygon(-0.5f, -0.5f, r, r);
            var cornerTopLeft = rect.Clip(new EllipsePolygon(r - 0.5f, r - 0.5f, r));
            float rightPos = w - cornerTopLeft.Bounds.Width + 1;
            float bottomPos = h - cornerTopLeft.Bounds.Height + 1;
            var cornerTopRight = cornerTopLeft.RotateDegree(90).Translate(rightPos, 0);
            var cornerBottomLeft = cornerTopLeft.RotateDegree(-90).Translate(0, bottomPos);
            var cornerBottomRight = cornerTopLeft.RotateDegree(180).Translate(rightPos, bottomPos);
            return new PathCollection(cornerTopLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight);
        }
    }
}
