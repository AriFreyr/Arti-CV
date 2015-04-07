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
using ImageClassifier.Models;

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
        private ImageContext db = new ImageContext();
        private List<Bitmap> imageData;
        private Boolean databaseChanged = false;
        private List<Image> selectedImages;
        private List<ImageData> imagesToBeDeleted;

        public Form1()
        {
            InitializeComponent();
            imageData = convertImagesFromDatabaseToBitmapType(db);
            //ProcessImages(out inputs, out outputs);
        }

        #region Utility functions
        private void ProcessImages(out double[][] argInputs, out int[] argOutputs)
        {
            var imageTypes = new[] { "car", "laptop", "bicycle" };
            db = new ImageContext();
            var data = db.Image.ToList();
            data.Shuffle();
            imageProcessor = new CornerProcessor(new FastCornersDetector());
            var sw = Stopwatch.StartNew();
            var numImages = imageProcessor.ProcessImages(data, out argInputs, out argOutputs);
            sw.Stop();
            //LoadingForm.ActiveForm.Close();
        }

        private void getAllImagesFromDatabaseToListView()
        {
            listView1.Clear();
            imageList1.ImageSize = new Size(64, 64);
            listView1.View = View.LargeIcon;

            foreach (var image in imageData)
            {
                imageList1.Images.Add(image);
            }

            listView1.LargeImageList = imageList1;

            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                this.listView1.Items.Add(item);
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
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex.Equals(2))
            {
                getAllImagesFromDatabaseToListView();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndexes = listView1.SelectedIndices;
            if (selectedIndexes.Count != 0)
            {
                selectedImages = new List<Image>();
                foreach (var item in selectedIndexes)
                {
                    selectedImages.Add(imageList1.Images[(int)item]);
                }
                pictureBox1.Image = selectedImages[0];
                totalNumberOfSelectedImages.Text = selectedIndexes.Count.ToString();
                selectedImageIndex.Text = "1";
            }
        }

        #endregion

        private void lastImageButton_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(selectedImageIndex.Text);

            if (!index.Equals(1))
            {
                pictureBox1.Image = selectedImages[--index - 1];
                selectedImageIndex.Text = index.ToString();
            }
        }

        private void nextImageButton_Click(object sender, EventArgs e)
        {
            int index = Int32.Parse(selectedImageIndex.Text);
            int indexEnd = listView1.SelectedIndices.Count;

            if (!index.Equals(indexEnd))
            {
                pictureBox1.Image = selectedImages[++index - 1];
                selectedImageIndex.Text = index.ToString();
            }
        }

        private void deleteImageButton_Click(object sender, EventArgs e)
        {
            var selectedIndices = listView1.SelectedIndices;

            foreach (var item in selectedIndices)
            {
                var image = from img in db.Image
                            where img.ID == (int)item
                            select img;
                foreach (var im in image)
                {
                    imagesToBeDeleted.Add(im);
                }
            }
        }
    }
}
