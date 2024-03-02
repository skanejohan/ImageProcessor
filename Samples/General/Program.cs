using ImageProcessorLib;
using ImageProcessorLib.ImageProcessorExtensions;
using ImageProcessorLib.Utils;
using SixLabors.ImageSharp;

namespace General
{
    public class Program 
    {
        public static void Main()
        {
            Directory.CreateDirectory("Samples");

            ImageProcessor.StartFromScratch(100, 100)
                .Get().Save(@"Samples\Empty.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithSolidRectangle(0, 0, 100, 100, Color.Green)
                .WithoutSolidRectangle(30, 30, 40, 40)
                .Get().Save(@"Samples\Rectangle.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithCircle(50, 50, 40, Color.RebeccaPurple)
                .WithoutCircle(50, 50, 20)
                .Get().Save(@"Samples\Circle.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithEllipse(50, 50, 40, 30, Color.BurlyWood)
                .WithoutEllipse(50, 50, 30, 20)
                .Get().Save(@"Samples\Ellipse.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithInvertedCircle(50, 50, 40, Color.RebeccaPurple)
                .Get().Save(@"Samples\WithInvertedCircle.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithInvertedEllipse(50, 50, 40, 30, Color.BurlyWood)
                .Get().Save(@"Samples\WithInvertedEllipse.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithSolidRectangle(0, 0, 100, 100, Color.Green)
                .WithoutInvertedCircle(50, 50, 40)
                .Get().Save(@"Samples\WithoutInvertedCircle.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithSolidRectangle(0, 0, 100, 100, Color.Green)
                .WithoutInvertedEllipse(50, 50, 40, 30)
                .Get().Save(@"Samples\WithoutInvertedEllipse.png");

            var image = ImageProcessor.StartFromScratch(100, 100)
                .WithSolidRectangle(0, 0, 100, 100, Color.Green)
                .WithoutInvertedEllipse(50, 50, 40, 30)
                .Get();
            ImageProcessor.StartFromImage(image)
                .WithInvertedEllipse(50, 50, 30, 40, Color.BurlyWood)
                .Get().Save(@"Samples\WithoutInvertedEllipseWithInvertedEllipse.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithCircle(50, 50, 40, Color.RebeccaPurple)
                .CroppedTo(10, 10, 50, 50)
                .Get().Save(@"Samples\CroppedCircle.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithCircle(50, 50, 40, Color.RebeccaPurple)
                .ResizedTo(50, 50)
                .Get().Save(@"Samples\ResizedCircle.png");

            image = ImageProcessor.StartFromScratch(100, 100)
                .WithCircle(50, 50, 30, Color.Green)
                .Get();
            ImageProcessor.StartFromScratch(100, 100)
                .WithCircle(50, 50, 40, Color.Red)
                .WithImage(image, -20, -20, 0.5f)
                .WithImage(image, 20, 20)
                .Get().Save(@"Samples\Image.png");

            ImageProcessor.StartFromScratch(100, 100)
                .WithSolidRectangle(0, 0, 100, 100, Color.Green)
                .WithRoundedCorners(20)
                .Get().Save(@"Samples\RoundedCorners.png");

            ImageProcessor.StartFromScratch(600, 400)
                .WithSolidRectangle(0, 0, 600, 400, Color.Green)
                .WithText("HEADER", 300, 40, Color.Black, fontName: "Courier New", fontSize: 40, horizontalAlignment: SixLabors.Fonts.HorizontalAlignment.Center)
                .WithText(
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                    "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " +
                    "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", 10, 80, Color.White,
                    fontSize: 16, wrappingLength: 200)
                .Get().Save(@"Samples\Text.png");

            CartoonGenerator.Generate(@"img1.jpg", @"Samples\img1");
            CartoonGenerator.Generate(@"img2.jpg", @"Samples\img2");
        }
    }
}

