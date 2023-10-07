﻿namespace ImageProcessorLib
{
    internal static class Extensions
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
    }
}
