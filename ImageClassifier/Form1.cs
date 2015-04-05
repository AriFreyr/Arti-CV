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

namespace ImageClassifier
{
    public partial class Form1 : Form
    {
        private enum Algorithms {KNN=1, SVM=2};
        private Algorithms selectedAlgorithm;
        private double[][] inputs;
        private int[] outputs;
        private ImageProcessor imageProcessor;
        private Image img;
        private int k = 1;


        public Form1()
        {
            InitializeComponent();
            ProcessImages(out inputs, out outputs);
        }

        private void ProcessImages(out double[][] argInputs, out int[] argOutputs)
        {
            var imageTypes = new[] { "car", "laptop", "bicycle" };
            var db = new ImageContext();
            var data = db.Image.ToList();
            data.Shuffle();
            imageProcessor = new CornerProcessor(new FastCornersDetector());
            var sw = Stopwatch.StartNew();
            var numImages = imageProcessor.ProcessImages(data, out argInputs, out argOutputs);
            sw.Stop();
            //LoadingForm.ActiveForm.Close();
        }

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
                textBoxResults.AppendText("Starting classification with kNN where k is " + k + Environment.NewLine);
                if (img == null)
                {
                    textBoxResults.AppendText("ERROR: Please choose an image first" + Environment.NewLine);
                }
                else
                {
                    var knn = new KNN();
                    string result;
                    textBoxResults.AppendText("Running training function..." + Environment.NewLine);
                    knn.TrainKNN(inputs, outputs, k);
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
            k = (int)numericUpDownKValue.Value;
        }
    }
}
