using Accord.Imaging;
using Accord.Statistics.Kernels;
using ImageClassifier.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageClassifier.ImageProcessors;
using Image = System.Drawing.Image;
using Accord.MachineLearning;
using Accord.Math;
using AForge.Imaging;
using ImageClassifier.Models;
using System.Net;
using Newtonsoft.Json;

namespace ImageClassifier
{
    public partial class Form1 : Form
    {

        const string GoogleApiKey = "AIzaSyC3E6KWp9rLiIt3mVG4CsABiZcafO7456A";
        const string SearchEngineCx = "015363661733912743555:c60m6j8qy2o";
        private enum Algorithms { KNN = 1, SVM = 2 };
        private enum CornerDetector { FAST = 1, SURF = 2, HCD = 3 };
        private enum imageTypes { car = 1, laptop = 2, bicycle = 3 };

        private Algorithms selectedAlgorithm;
        private CornerDetector selectedCornerDetector;
        private imageTypes selectedCategory;
        private double[][] inputs;
        private int[] outputs;
        private ImageProcessor imageProcessor;
        private Image img;
        private int testK = 1;
        private int classK = 1;
        private ImageContext db = new ImageContext();
        private List<Bitmap> imageData;
        private int KNNCVFolds = 10;
        private int SVMCVFolds = 10;
        private double RatQuadConst = 1.0000;
        private double GaussSigma = 1.0000;
        private int PolyDegree = 1;
        private double PolyConst = 1.0000;

        public Form1()
        {
            InitializeComponent();
            imageData = convertImagesFromDatabaseToBitmapType(db);
        }

        #region Utility functions
        private void ProcessImages(out double[][] argInputs, out int[] argOutputs)
        {
            db = new ImageContext();
            var data = db.Image.ToList();
            data.Shuffle();
            imageProcessor = new CornerProcessor(getCornerDetector());
            var sw = Stopwatch.StartNew();
            var numImages = imageProcessor.ProcessImages(data, out argInputs, out argOutputs);
            sw.Stop();
            tabControl1.Enabled = true;
            Console.WriteLine();
            //LoadingForm.ActiveForm.Close();
        }

        /// <summary>
        /// Populates the database with a given search term with 50 entries
        /// </summary>
        /// <param name="searchQuery">search term</param>
        /// <param name="ctx">database context</param>
        /// <param name="type">type of item</param>
        public void PopulateDatabase(string searchQuery, ImageContext ctx, string type, int numberOfImages)
        {
            var beginCount = ctx.Image.Count(x => x.Type == type);
            var count = 1;
            var imagesLeft = 0;
            LoadingForm lf = new LoadingForm();
            lf.StartProgressBar("Downloading images", numberOfImages+11);
            lf.Show();
            lf.Refresh();
            while (imagesLeft < numberOfImages)
            {
                var requestUrl = CreateRequest(searchQuery, count);
                var response = MakeRequest(requestUrl);
                count += response.queries.nextPage[0].count;
                Console.WriteLine(count);
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
                imagesLeft = (ctx.Image.Count(x => x.Type == type) - beginCount);
                lf.SetProgressBar(imagesLeft);
                lf.Refresh();
            }
            lf.Close();
            getAllImagesFromDatabaseToListView(listView1);
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
                                + "&searchType=image" + "&start=" + count + "&imgSize=medium";

            return requestString;
        }

        /// <summary>
        /// Makes request to google API with given request string
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        public static Response MakeRequest(string requestUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestUrl);
            using (var response = (HttpWebResponse)request.GetResponse())
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


        private ICornersDetector getCornerDetector()
        {
            if (selectedCornerDetector.Equals(CornerDetector.FAST))
            {
                return new FastCornersDetector();
            }
            else if (selectedCornerDetector.Equals(CornerDetector.SURF))
            {
                return new SpeededUpRobustFeaturesDetector();
            }
            else if (selectedCornerDetector.Equals(CornerDetector.HCD))
            {
                return new HarrisCornersDetector();
            }

            throw new Exception();
        }

        private void getAllImagesFromDatabaseToListView(ListView listview)
        {
            listView1.Clear();
            imageData = convertImagesFromDatabaseToBitmapType(db);
            imageList1.ImageSize = new Size(64, 64);
            listview.View = View.LargeIcon;

            foreach (var image in imageData)
            {
                imageList1.Images.Add(image);
            }

            listview.LargeImageList = imageList1;

            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listview.Items.Add(item);
            }

        }

