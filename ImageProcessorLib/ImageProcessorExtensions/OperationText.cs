using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;

namespace ImageProcessorLib.ImageProcessorExtensions;

public static class OperationText
{
    /// <summary>
    /// Add text with given parameters.
    /// </summary>
    public static ImageProcessor WithText(this ImageProcessor imageProcessor, string text, int left, int top, Color color,
        string fontName = "Arial", int fontSize = 24, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment verticalAlignment = VerticalAlignment.Top, float wrappingLength = 0.0f, float lineSpacing = 1.0f)
    {
        imageProcessor.AddOperation(ctx =>
        {
            var font = SystemFonts.CreateFont(fontName, fontSize);
            var textOptions = new RichTextOptions(font)
            {
                Origin = new System.Numerics.Vector2(left, top),
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = verticalAlignment,
                WrappingLength = wrappingLength,
                LineSpacing = lineSpacing
            };
            ctx.DrawText(textOptions, text, color);
        });
        return imageProcessor;
    }
}
