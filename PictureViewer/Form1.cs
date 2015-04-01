using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cVDatabase12DataSet.ImageDatas' table. You can move, or remove it, as needed.
            this.imageDatasTableAdapter.Fill(this.cVDatabase12DataSet.ImageDatas);
        }

        private void imageDatasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.imageDatasBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.cVDatabase12DataSet);
                MessageBox.Show("Update successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed " + ex.Message);
            }

        }

    }
}