        /// <summary>
        /// Converts all bit array images from the database to Bitmap type
        /// </summary>
        /// <param name="db">The database image context</param>
        /// <returns>The list of all the converted images</returns>
        private List<Bitmap> convertImagesFromDatabaseToBitmapType(ImageContext db)
        {
            var images = db.Image.ToList();
            var imageData = new List<Bitmap>();


            foreach (var image in images)
            {
                using (var stream = new MemoryStream(image.Image))
                {
                    imageData.Add(new Bitmap(stream));
                }
            }

            return imageData;
        }
        #endregion

        #region Testing Functions
        public void TestKNN(double[][] inputs, int[] outputs, int kValue)
        {
            var crossValidation = new CrossValidation(inputs.Length, KNNCVFolds);
            crossValidation.Fitting = delegate(int k, int[] indicesTrain, int[] indicesValidation)
            {
                var trainingInputs = inputs.Submatrix(indicesTrain);
                var trainingOutputs = outputs.Submatrix(indicesTrain);

                // And now the validation data:
                var validationInputs = inputs.Submatrix(indicesValidation);
                var validationOutputs = outputs.Submatrix(indicesValidation);

                var sw = Stopwatch.StartNew();
                var knn = new KNN();
                knn.TrainKNN(trainingInputs, trainingOutputs, kValue);
                sw.Stop();

                //addToTestResultBox("Training for: " + sw.ElapsedMilliseconds + "ms");

                var error = knn.ComputeError(validationInputs, validationOutputs);

                return new CrossValidationValues(knn, 0, error);

            };

            // Compute the cross-validation
            var result = crossValidation.Compute();

            // Finally, access the measured performance.
            var trainingErrors = result.Training.Mean;
            var validationErrors = result.Validation.Mean;

            textBoxTestResults.AppendText("Finished with " + trainingErrors + " training errors and " + validationErrors + " validation errors" + Environment.NewLine);
        }

        public void TestSVM(double[][] inputs, int[] outputs)
        {

            var crossValidation = new CrossValidation(inputs.Length, SVMCVFolds);
            crossValidation.Fitting = delegate(int k, int[] indicesTrain, int[] indicesValidation)
            {

                var trainingInputs = inputs.Submatrix(indicesTrain);
                var trainingOutputs = outputs.Submatrix(indicesTrain);

                // And now the validation data:
                var validationInputs = inputs.Submatrix(indicesValidation);
                var validationOutputs = outputs.Submatrix(indicesValidation);

                var sw1 = Stopwatch.StartNew();
                var svm = new SVM();
                var trainingError = svm.TrainSVM(getKernel(), 3, trainingInputs, trainingOutputs);
                sw1.Stop();

                //textBoxTestResults.AppendText("Training for: " + sw1.ElapsedMilliseconds + "ms with errors: " + trainingError + Environment.NewLine);

                var validationError = svm.GetSMO().ComputeError(validationInputs, validationOutputs);

                // Return a new information structure containing the model and the errors achieved.
                return new CrossValidationValues(svm, trainingError, validationError);

            };

            // Compute the cross-validation
            var result = crossValidation.Compute();

            // Finally, access the measured performance.
            var trainingErrors = result.Training.Mean;
            var validationErrors = result.Validation.Mean;

            addToTestResultBox("Finished with " + trainingErrors + " training errors and " + validationErrors + " validation errors");
        }

        private IKernel getKernel()
        {
            if (radioButtonRatQuad.Checked)
            {
                return new RationalQuadratic(RatQuadConst);
            }
            else if (radioButtonPoly.Checked)
            {
                return new Polynomial(PolyDegree, PolyConst);
            }
            else if (radioButtonGauss.Checked)
            {
                return new Gaussian(GaussSigma);
            }
            else if (radioButtonChi.Checked)
            {
                return new ChiSquare();
            }

            throw new Exception();

        }

        private void addToTestResultBox(string result)
        {
            textBoxTestResults.AppendText(result + Environment.NewLine);
        }

        #endregion

