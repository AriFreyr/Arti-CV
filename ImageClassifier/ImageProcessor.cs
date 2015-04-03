using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging;
using AForge.Imaging;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;
using ImageClassifier.Models;
using System.Windows.Forms;

namespace ImageClassifier
{
    public class ImageProcessor
    {
        private const int NumberOfWords = 32;
        private ICornersDetector _detector;
        private BagOfVisualWords<CornerFeaturePoint> _bagOfVisualWords;
        public static LoadingForm mainForm;

        public ImageProcessor(ICornersDetector detector, LoadingForm form)
        {
            mainForm = form;
            _detector = detector;
        }

        public ImageProcessor(ICornersDetector detector)
        {
            _detector = detector;
        }

        public int ProcessImages(List<ImageData> images, out double[][] inputs, out int[] outputs)
        {
            outputs = new int[images.Count];
            inputs = new double[images.Count][];

            var imageData = new List<Bitmap>();
            mainForm.StartProgressBar("Loading images from database", images.Count);
            mainForm.Show();
            foreach (var image in images)
            {
                using (var stream = new MemoryStream(image.Image))
                {
                    imageData.Add(new Bitmap(stream));
                }
                mainForm.IncrementProgressBar();
                mainForm.Update();
            }
            mainForm.Hide();

            var converter = new CornerFeaturesDetector(_detector);

            _bagOfVisualWords = new BagOfVisualWords<CornerFeaturePoint>(converter, NumberOfWords);

            mainForm.StartProgressBar("Getting bag of visual words...", imageData.Count);
            mainForm.StopProgressBar();
            mainForm.Show();
            mainForm.Update();

            _bagOfVisualWords.Compute(imageData.ToArray());
            mainForm.Hide();

            mainForm.StopProgressBar();
            mainForm.StartProgressBar("Processing feature points", images.Count);
            mainForm.Show();
            mainForm.Update();
            for (var i = 0; i < images.Count; i++)
            {
                inputs[i] = _bagOfVisualWords.GetFeatureVector(imageData[i]);
                outputs[i] = Utilities.GetIntFromClass(images[i].Type);
                mainForm.IncrementProgressBar();
                mainForm.Update();
            }

            return images.Count;
        }

        public Double[] ProcessImages(Image ctx)
        {   
            return _bagOfVisualWords.GetFeatureVector(new Bitmap(ctx));
        }
    }
}
