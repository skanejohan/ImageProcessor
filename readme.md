<h1 align="center" style="display: block; font-size: 2.5em; font-weight: bold; margin-block-start: 1em; margin-block-end: 1em;">
  <img align="center" src="logo.png" alt="Meander logo by Johan Åhlgren" style="width:640px"/>
</h1>

Meander is a .net library allowing you to produce images by performing modifications to existing images, or to images generated from scratch.

The Meander library depends on the following libraries:

 - [SixLabors.ImageSharp](https://github.com/SixLabors/ImageSharp)
 - [SixLabors.ImageSharp.Drawing](https://github.com/SixLabors/ImageSharp.Drawing)

# Principles

You start by specifying either an existing image file on disk, an image in memory, or dimensions of an empty image. No processing is done in this step, this just starts the chain of operations that will eventually be performed. You then add more operations that will be performed on the image. Finally, you call the Get() function to generate and return the resulting image.

# Why "Meander"?

A river that [meanders](https://en.wikipedia.org/wiki/Meander) through a region will in time modify it, just like our library will modify images. The name also reflects the [fluent principles](https://en.wikipedia.org/wiki/Fluent_interface) that guide the Meander library.

# Getting started

A "hello, world" application, starting from scratch, setting the background color to yellow and adding the text "Hello, world" in the center of the image: 

````c#
    ImageProcessor.StartFromScratch(320, 200)
        .WithSolidRectangle(0, 0, 320, 200, Color.Yellow)
        .WithText("Hello, World", 160, 100, Color.Blue, "Arial", 32, HorizontalAlignment.Center, VerticalAlignment.Center)
        .Get();
````

This code returns an [image](https://docs.sixlabors.com/api/ImageSharp/SixLabors.ImageSharp.Image.html), which can e.g. be saved to disk using its Save() function.

## Combining images

# Samples
