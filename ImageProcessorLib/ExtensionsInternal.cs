namespace ImageProcessorLib
{
    internal static class ExtensionsInternal
    {
        public static void SetStandardGraphicsOptions(this IImageProcessingContext ctx, bool delete = false)
        {
            ctx.SetGraphicsOptions(new GraphicsOptions()
            {
                Antialias = true,
                AlphaCompositionMode = delete
                    ? PixelAlphaCompositionMode.DestOut
                    : PixelAlphaCompositionMode.SrcOver
            });
        }

        public static int SquaredEuclideanDistance(this Rgba32 color, Rgba32 other)
        {
            if (color == other)
            {
                return 0;
            }
            var dr = color.R - other.R;
            var dg = color.G - other.G;
            var db = color.B - other.B;
            var da = color.A - other.A;
            return dr * dr + dg * dg + db * db + da * da;
        }
    }
}
