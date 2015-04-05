using System.Collections.Generic;
using ImageClassifier.Models;
using Image = System.Drawing.Image;

namespace ImageClassifier.ImageProcessors
{
    public abstract class ImageProcessor
    {
        public abstract int ProcessImages(List<ImageData> images, out double[][] inputs, out int[] outputs);
        public abstract double[] ProcessImages(Image ctx);
    }
}
