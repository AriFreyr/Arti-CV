using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging;
using AForge.Imaging;
using CVTester.Models;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

namespace CVTester
{
    public class ImageProcessor
    {
        private const int NumberOfWords = 32;
        private ICornersDetector _detector;
        private BagOfVisualWords<CornerFeaturePoint> _bagOfVisualWords;

        public ImageProcessor(ICornersDetector detector)
        {
            _detector = detector;
        }

        public int ProcessImages(List<ImageData> images, out double[][] inputs, out int[] outputs)
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

        public Double[] ProcessImages(Image ctx)
        {
            return _bagOfVisualWords.GetFeatureVector(new Bitmap(ctx));
        }
    }
}
