namespace ImageClassifier
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxAlgPicker = new System.Windows.Forms.ComboBox();
            this.labelClassifyingAlg = new System.Windows.Forms.Label();
            this.groupBoxClassifier = new System.Windows.Forms.GroupBox();
            this.numericUpDownKValue = new System.Windows.Forms.NumericUpDown();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.labelKValue = new System.Windows.Forms.Label();
            this.buttonClassify = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBoxImageInput = new System.Windows.Forms.TextBox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.textBoxResults = new System.Windows.Forms.TextBox();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lastImageButton = new System.Windows.Forms.ToolStripButton();
            this.nextImageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteImageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveChangesButton = new System.Windows.Forms.ToolStripButton();
            this.totalNumberOfSelectedImages = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripLabel();
            this.selectedImageIndex = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxClassifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKValue)).BeginInit();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.groupBoxResult.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAlgPicker
            // 
            this.comboBoxAlgPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAlgPicker.Enabled = false;
            this.comboBoxAlgPicker.FormattingEnabled = true;
            this.comboBoxAlgPicker.Items.AddRange(new object[] {
            "KNN",
            "SVM"});
            this.comboBoxAlgPicker.Location = new System.Drawing.Point(116, 22);
            this.comboBoxAlgPicker.Name = "comboBoxAlgPicker";
            this.comboBoxAlgPicker.Size = new System.Drawing.Size(176, 21);
            this.comboBoxAlgPicker.TabIndex = 0;
            this.comboBoxAlgPicker.SelectedIndexChanged += new System.EventHandler(this.comboBoxAlgPicker_SelectedIndexChanged);
            // 
            // labelClassifyingAlg
            // 
            this.labelClassifyingAlg.AutoSize = true;
            this.labelClassifyingAlg.Location = new System.Drawing.Point(6, 25);
            this.labelClassifyingAlg.Name = "labelClassifyingAlg";
            this.labelClassifyingAlg.Size = new System.Drawing.Size(104, 13);
            this.labelClassifyingAlg.TabIndex = 1;
            this.labelClassifyingAlg.Text = "Classifying algorithm:";
            // 
            // groupBoxClassifier
            // 
            this.groupBoxClassifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxClassifier.Controls.Add(this.numericUpDownKValue);
            this.groupBoxClassifier.Controls.Add(this.buttonTrain);
            this.groupBoxClassifier.Controls.Add(this.labelKValue);
            this.groupBoxClassifier.Controls.Add(this.buttonClassify);
            this.groupBoxClassifier.Controls.Add(this.labelClassifyingAlg);
            this.groupBoxClassifier.Controls.Add(this.comboBoxAlgPicker);
            this.groupBoxClassifier.Location = new System.Drawing.Point(6, 6);
            this.groupBoxClassifier.Name = "groupBoxClassifier";
            this.groupBoxClassifier.Size = new System.Drawing.Size(307, 505);
            this.groupBoxClassifier.TabIndex = 2;
            this.groupBoxClassifier.TabStop = false;
            this.groupBoxClassifier.Text = "Classifier";
            // 
            // numericUpDownKValue
            // 
            this.numericUpDownKValue.Enabled = false;
            this.numericUpDownKValue.Location = new System.Drawing.Point(116, 50);
            this.numericUpDownKValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKValue.Name = "numericUpDownKValue";
            this.numericUpDownKValue.ReadOnly = true;
            this.numericUpDownKValue.Size = new System.Drawing.Size(176, 20);
            this.numericUpDownKValue.TabIndex = 7;
            this.numericUpDownKValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKValue.ValueChanged += new System.EventHandler(this.numericUpDownKValue_ValueChanged);
            // 
            // buttonTrain
            // 
            this.buttonTrain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonTrain.Enabled = false;
            this.buttonTrain.Location = new System.Drawing.Point(9, 448);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(283, 23);
            this.buttonTrain.TabIndex = 5;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            // 
            // labelKValue
            // 
            this.labelKValue.AutoSize = true;
            this.labelKValue.Location = new System.Drawing.Point(64, 52);
            this.labelKValue.Name = "labelKValue";
            this.labelKValue.Size = new System.Drawing.Size(46, 13);
            this.labelKValue.TabIndex = 4;
            this.labelKValue.Text = "K value:";
            // 
            // buttonClassify
            // 
            this.buttonClassify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClassify.Enabled = false;
            this.buttonClassify.Location = new System.Drawing.Point(9, 476);
            this.buttonClassify.Name = "buttonClassify";
            this.buttonClassify.Size = new System.Drawing.Size(283, 23);
            this.buttonClassify.TabIndex = 2;
            this.buttonClassify.Text = "Classify";
            this.buttonClassify.UseVisualStyleBackColor = true;
            this.buttonClassify.Click += new System.EventHandler(this.buttonClassify_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "JPEG File (*.jpeg)|*.jpeg|PNG File (*.png)|*.png|JPG File (*.jpg)|*.jpg|GIF File " +
    "(*.gif)|*.gif";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOpen.Location = new System.Drawing.Point(6, 239);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // textBoxImageInput
            // 
            this.textBoxImageInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImageInput.Location = new System.Drawing.Point(87, 241);
            this.textBoxImageInput.Name = "textBoxImageInput";
            this.textBoxImageInput.Size = new System.Drawing.Size(533, 20);
            this.textBoxImageInput.TabIndex = 4;
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxImage.Controls.Add(this.pictureBoxImage);
            this.groupBoxImage.Controls.Add(this.buttonOpen);
            this.groupBoxImage.Controls.Add(this.textBoxImageInput);
            this.groupBoxImage.Location = new System.Drawing.Point(319, 244);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(626, 267);
            this.groupBoxImage.TabIndex = 5;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Image";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxImage.Location = new System.Drawing.Point(6, 19);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(614, 214);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // textBoxResults
            // 
            this.textBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxResults.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxResults.Location = new System.Drawing.Point(6, 19);
            this.textBoxResults.Multiline = true;
            this.textBoxResults.Name = "textBoxResults";
            this.textBoxResults.ReadOnly = true;
            this.textBoxResults.Size = new System.Drawing.Size(614, 205);
            this.textBoxResults.TabIndex = 6;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.Controls.Add(this.textBoxResults);
            this.groupBoxResult.Location = new System.Drawing.Point(319, 6);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(626, 230);
            this.groupBoxResult.TabIndex = 7;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Results";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(5, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 543);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxImage);
            this.tabPage1.Controls.Add(this.groupBoxResult);
            this.tabPage1.Controls.Add(this.groupBoxClassifier);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(951, 517);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Classify";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(951, 517);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Test";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.listView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(951, 517);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(6, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 505);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(522, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(421, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedImageIndex,
            this.toolStripSeparator3,
            this.totalNumberOfSelectedImages,
            this.lastImageButton,
            this.nextImageButton,
            this.toolStripSeparator1,
            this.deleteImageButton,
            this.toolStripSeparator2,
            this.saveChangesButton});
            this.toolStrip1.Location = new System.Drawing.Point(522, 243);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(210, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lastImageButton
            // 
            this.lastImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lastImageButton.Image = ((System.Drawing.Image)(resources.GetObject("lastImageButton.Image")));
            this.lastImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lastImageButton.Name = "lastImageButton";
            this.lastImageButton.Size = new System.Drawing.Size(23, 22);
            this.lastImageButton.Text = "toolStripButton1";
            this.lastImageButton.Click += new System.EventHandler(this.lastImageButton_Click);
            // 
            // nextImageButton
            // 
            this.nextImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextImageButton.Image = ((System.Drawing.Image)(resources.GetObject("nextImageButton.Image")));
            this.nextImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nextImageButton.Name = "nextImageButton";
            this.nextImageButton.Size = new System.Drawing.Size(23, 22);
            this.nextImageButton.Text = "toolStripButton2";
            this.nextImageButton.Click += new System.EventHandler(this.nextImageButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteImageButton
            // 
            this.deleteImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteImageButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteImageButton.Image")));
            this.deleteImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteImageButton.Name = "deleteImageButton";
            this.deleteImageButton.Size = new System.Drawing.Size(23, 22);
            this.deleteImageButton.Text = "toolStripButton1";
            this.deleteImageButton.Click += new System.EventHandler(this.deleteImageButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveChangesButton.Image = ((System.Drawing.Image)(resources.GetObject("saveChangesButton.Image")));
            this.saveChangesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(23, 22);
            this.saveChangesButton.Text = "toolStripButton1";
            // 
            // totalNumberOfSelectedImages
            // 
            this.totalNumberOfSelectedImages.Name = "totalNumberOfSelectedImages";
            this.totalNumberOfSelectedImages.Size = new System.Drawing.Size(25, 25);
            this.totalNumberOfSelectedImages.Text = "0";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(18, 22);
            this.toolStripSeparator3.Text = "of";
            // 
            // selectedImageIndex
            // 
            this.selectedImageIndex.Name = "selectedImageIndex";
            this.selectedImageIndex.Size = new System.Drawing.Size(25, 25);
            this.selectedImageIndex.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 552);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(859, 524);
            this.Name = "Form1";
            this.Text = "Image Classifier";
            this.groupBoxClassifier.ResumeLayout(false);
            this.groupBoxClassifier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKValue)).EndInit();
            this.groupBoxImage.ResumeLayout(false);
            this.groupBoxImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAlgPicker;
        private System.Windows.Forms.Label labelClassifyingAlg;
        private System.Windows.Forms.GroupBox groupBoxClassifier;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.TextBox textBoxImageInput;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TextBox textBoxResults;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.Button buttonClassify;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label labelKValue;
        private System.Windows.Forms.NumericUpDown numericUpDownKValue;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton lastImageButton;
        private System.Windows.Forms.ToolStripButton nextImageButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton deleteImageButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton saveChangesButton;
        private System.Windows.Forms.ToolStripLabel toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox totalNumberOfSelectedImages;
        private System.Windows.Forms.ToolStripTextBox selectedImageIndex;
    }
}

