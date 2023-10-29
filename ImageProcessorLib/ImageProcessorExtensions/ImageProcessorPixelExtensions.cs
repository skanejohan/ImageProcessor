namespace ImageProcessorLib.ImageProcessorExtensions
{
    public static class ImageProcessorPixelExtensions
    {
        public static Image GetExpandedToPixelSize(this ImageProcessor imageProcessor, int pixelSize, bool outline = false)
        {
            var originalImage = imageProcessor.Get().CloneAs<Rgba32>();
            imageProcessor.StartFromScratch(originalImage.Width * pixelSize, originalImage.Height * pixelSize);

            originalImage.ProcessPixelRows(accessor =>
            {
                for (int y = 0; y < accessor.Height; y++)
                {
                    var x = 0;
                    Span<Rgba32> pixelRow = accessor.GetRowSpan(y);
                    foreach (ref Rgba32 pixel in pixelRow)
                    {
                        imageProcessor.WithSolidRectangle(x * pixelSize, y * pixelSize, pixelSize, pixelSize, pixel);
                        if (outline)
                        {
                            imageProcessor.WithSolidRectangle(x * pixelSize, y * pixelSize, pixelSize, 1, Color.Black);
                            imageProcessor.WithSolidRectangle(x * pixelSize, y * pixelSize, 1, pixelSize, Color.Black);
                        }
                        x++;
                    }
                }
            });
            return imageProcessor.Get();
        }
    }
}
