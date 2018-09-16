namespace WindowsFormsApp
{
    partial class MainForm
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
            this._matrixGridView = new System.Windows.Forms.DataGridView();
            this._codeLengthTextBox = new System.Windows.Forms.TextBox();
            this._dimensionTextBox = new System.Windows.Forms.TextBox();
            this.CodeLengthLabel = new System.Windows.Forms.Label();
            this.DimensionLabel = new System.Windows.Forms.Label();
            this._randomizeMatrixButton = new System.Windows.Forms.Button();
            this._enterMatrixButton = new System.Windows.Forms.Button();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._vectorTabPage = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this._decodedTextBox = new System.Windows.Forms.TextBox();
            this._decodeVectorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this._fromChannelTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._encodedTextBox = new System.Windows.Forms.TextBox();
            this._encodeVectorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._vectorTextBox = new System.Windows.Forms.TextBox();
            this._stringTabPage = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this._notCodedStringTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._decodedStringTextBox = new System.Windows.Forms.TextBox();
            this._startStringButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this._inputStringTextBox = new System.Windows.Forms.TextBox();
            this._imageTabPage = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._decodeImageButton = new System.Windows.Forms.Button();
            this._notCodedImage = new System.Windows.Forms.PictureBox();
            this._codedImage = new System.Windows.Forms.PictureBox();
            this._inputImage = new System.Windows.Forms.PictureBox();
            this._selectImageButton = new System.Windows.Forms.Button();
            this._failureRateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._setMatrixButton = new System.Windows.Forms.Button();
            this._failureLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._matrixGridView)).BeginInit();
            this._tabControl.SuspendLayout();
            this._vectorTabPage.SuspendLayout();
            this._stringTabPage.SuspendLayout();
            this._imageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._notCodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._codedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._inputImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _matrixGridView
            // 
            this._matrixGridView.AllowUserToAddRows = false;
            this._matrixGridView.AllowUserToDeleteRows = false;
            this._matrixGridView.AllowUserToResizeColumns = false;
            this._matrixGridView.AllowUserToResizeRows = false;
            this._matrixGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this._matrixGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this._matrixGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._matrixGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this._matrixGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._matrixGridView.ColumnHeadersVisible = false;
            this._matrixGridView.EnableHeadersVisualStyles = false;
            this._matrixGridView.Location = new System.Drawing.Point(452, 0);
            this._matrixGridView.Name = "_matrixGridView";
            this._matrixGridView.RowHeadersVisible = false;
            this._matrixGridView.Size = new System.Drawing.Size(305, 214);
            this._matrixGridView.TabIndex = 0;
            // 
            // _codeLengthTextBox
            // 
            this._codeLengthTextBox.Location = new System.Drawing.Point(95, 58);
            this._codeLengthTextBox.Name = "_codeLengthTextBox";
            this._codeLengthTextBox.Size = new System.Drawing.Size(88, 20);
            this._codeLengthTextBox.TabIndex = 1;
            // 
            // _dimensionTextBox
            // 
            this._dimensionTextBox.Location = new System.Drawing.Point(95, 84);
            this._dimensionTextBox.Name = "_dimensionTextBox";
            this._dimensionTextBox.Size = new System.Drawing.Size(87, 20);
            this._dimensionTextBox.TabIndex = 2;
            // 
            // CodeLengthLabel
            // 
            this.CodeLengthLabel.AutoSize = true;
            this.CodeLengthLabel.Location = new System.Drawing.Point(18, 61);
            this.CodeLengthLabel.Name = "CodeLengthLabel";
            this.CodeLengthLabel.Size = new System.Drawing.Size(71, 13);
            this.CodeLengthLabel.TabIndex = 3;
            this.CodeLengthLabel.Text = "Code Length:";
            // 
            // DimensionLabel
            // 
            this.DimensionLabel.AutoSize = true;
            this.DimensionLabel.Location = new System.Drawing.Point(30, 87);
            this.DimensionLabel.Name = "DimensionLabel";
            this.DimensionLabel.Size = new System.Drawing.Size(59, 13);
            this.DimensionLabel.TabIndex = 4;
            this.DimensionLabel.Text = "Dimension:";
            // 
            // _randomizeMatrixButton
            // 
            this._randomizeMatrixButton.Location = new System.Drawing.Point(227, 58);
            this._randomizeMatrixButton.Name = "_randomizeMatrixButton";
            this._randomizeMatrixButton.Size = new System.Drawing.Size(125, 23);
            this._randomizeMatrixButton.TabIndex = 5;
            this._randomizeMatrixButton.Text = "Randomize matrix";
            this._randomizeMatrixButton.UseVisualStyleBackColor = true;
            this._randomizeMatrixButton.Click += new System.EventHandler(this._randomizeMatrixButton_Click);
            // 
            // _enterMatrixButton
            // 
            this._enterMatrixButton.Location = new System.Drawing.Point(228, 84);
            this._enterMatrixButton.Name = "_enterMatrixButton";
            this._enterMatrixButton.Size = new System.Drawing.Size(124, 20);
            this._enterMatrixButton.TabIndex = 6;
            this._enterMatrixButton.Text = "Enter matrix";
            this._enterMatrixButton.UseVisualStyleBackColor = true;
            this._enterMatrixButton.Click += new System.EventHandler(this._enterMatrixButton_Click);
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._vectorTabPage);
            this._tabControl.Controls.Add(this._stringTabPage);
            this._tabControl.Controls.Add(this._imageTabPage);
            this._tabControl.Location = new System.Drawing.Point(4, 198);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1077, 480);
            this._tabControl.TabIndex = 7;
            // 
            // _vectorTabPage
            // 
            this._vectorTabPage.Controls.Add(this._failureLabel);
            this._vectorTabPage.Controls.Add(this.label4);
            this._vectorTabPage.Controls.Add(this._decodedTextBox);
            this._vectorTabPage.Controls.Add(this._decodeVectorButton);
            this._vectorTabPage.Controls.Add(this.label3);
            this._vectorTabPage.Controls.Add(this._fromChannelTextBox);
            this._vectorTabPage.Controls.Add(this.label2);
            this._vectorTabPage.Controls.Add(this._encodedTextBox);
            this._vectorTabPage.Controls.Add(this._encodeVectorButton);
            this._vectorTabPage.Controls.Add(this.label1);
            this._vectorTabPage.Controls.Add(this._vectorTextBox);
            this._vectorTabPage.Location = new System.Drawing.Point(4, 22);
            this._vectorTabPage.Name = "_vectorTabPage";
            this._vectorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._vectorTabPage.Size = new System.Drawing.Size(1069, 454);
            this._vectorTabPage.TabIndex = 0;
            this._vectorTabPage.Text = "Vector";
            this._vectorTabPage.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Decoded vector:";
            // 
            // _decodedTextBox
            // 
            this._decodedTextBox.Location = new System.Drawing.Point(222, 246);
            this._decodedTextBox.Name = "_decodedTextBox";
            this._decodedTextBox.ReadOnly = true;
            this._decodedTextBox.Size = new System.Drawing.Size(468, 20);
            this._decodedTextBox.TabIndex = 8;
            // 
            // _decodeVectorButton
            // 
            this._decodeVectorButton.Location = new System.Drawing.Point(739, 191);
            this._decodeVectorButton.Name = "_decodeVectorButton";
            this._decodeVectorButton.Size = new System.Drawing.Size(75, 23);
            this._decodeVectorButton.TabIndex = 7;
            this._decodeVectorButton.Text = "Decode";
            this._decodeVectorButton.UseVisualStyleBackColor = true;
            this._decodeVectorButton.Click += new System.EventHandler(this._decodeButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vector from channel:";
            // 
            // _fromChannelTextBox
            // 
            this._fromChannelTextBox.Location = new System.Drawing.Point(222, 193);
            this._fromChannelTextBox.Name = "_fromChannelTextBox";
            this._fromChannelTextBox.Size = new System.Drawing.Size(468, 20);
            this._fromChannelTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "encoded vector:";
            // 
            // _encodedTextBox
            // 
            this._encodedTextBox.Location = new System.Drawing.Point(222, 121);
            this._encodedTextBox.Name = "_encodedTextBox";
            this._encodedTextBox.ReadOnly = true;
            this._encodedTextBox.Size = new System.Drawing.Size(468, 20);
            this._encodedTextBox.TabIndex = 3;
            // 
            // _encodeVectorButton
            // 
            this._encodeVectorButton.Location = new System.Drawing.Point(739, 76);
            this._encodeVectorButton.Name = "_encodeVectorButton";
            this._encodeVectorButton.Size = new System.Drawing.Size(75, 23);
            this._encodeVectorButton.TabIndex = 2;
            this._encodeVectorButton.Text = "Encode";
            this._encodeVectorButton.UseVisualStyleBackColor = true;
            this._encodeVectorButton.Click += new System.EventHandler(this._encodeVectorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input vector:";
            // 
            // _vectorTextBox
            // 
            this._vectorTextBox.Location = new System.Drawing.Point(222, 76);
            this._vectorTextBox.Name = "_vectorTextBox";
            this._vectorTextBox.Size = new System.Drawing.Size(468, 20);
            this._vectorTextBox.TabIndex = 0;
            // 
            // _stringTabPage
            // 
            this._stringTabPage.Controls.Add(this.label8);
            this._stringTabPage.Controls.Add(this._notCodedStringTextBox);
            this._stringTabPage.Controls.Add(this.label7);
            this._stringTabPage.Controls.Add(this._decodedStringTextBox);
            this._stringTabPage.Controls.Add(this._startStringButton);
            this._stringTabPage.Controls.Add(this.label6);
            this._stringTabPage.Controls.Add(this._inputStringTextBox);
            this._stringTabPage.Location = new System.Drawing.Point(4, 22);
            this._stringTabPage.Name = "_stringTabPage";
            this._stringTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._stringTabPage.Size = new System.Drawing.Size(1069, 454);
            this._stringTabPage.TabIndex = 1;
            this._stringTabPage.Text = "String";
            this._stringTabPage.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "String without encoding:";
            // 
            // _notCodedStringTextBox
            // 
            this._notCodedStringTextBox.Location = new System.Drawing.Point(208, 165);
            this._notCodedStringTextBox.Name = "_notCodedStringTextBox";
            this._notCodedStringTextBox.Size = new System.Drawing.Size(468, 20);
            this._notCodedStringTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Decoded string:";
            // 
            // _decodedStringTextBox
            // 
            this._decodedStringTextBox.Location = new System.Drawing.Point(208, 231);
            this._decodedStringTextBox.Name = "_decodedStringTextBox";
            this._decodedStringTextBox.Size = new System.Drawing.Size(468, 20);
            this._decodedStringTextBox.TabIndex = 6;
            // 
            // _startStringButton
            // 
            this._startStringButton.Location = new System.Drawing.Point(715, 97);
            this._startStringButton.Name = "_startStringButton";
            this._startStringButton.Size = new System.Drawing.Size(75, 23);
            this._startStringButton.TabIndex = 5;
            this._startStringButton.Text = "Start";
            this._startStringButton.UseVisualStyleBackColor = true;
            this._startStringButton.Click += new System.EventHandler(this._startStringButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Input string:";
            // 
            // _inputStringTextBox
            // 
            this._inputStringTextBox.Location = new System.Drawing.Point(208, 100);
            this._inputStringTextBox.Name = "_inputStringTextBox";
            this._inputStringTextBox.Size = new System.Drawing.Size(468, 20);
            this._inputStringTextBox.TabIndex = 3;
            // 
            // _imageTabPage
            // 
            this._imageTabPage.Controls.Add(this.label10);
            this._imageTabPage.Controls.Add(this.label9);
            this._imageTabPage.Controls.Add(this._decodeImageButton);
            this._imageTabPage.Controls.Add(this._notCodedImage);
            this._imageTabPage.Controls.Add(this._codedImage);
            this._imageTabPage.Controls.Add(this._inputImage);
            this._imageTabPage.Controls.Add(this._selectImageButton);
            this._imageTabPage.Location = new System.Drawing.Point(4, 22);
            this._imageTabPage.Name = "_imageTabPage";
            this._imageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._imageTabPage.Size = new System.Drawing.Size(1069, 454);
            this._imageTabPage.TabIndex = 2;
            this._imageTabPage.Text = "Image";
            this._imageTabPage.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(845, 425);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "With encoding";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(487, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Without encoding";
            // 
            // _decodeImageButton
            // 
            this._decodeImageButton.Location = new System.Drawing.Point(112, 425);
            this._decodeImageButton.Name = "_decodeImageButton";
            this._decodeImageButton.Size = new System.Drawing.Size(116, 21);
            this._decodeImageButton.TabIndex = 5;
            this._decodeImageButton.Text = "Start";
            this._decodeImageButton.UseVisualStyleBackColor = true;
            this._decodeImageButton.Click += new System.EventHandler(this._decodeImageButton_Click);
            // 
            // _notCodedImage
            // 
            this._notCodedImage.Location = new System.Drawing.Point(360, 3);
            this._notCodedImage.Name = "_notCodedImage";
            this._notCodedImage.Size = new System.Drawing.Size(350, 415);
            this._notCodedImage.TabIndex = 4;
            this._notCodedImage.TabStop = false;
            // 
            // _codedImage
            // 
            this._codedImage.Location = new System.Drawing.Point(716, 3);
            this._codedImage.Name = "_codedImage";
            this._codedImage.Size = new System.Drawing.Size(350, 415);
            this._codedImage.TabIndex = 3;
            this._codedImage.TabStop = false;
            // 
            // _inputImage
            // 
            this._inputImage.Location = new System.Drawing.Point(6, 3);
            this._inputImage.Name = "_inputImage";
            this._inputImage.Size = new System.Drawing.Size(350, 415);
            this._inputImage.TabIndex = 1;
            this._inputImage.TabStop = false;
            // 
            // _selectImageButton
            // 
            this._selectImageButton.Location = new System.Drawing.Point(6, 425);
            this._selectImageButton.Name = "_selectImageButton";
            this._selectImageButton.Size = new System.Drawing.Size(100, 23);
            this._selectImageButton.TabIndex = 0;
            this._selectImageButton.Text = "Select Image";
            this._selectImageButton.UseVisualStyleBackColor = true;
            this._selectImageButton.Click += new System.EventHandler(this._selectImageButton_Click);
            // 
            // _failureRateTextBox
            // 
            this._failureRateTextBox.Location = new System.Drawing.Point(216, 162);
            this._failureRateTextBox.Name = "_failureRateTextBox";
            this._failureRateTextBox.Size = new System.Drawing.Size(138, 20);
            this._failureRateTextBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Failure rate:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // _setMatrixButton
            // 
            this._setMatrixButton.Location = new System.Drawing.Point(856, 49);
            this._setMatrixButton.Name = "_setMatrixButton";
            this._setMatrixButton.Size = new System.Drawing.Size(106, 25);
            this._setMatrixButton.TabIndex = 12;
            this._setMatrixButton.Text = "Set matrix";
            this._setMatrixButton.UseVisualStyleBackColor = true;
            this._setMatrixButton.Visible = false;
            this._setMatrixButton.Click += new System.EventHandler(this._setMatrixButton_Click);
            // 
            // _failureLabel
            // 
            this._failureLabel.AutoSize = true;
            this._failureLabel.Location = new System.Drawing.Point(224, 170);
            this._failureLabel.Name = "_failureLabel";
            this._failureLabel.Size = new System.Drawing.Size(0, 13);
            this._failureLabel.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 680);
            this.Controls.Add(this._setMatrixButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._failureRateTextBox);
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this._enterMatrixButton);
            this.Controls.Add(this._randomizeMatrixButton);
            this.Controls.Add(this.DimensionLabel);
            this.Controls.Add(this.CodeLengthLabel);
            this.Controls.Add(this._dimensionTextBox);
            this.Controls.Add(this._codeLengthTextBox);
            this.Controls.Add(this._matrixGridView);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._matrixGridView)).EndInit();
            this._tabControl.ResumeLayout(false);
            this._vectorTabPage.ResumeLayout(false);
            this._vectorTabPage.PerformLayout();
            this._stringTabPage.ResumeLayout(false);
            this._stringTabPage.PerformLayout();
            this._imageTabPage.ResumeLayout(false);
            this._imageTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._notCodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._codedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._inputImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _matrixGridView;
        private System.Windows.Forms.TextBox _codeLengthTextBox;
        private System.Windows.Forms.TextBox _dimensionTextBox;
        private System.Windows.Forms.Label CodeLengthLabel;
        private System.Windows.Forms.Label DimensionLabel;
        private System.Windows.Forms.Button _randomizeMatrixButton;
        private System.Windows.Forms.Button _enterMatrixButton;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _vectorTabPage;
        private System.Windows.Forms.Button _encodeVectorButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _vectorTextBox;
        private System.Windows.Forms.TabPage _stringTabPage;
        private System.Windows.Forms.TabPage _imageTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _encodedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _decodedTextBox;
        private System.Windows.Forms.Button _decodeVectorButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _fromChannelTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _decodedStringTextBox;
        private System.Windows.Forms.Button _startStringButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _inputStringTextBox;
        private System.Windows.Forms.PictureBox _notCodedImage;
        private System.Windows.Forms.PictureBox _codedImage;
        private System.Windows.Forms.PictureBox _inputImage;
        private System.Windows.Forms.Button _selectImageButton;
        private System.Windows.Forms.TextBox _failureRateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button _decodeImageButton;
        private System.Windows.Forms.Button _setMatrixButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _notCodedStringTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label _failureLabel;
    }
}

