using Accord.Imaging;
using AForge;
using CVTester.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVTester
{
    public class KnnTester
    {
        /// <summary>
        /// Gets feature points for all images in database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<List<FastRetinaKeypoint>> GetFeaturePoints(ImageContext db)
        {
            var images = db.Image.ToList();
            var result = new List<List<FastRetinaKeypoint>>();
            var detector = new FastCornersDetector(60);
            var freak = new FastRetinaKeypointDetector(detector);

            foreach (var image in images)
            {
                using (var stream = new MemoryStream(image.Image))
                {
                    result.Add(freak.ProcessImage(new Bitmap(stream)));
                }
            }

            return result;
        }

        public static List<FastRetinaKeypoint> GetFeaturePoints(Image img)
        {
            var detector = new FastCornersDetector(60);
            var freak = new FastRetinaKeypointDetector(detector);

            return freak.ProcessImage(new Bitmap(img));
        }


        public static int NeighbourMatch(IEnumerable<List<FastRetinaKeypoint>> imageFeaturePoints, List<FastRetinaKeypoint> testImageFeaturePoints)
        {
            var knn = new KNearestNeighborMatching(5) { Threshold = 0.2 };
            var indexOfBest = 0;
            var bestValue = Double.PositiveInfinity;
            var count = 1;
            foreach (var imageFeaturePoint in imageFeaturePoints)
            {
                if (imageFeaturePoint.Count < 50)
                {
                    continue;
                }
                var match = knn.Match(imageFeaturePoint, testImageFeaturePoints);
                var value = GetMatchValue(match);

                if (value < bestValue)
                {
                    bestValue = value;
                    indexOfBest = count;
                }
                Console.WriteLine("Image Id: " + count + " Matched: " + value);
                count++;
            }


            return indexOfBest;
        }

        private static double GetMatchValue(IntPoint[][] match)
        {
            if (match[0].Length == 0)
            {
                return Double.PositiveInfinity;
            }
            // Both arrays are always the same size so its safe to check just one
            var lengthList = new List<Double>();
            for (var i = 0; i < match[0].Length; i++)
            {
                var point1 = match[0][i];
                var point2 = match[1][i];

                var euclideanLength = Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));
                lengthList.Add(euclideanLength);

            }
            var mean = lengthList.Average();

            var stdDev = lengthList.Sum(num => Math.Pow((num - mean), 2));

            stdDev = stdDev / lengthList.Count;

            return Math.Sqrt(stdDev);
        }
    }
}
