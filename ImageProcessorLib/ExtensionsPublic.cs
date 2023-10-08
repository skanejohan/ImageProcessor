namespace ImageProcessorLib
{
    public static class ExtensionsPublic
    {
        public static Image WithTransparencySet(this Image image, Func<Rgba32, bool> shouldConvert)
        {
            return image.WithColorConverted(shouldConvert, Color.Transparent);
        }

        public static Image WithColorConverted(this Image image, Func<Rgba32, bool> shouldConvert, Color targetColor)
        {
            var clonedImage = image.CloneAs<Rgba32>();
            clonedImage.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    foreach (ref Rgba32 pixel in pixelRow)
                    {
                        if (shouldConvert(pixel))
                        {
                            pixel = targetColor;
                        }
                    }
                }
            });
            return clonedImage;
        }

        public static Image WithPalette(this Image image, IEnumerable<Rgba32> palette)
        {
            Dictionary<Rgba32, Rgba32> closestColors = new();

            var clonedImage = image.CloneAs<Rgba32>();
            clonedImage.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    foreach (ref Rgba32 pixel in pixelRow)
                    {
                        pixel = GetTargetColor(pixel);
                    }
                }
            });
            return clonedImage;

            Rgba32 GetTargetColor(Rgba32 sourceColor)
            {
                if (closestColors.TryGetValue(sourceColor, out var closestColor))
                {
                    return closestColor;
                }

                var minDist = int.MaxValue;
                foreach(var paletteColor in palette)
                {
                    var dist = sourceColor.SquaredEuclideanDistance(paletteColor);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closestColor = paletteColor;
                    }
                }
                closestColors[sourceColor] = closestColor;
                return closestColor;
            }
        }
    }
}
