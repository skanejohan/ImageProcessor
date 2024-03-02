namespace ImageProcessorLib.ImageProcessorExtensions
{
    public static class ImageProcessorPixelExtensions
    {
        public static Image GetExpandedToPixelSize(this ImageProcessor imageProcessor, int pixelSize, bool outline = false)
        {
            var originalImage = imageProcessor.Get().CloneAs<Rgba32>();
            var ip = ImageProcessor.StartFromScratch(originalImage.Width * pixelSize, originalImage.Height * pixelSize);

            originalImage.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var x = 0;
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    foreach (ref Rgba32 pixel in pixelRow)
                    {
                        ip.WithSolidRectangle(x * pixelSize, y * pixelSize, pixelSize, pixelSize, pixel);
                        if (outline)
                        {
                            ip.WithSolidRectangle(x * pixelSize, y * pixelSize, pixelSize, 1, Color.Black);
                            ip.WithSolidRectangle(x * pixelSize, y * pixelSize, 1, pixelSize, Color.Black);
                        }
                        x++;
                    }
                }
            });
            return ip.Get();
        }
    }
}
