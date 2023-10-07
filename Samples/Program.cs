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
