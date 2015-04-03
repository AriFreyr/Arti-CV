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
            this.groupBoxClassifier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKValue)).BeginInit();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.groupBoxResult.SuspendLayout();
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
            this.groupBoxClassifier.Location = new System.Drawing.Point(12, 12);
            this.groupBoxClassifier.Name = "groupBoxClassifier";
            this.groupBoxClassifier.Size = new System.Drawing.Size(307, 468);
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
            this.buttonTrain.Location = new System.Drawing.Point(9, 411);
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
            this.buttonClassify.Location = new System.Drawing.Point(9, 439);
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
            this.buttonOpen.Location = new System.Drawing.Point(6, 157);
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
            this.textBoxImageInput.Location = new System.Drawing.Point(87, 159);
            this.textBoxImageInput.Name = "textBoxImageInput";
            this.textBoxImageInput.Size = new System.Drawing.Size(413, 20);
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
            this.groupBoxImage.Location = new System.Drawing.Point(325, 295);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(506, 185);
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
            this.pictureBoxImage.Size = new System.Drawing.Size(494, 132);
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
            this.textBoxResults.Size = new System.Drawing.Size(494, 252);
            this.textBoxResults.TabIndex = 6;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResult.Controls.Add(this.textBoxResults);
            this.groupBoxResult.Location = new System.Drawing.Point(325, 12);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(506, 277);
            this.groupBoxResult.TabIndex = 7;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 485);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxClassifier);
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
    }
}