        #region UI element function
        private void comboBoxAlgPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAlgPicker.SelectedIndex == 0)
            {
                selectedAlgorithm = Algorithms.KNN;
                buttonClassify.Enabled = true;
                numericUpDownKValue.Enabled = true;
            }
            else if (comboBoxAlgPicker.SelectedIndex == 1)
            {
                selectedAlgorithm = Algorithms.SVM;
                buttonClassify.Enabled = true;
                numericUpDownKValue.Enabled = false;
            }
        }

        private void buttonClassify_Click(object sender, EventArgs e)
        {
            if (selectedAlgorithm.Equals(Algorithms.KNN))
            {
                textBoxResults.AppendText("Starting classification with kNN where k is " + classK + Environment.NewLine);
                if (img == null)
                {
                    textBoxResults.AppendText("ERROR: Please choose an image first" + Environment.NewLine);
                }
                else
                {
                    var knn = new KNN();
                    string result;
                    textBoxResults.AppendText("Running training function..." + Environment.NewLine);
                    knn.TrainKNN(inputs, outputs, classK);
                    result = knn.Classify(imageProcessor.ProcessImages(img));
                    textBoxResults.AppendText("Result: " + result + Environment.NewLine);
                }
            }
            else if (selectedAlgorithm.Equals(Algorithms.SVM))
            {
                textBoxResults.AppendText("Starting classification with SVM" + Environment.NewLine);
                if (img == null)
                {
                    textBoxResults.AppendText("ERROR: Please choose an image first" + Environment.NewLine);
                }
                else
                {
                    var svm = new SVM();
                    string result;
                    textBoxResults.AppendText("Running training function..." + Environment.NewLine);
                    svm.TrainSVM(new RationalQuadratic(1), 3, inputs, outputs);
                    result = svm.Classify(imageProcessor.ProcessImages(img));
                    textBoxResults.AppendText("Result: " + result + Environment.NewLine);
                }

            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var path = openFileDialog1.FileName;
            textBoxImageInput.Text = path;

            try
            {
                img = Image.FromFile(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                pictureBoxImage.Image = img;
                comboBoxAlgPicker.Enabled = true;
            }
        }

        private void numericUpDownKValue_ValueChanged(object sender, EventArgs e)
        {
            classK = (int)numericUpDownKValue.Value;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(2))
            {
                getAllImagesFromDatabaseToListView(listView1);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndexes = listView1.SelectedIndices;
            if (selectedIndexes.Count != 0)
            {
                List<Image> images = new List<Image>();
                foreach (var item in selectedIndexes)
                {
                    images.Add(imageList1.Images[(int)item]);
                }
                pictureBox1.Image = images[0];
            }
        }

        private void buttonRunTestKNN_Click(object sender, EventArgs e)
        {
            TestKNN(inputs, outputs, testK);
        }

        #endregion

        private void buttonBagOfWords_Click(object sender, EventArgs e)
        {
            ProcessImages(out inputs, out outputs);
        }

        private void buttonRunTestSVM_Click(object sender, EventArgs e)
        {
            TestSVM(inputs, outputs);
        }

        private void numericUpDownTesterKValueTester_ValueChanged(object sender, EventArgs e)
        {
            testK = (int)numericUpDownKValue.Value;
        }

        private void numericUpDownCVFoldsKNN_ValueChanged(object sender, EventArgs e)
        {
            KNNCVFolds = (int)numericUpDownCVFoldsKNN.Value;
        }

        private void numericUpDownRatQuadConst_ValueChanged(object sender, EventArgs e)
        {
            RatQuadConst = (double)numericUpDownRatQuadConst.Value;
        }

        private void numericUpDownGaussSigma_ValueChanged(object sender, EventArgs e)
        {
            GaussSigma = (double)numericUpDownGaussSigma.Value;
        }

        private void numericUpDownPolyDegree_ValueChanged(object sender, EventArgs e)
        {
            PolyDegree = (int)numericUpDownPolyDegree.Value;
        }

        private void numericUpDownPolyConst_ValueChanged(object sender, EventArgs e)
        {
            PolyConst = (double)numericUpDownPolyConst.Value;
        }

        private void comboBoxCornerDetector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCornerDetector.SelectedIndex.Equals(0))
            {
                selectedCornerDetector = CornerDetector.FAST;
            }
            else if (comboBoxCornerDetector.SelectedIndex.Equals(1))
            {
                selectedCornerDetector = CornerDetector.SURF;
            }
            else if (comboBoxCornerDetector.SelectedIndex.Equals(2))
            {
                selectedCornerDetector = CornerDetector.HCD;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchQuery = textBox1.Text;
            PopulateDatabase(searchQuery, db, selectedCategory.ToString(), (int)numericUpDownNumberOfImages.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.Equals(0))
            {
                selectedCategory = imageTypes.car;
            }
            else if (comboBox1.SelectedIndex.Equals(1))
            {
                selectedCategory = imageTypes.laptop;
            }
            else if (comboBox1.SelectedIndex.Equals(2))
            {
                selectedCategory = imageTypes.bicycle;
            }
        }

        private void lastImageButton_Click(object sender, EventArgs e)
        {

        }
    }
}
