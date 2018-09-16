using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code.Contracts;
using System.Collections;
using Code.Implementation;

namespace WindowsFormsApp
{
    public partial class MainForm : Form
    {
        GeneratingMatrix _generatingMatrix;
        ICode _code;
        IChannel _channel = new Channel();
        string _fileName = null;
        public MainForm()
        {
            InitializeComponent();
            openFileDialog.Filter = "bmp files (*.bmp)|*.bmp";
            _inputImage.SizeMode = PictureBoxSizeMode.StretchImage;
            _notCodedImage.SizeMode = PictureBoxSizeMode.StretchImage;
            _codedImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void _selectImageButton_Click(object sender, EventArgs e)
        {           
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _fileName = openFileDialog.FileName;
                var image = new Bitmap(_fileName);
                _inputImage.Image = image;
            }
        }

        private void _decodeImageButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(_fileName) && 
                _generatingMatrix != null &&
                double.TryParse(_failureRateTextBox.Text, out var failureRate))
            {
                var bytes = File.ReadAllBytes(_fileName);
                var header = bytes.Take(34);
                var imageWithoutHeader = bytes.Skip(34).ToArray();
                var encoded = _code.EncodeData(imageWithoutHeader);
                var fromChannel = _channel.Send(encoded, failureRate);
                var decoded = _code.DecodeData(fromChannel);
                var decodedImage = new MemoryStream( header.Concat(decoded).ToArray());
                _codedImage.Image = new Bitmap(decodedImage);

                var notCodedImage = new MemoryStream(header.Concat(_channel.Send(imageWithoutHeader, failureRate)).ToArray());
                _notCodedImage.Image = new Bitmap(notCodedImage);
            }
        }

        private void _randomizeMatrixButton_Click(object sender, EventArgs e)
        {
            if (TryGetMatrixSize(out var codeLength, out var dimension))
            {
                _generatingMatrix = new GeneratingMatrix(codeLength, dimension);
                _setMatrixButton.Visible = false;
                _matrixGridView.ColumnCount = _generatingMatrix.PostfixLength;
                _matrixGridView.RowCount = dimension;
                _generatingMatrix.GenerateStandardFormMatrix();
                for (int i = 0; i < _generatingMatrix.Dimension; i++)
                    for (int j = 0; j < _generatingMatrix.PostfixLength; j++)
                        _matrixGridView.Rows[i].Cells[j].Value = _generatingMatrix.Matrix[i][j].ToText();
                _code = new StraightCode(_generatingMatrix);
            }
        }

        private void _enterMatrixButton_Click(object sender, EventArgs e)
        {
            if(TryGetMatrixSize(out var codeLength, out var dimension))
            {
                _generatingMatrix = new GeneratingMatrix(codeLength, dimension);
                _setMatrixButton.Visible = true;
                _matrixGridView.ColumnCount = _generatingMatrix.PostfixLength;
                _matrixGridView.RowCount = dimension;
            }
        }

        private void _setMatrixButton_Click(object sender, EventArgs e)
        {
            var rows = _matrixGridView.Rows;
            var bits = new BitArray(_generatingMatrix.PostfixLength * _generatingMatrix.Dimension);
            for (int i = 0; i < _generatingMatrix.Dimension; i++)
                for (int j = 0; j < _generatingMatrix.PostfixLength; j++)
                    if (TryGetBit(rows[i].Cells[j].Value.ToString()[0], out var bit))
                        bits[i * _generatingMatrix.PostfixLength + j] = bit;
                    else
                        return;
            _setMatrixButton.Visible = false;
            _generatingMatrix.GenerateStandardFormMatrix(bits);
            _code = new StraightCode(_generatingMatrix);
        }

        private bool TryGetMatrixSize(out int codeLength, out int dimension)
        {
            if (int.TryParse(_codeLengthTextBox.Text, out codeLength) & int.TryParse(_dimensionTextBox.Text, out dimension))
                return true;
            return false;
        }

        private bool TryGetBit(char bit, out bool result)
        {
            switch(bit)
            {
                case '0':
                    result = false;
                    return true;
                case '1':
                    result = true;
                    return true;
                default:
                    result = false;
                    return false;
            }

        }

        private bool TryGetBits(string bits, out BitArray result)
        {
            result = new BitArray(bits.Length);
            for (int i = 0; i < bits.Length; i++)
            {
                if (TryGetBit(bits[i], out var bit))
                    result[i] = bit;
                else
                {
                    result = null;
                    return false;
                }
            }
            return true;
        }

        private void _encodeVectorButton_Click(object sender, EventArgs e)
        {
            string input = _vectorTextBox.Text;
            if (!string.IsNullOrWhiteSpace(input) && 
                double.TryParse(_failureRateTextBox.Text, out var failureRate) &&
                _generatingMatrix.Matrix != null &&
                input.Length == _generatingMatrix.Dimension && 
                TryGetBits(input, out var vector))
            {
                var encodedVector = _code.EncodeVector(vector);
                _encodedTextBox.Text =  encodedVector.ToText();
                _fromChannelTextBox.Text = _channel.Send(encodedVector, failureRate, out var failures).ToText();
                string failurePositions = null;
                failures.ForEach(f => failurePositions += f + ", ");
                _failureLabel.Text = $"failures: {failures.Count}. In positions: {failurePositions}";
            }
        }

        private void _decodeButton_Click(object sender, EventArgs e)
        {
            string input = _fromChannelTextBox.Text;
            if (!string.IsNullOrWhiteSpace(input) && input.Length == _generatingMatrix.CodeLength && TryGetBits(input, out var vector))
                _decodedTextBox.Text = _code.DecodeVector(vector).ToText();
        }

        private void _startStringButton_Click(object sender, EventArgs e)
        {
            string text = _inputStringTextBox.Text;
            if (!string.IsNullOrWhiteSpace(text) && 
                _generatingMatrix.Matrix != null && 
                double.TryParse(_failureRateTextBox.Text, out var failureRate))
            {
                var input = Encoding.ASCII.GetBytes(text);
                var encodedVector = _code.EncodeData(input);
                var encodedFromChannel = _channel.Send(encodedVector, failureRate);             
                var decoded = _code.DecodeData(encodedFromChannel);
                _decodedStringTextBox.Text = Encoding.ASCII.GetString(decoded);

                var notCoded = _channel.Send(input, failureRate);
                _notCodedStringTextBox.Text = Encoding.ASCII.GetString(notCoded);
            }
        }
    }
}
