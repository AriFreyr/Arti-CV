using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using Accord.Imaging;
using Accord.MachineLearning;
using Accord.Math;
using Accord.Statistics.Kernels;
using CVTester.DAL;
using Newtonsoft.Json;
using CVTester.Models;

namespace CVTester
{
    class Program
    {
        const string GoogleApiKey = "AIzaSyC3E6KWp9rLiIt3mVG4CsABiZcafO7456A";
        const string SearchEngineCx = "015363661733912743555:c60m6j8qy2o";
        static void Main(string[] args)
        {
            var imageTypes = new[] {"car", "laptop", "bicycle"};
            var db = new ImageContext();
            var data = db.Image.ToList();
            data.Shuffle();
            //PopulateDatabase("macbook pro", db, "laptop");
            var imageProcessor = new ImageProcessor(new FastCornersDetector());
            double[][] inputs;
            int[] outputs;

            var sw = Stopwatch.StartNew();
            var numImages = imageProcessor.ProcessImages(data, out inputs, out outputs);
            sw.Stop();
            Console.WriteLine("Processing for: " + sw.ElapsedMilliseconds + "ms with: " + numImages + " images");

            var sw1 = Stopwatch.StartNew();
            //var knn = UseKNN(inputs, outputs);
            var svm = new SVM();
            svm.TrainSVM(new ChiSquare(), 3, inputs, outputs);
            sw1.Stop();
            Console.WriteLine("Training for: " + sw1.ElapsedMilliseconds);

            var sw2 = Stopwatch.StartNew();
            var result = svm.Classify(imageProcessor.ProcessImages(Properties.Resources.macbookari));
            sw2.Stop();
            Console.WriteLine("Classifying for " + sw2.ElapsedMilliseconds + "ms, classified as: " + result); 

            Console.Read(); 



        }

        /// <summary>
        /// Populates the database with a given search term with 50 entries
        /// </summary>
        /// <param name="searchQuery">search term</param>
        /// <param name="ctx">database context</param>
        /// <param name="type">type of item</param>
        public static void PopulateDatabase(string searchQuery, ImageContext ctx, string type)
        {
            var count = 1;
            while (ctx.Image.Count(x => x.Type == type) < 50)
            {
                var requestUrl = CreateRequest(searchQuery, count);
                var response = MakeRequest(requestUrl);
                count = response.queries.nextPage[0].count;
                foreach (var item in response.items)
                {
                    try
                    {
                        var img = Utilities.GetImageFromUrl(item.link);

                        if (img != null)
                        {
                            ctx.Image.Add(new ImageData
                            {
                                Image = Utilities.ImageToByteArray(img),
                                Link = item.link,
                                Type = type
                            });
                            ctx.SaveChanges();
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Could not reach: " + item.link + " " + e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a request string to google API with search term and page number
        /// </summary>
        /// <param name="query">search term</param>
        /// <param name="count">page index</param>
        /// <returns></returns>
        public static string CreateRequest(string query, int count)
        {
            var requestString = "https://www.googleapis.com/customsearch/v1?key="
                                + GoogleApiKey + "&cx=" + SearchEngineCx + "&q=" + query
                                + "&searchType=image" + "&start=" + count+ "&imgSize=medium";

            return requestString;
        }

        /// <summary>
        /// Makes request to google API with given request string
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static Response MakeRequest(string requestUrl)
        {
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format(
                                            "Server error (HTTP {0}: {1}).",
                                            response.StatusCode,
                                            response.StatusDescription));
                }
                var serializer = new JsonSerializer();

                Response result;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = (Response)serializer.Deserialize(reader, typeof(Response));
                }

                return result;

            }
        }

        public static void UseSVM(double[][] inputs, int[] outputs)
        {
          
            var crossValidation = new CrossValidation(inputs.Length, 10);
            crossValidation.Fitting = delegate(int k, int[] indicesTrain, int[] indicesValidation)
            {
                
                var trainingInputs = inputs.Submatrix(indicesTrain);
                var trainingOutputs = outputs.Submatrix(indicesTrain);

                // And now the validation data:
                var validationInputs = inputs.Submatrix(indicesValidation);
                var validationOutputs = outputs.Submatrix(indicesValidation);

                var sw1 = Stopwatch.StartNew();
                var svm = new SVM();
                var trainingError = svm.TrainSVM(new ChiSquare(), 3, trainingInputs, trainingOutputs);
                sw1.Stop(); 
                Console.WriteLine("Training for: " + sw1.ElapsedMilliseconds + "ms with errors: " + trainingError);

                var validationError = svm.GetSMO().ComputeError(validationInputs, validationOutputs); 

                // Return a new information structure containing the model and the errors achieved.
               return new CrossValidationValues(svm, trainingError, validationError);

            };

            // Compute the cross-validation
            var result = crossValidation.Compute();

            // Finally, access the measured performance.
            var trainingErrors = result.Training.Mean;
            var validationErrors = result.Validation.Mean;

            Console.WriteLine("Finished with " + trainingErrors + " training errors and " + validationErrors + " validation errors");
           
        }

        public static KNN UseKNN(double[][] inputs, int[] outputs)
        {
            var knn = new KNN();
            knn.TrainKNN(inputs, outputs, 4);

            return knn;
        }
    }
}
