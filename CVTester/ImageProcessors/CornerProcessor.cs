using System;
using System.Collections.Generic;
using Accord.Imaging;
using AForge.Imaging;
using CVTester.Models;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

namespace CVTester.ImageProcessors
{
    public class CornerProcessor : ImageProcessor
    {
        private const int NumberOfWords = 64;

        private readonly ICornersDetector _detector;
        private BagOfVisualWords<CornerFeaturePoint> _bagOfVisualWords;

        public CornerProcessor(ICornersDetector detector)
        {
            _detector = detector;
        }

        public override int ProcessImages(List<ImageData> images, out double[][] inputs, out int[] outputs)
        {
            outputs = new int[images.Count];
            inputs = new double[images.Count][];

            var imageData = new List<Bitmap>();

            foreach (var image in images)
            {
                using (var stream = new MemoryStream(image.Image))
                {
                    imageData.Add(new Bitmap(stream));
                }
            }

            var converter = new CornerFeaturesDetector(_detector);

            _bagOfVisualWords = new BagOfVisualWords<CornerFeaturePoint>(converter, NumberOfWords);

            _bagOfVisualWords.Compute(imageData.ToArray());

            for (var i = 0; i < images.Count; i++)
            {
                inputs[i] = _bagOfVisualWords.GetFeatureVector(imageData[i]);
                outputs[i] = Utilities.GetIntFromClass(images[i].Type);
            }

            return images.Count;
        }

        public override Double[] ProcessImages(Image ctx)
        {
            return _bagOfVisualWords.GetFeatureVector(new Bitmap(ctx));
        }
    }
}
