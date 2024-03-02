using ImageProcessorLib;
using ImageProcessorLib.ImageProcessorExtensions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Convolution;

namespace CartoonEffects
{
    public class CartoonEffects
    {
        static void Main()
        {
            ImageProcessor
                .StartFromSourceFile("img_house.jpg")
                .GetCartoonified(KnownEdgeDetectorKernels.Prewitt, 1, 1)
                .Save("house.png");

            Run("Laplacian3x3", KnownEdgeDetectorKernels.Laplacian3x3);
            Run("Laplacian5x5", KnownEdgeDetectorKernels.Laplacian5x5);
            Run("LaplacianOfGaussian", KnownEdgeDetectorKernels.LaplacianOfGaussian);

            Run2D("Kayyali", KnownEdgeDetectorKernels.Kayyali);
            Run2D("Prewitt", KnownEdgeDetectorKernels.Prewitt);
            Run2D("RobertsCross", KnownEdgeDetectorKernels.RobertsCross);
            Run2D("Scharr", KnownEdgeDetectorKernels.Scharr);
            Run2D("Sobel", KnownEdgeDetectorKernels.Sobel);

            RunCompass("Kirsch", KnownEdgeDetectorKernels.Kirsch);
            RunCompass("Robinson", KnownEdgeDetectorKernels.Robinson);

            void Run(string name, EdgeDetectorKernel kernel)
            {
                for (var sigma = 1; sigma <= 5; sigma += 2)
                {
                    for (var edgeSigma = 1; edgeSigma <= 5; edgeSigma += 2)
                    {
                        ImageProcessor
                            .StartFromSourceFile("img_car.jpg")
                            .GetCartoonified(kernel, sigma, edgeSigma)
                            .Save($"{name}_{sigma}_{edgeSigma}.png");
                    }
                }
            }

            void Run2D(string name, EdgeDetector2DKernel kernel)
            {
                for (var sigma = 1; sigma <= 5; sigma += 2)
                {
                    for (var edgeSigma = 1; edgeSigma <= 5; edgeSigma += 2)
                    {
                        ImageProcessor
                            .StartFromSourceFile("img_car.jpg")
                            .GetCartoonified(kernel, sigma, edgeSigma)
                            .Save($"{name}_{sigma}_{edgeSigma}.png");
                    }
                }
            }

            void RunCompass(string name, EdgeDetectorCompassKernel kernel)
            {
                for (var sigma = 1; sigma <= 5; sigma += 2)
                {
                    for (var edgeSigma = 1; edgeSigma <= 5; edgeSigma += 2)
                    {
                        ImageProcessor
                            .StartFromSourceFile("img_car.jpg")
                            .GetCartoonified(kernel, sigma, edgeSigma)
                            .Save($"{name}_{sigma}_{edgeSigma}.png");
                    }
                }
            }

        }
    }
}
