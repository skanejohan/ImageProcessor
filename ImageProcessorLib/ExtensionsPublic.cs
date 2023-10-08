namespace ImageProcessorLib
{
    public static class ExtensionsPublic
    {
        public static Image SetTransparency(this Image image, Func<Rgba32, bool> shouldConvert)
        {
            return image.ConvertColor(shouldConvert, Color.Transparent);
        }

        public static Image ConvertColor(this Image image, Func<Rgba32, bool> shouldConvert, Color targetColor)
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
    }
}
