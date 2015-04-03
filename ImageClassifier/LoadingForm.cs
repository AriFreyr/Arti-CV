using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageClassifier
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        public void StartProgressBar(string label, int size)
        {
            label1.Text = label;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = size;
        }

        public void IncrementProgressBar()
        {
            progressBar1.Increment(1);
        }

        public void StopProgressBar()
        {
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

    }
}
