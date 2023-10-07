using ImageProcessorLib;
using SixLabors.ImageSharp;

Directory.CreateDirectory("Samples");

new ImageProcessor().StartFromScratch(100, 100)
    .Save(@"Samples\Empty.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithRectangle(0, 0, 100, 100, Color.Green)
    .WithoutRectangle(30, 30, 40, 40)
    .Save(@"Samples\Rectangle.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithCircle(50, 50, 40, Color.RebeccaPurple)
    .WithoutCircle(50, 50, 20)
    .Save(@"Samples\Circle.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithEllipse(50, 50, 40, 30, Color.BurlyWood)
    .WithoutEllipse(50, 50, 30, 20)
    .Save(@"Samples\Ellipse.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithInvertedCircle(50, 50, 40, Color.RebeccaPurple)
    .Save(@"Samples\WithInvertedCircle.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithInvertedEllipse(50, 50, 40, 30, Color.BurlyWood)
    .Save(@"Samples\WithInvertedEllipse.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithRectangle(0, 0, 100, 100, Color.Green)
    .WithoutInvertedCircle(50, 50, 40)
    .Save(@"Samples\WithoutInvertedCircle.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithRectangle(0, 0, 100, 100, Color.Green)
    .WithoutInvertedEllipse(50, 50, 40, 30)
    .Save(@"Samples\WithoutInvertedEllipse.png");

var image = new ImageProcessor().StartFromScratch(100, 100)
    .WithRectangle(0, 0, 100, 100, Color.Green)
    .WithoutInvertedEllipse(50, 50, 40, 30)
    .Get();
new ImageProcessor().StartFromImage(image)
    .WithInvertedEllipse(50, 50, 30, 40, Color.BurlyWood)
    .Save(@"Samples\WithoutInvertedEllipseWithInvertedEllipse.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithCircle(50, 50, 40, Color.RebeccaPurple)
    .CroppedTo(10, 10, 50, 50)
    .Save(@"Samples\CroppedCircle.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithCircle(50, 50, 40, Color.RebeccaPurple)
    .ResizedTo(50, 50)
    .Save(@"Samples\ResizedCircle.png");

image = new ImageProcessor().StartFromScratch(100, 100)
    .WithCircle(50, 50, 30, Color.Green)
    .Get();
new ImageProcessor().StartFromScratch(100, 100)
    .WithCircle(50, 50, 40, Color.Red)
    .WithImage(image, -20, -20, 0.5f)
    .WithImage(image, 20, 20)
    .Save(@"Samples\Image.png");

new ImageProcessor().StartFromScratch(100, 100)
    .WithRectangle(0, 0, 100, 100, Color.Green)
    .WithRoundedCorners(20)
    .Save(@"Samples\RoundedCorners.png");

new ImageProcessor().StartFromScratch(600, 400)
    .WithRectangle(0, 0, 600, 400, Color.Green)
    .WithText("HEADER", 300, 40, Color.Black, fontName: "Courier New", fontSize: 40, horizontalAlignment: SixLabors.Fonts.HorizontalAlignment.Center)
    .WithText(
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " + 
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure " + 
        "dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.", 10, 80, Color.White, 
        fontSize: 16, wrappingLength: 200)
    .Save(@"Samples\Text.png");
