using ImageProcessorLib.ImageProcessorExtensions;

namespace ImageProcessorLib.Utils
{
    public static class CartoonGenerator
    {
        /// <summary>
        /// Taking a file name and the name of a directory, this function generates cartoonified versions of that file,
        /// placing the resulting images in the specified directory (which is created if it does not exist). All available
        /// edge detection kernels are used. For each such version, 9 versions are generated, using values 1, 3, and 5 for
        /// imageSigma and edgeSigma. Each file is named so that the kernel used and the values for imageSigma and edgeSigma
        /// are obvious, e.g. "Kayyali_1_5.png" which uses the Kayyali kernel with imageSigma = 1 and edgeSigma = 5.
        /// </summary>
        public static void Generate(string sourceFile, string outputDirectory)
        {
            Directory.CreateDirectory(outputDirectory);

            Run("Laplacian3x3", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Laplacian3x3));
            Run("Laplacian5x5", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Laplacian5x5));
            Run("LaplacianOfGaussian", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.LaplacianOfGaussian));
            Run("Kayyali", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Kayyali));
            Run("Prewitt", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Prewitt));
            Run("RobertsCross", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.RobertsCross));
            Run("Scharr", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Scharr));
            Run("Sobel", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Sobel));
            Run("Kirsch", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Kirsch));
            Run("Robinson", ctx => ctx.DetectEdges(KnownEdgeDetectorKernels.Robinson));
            Run("no_edge_detection", null);

            ImageProcessor.StartFromSourceFile(sourceFile).Get()
                .Save($"{outputDirectory}\\original_file.png");

            void Run(string kernel, Action<IImageProcessingContext>? detectEdges)
            {
                for (var sigma = 1; sigma <= 5; sigma+=2)
                {
                    for (var edgeSigma = 1; edgeSigma <= 5; edgeSigma+=2)
                    {
                        ImageProcessor.StartFromSourceFile(sourceFile)
                            .GetCartoonified(detectEdges, sigma, edgeSigma)
                            .Save($"{outputDirectory}\\{kernel}_{sigma}_{edgeSigma}.png");
                    }
                }
            }
        }
    }
}
