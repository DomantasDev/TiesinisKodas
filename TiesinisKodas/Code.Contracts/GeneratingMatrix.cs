using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Contracts
{
    public class GeneratingMatrix
    {
        public BitArray[] Matrix { get; private set; }
        public int PostfixLength { get; private set; } // kodo ilgis - dimensija
        public int Dimension { get; private set; }
        public int CodeLength { get; private set; }

        public GeneratingMatrix(int codeLength, int dimension)
        {
            if (codeLength <= dimension)
                throw new ArgumentException($"{nameof(codeLength)} cant be greater than {nameof(dimension)}");

            PostfixLength = codeLength - dimension;
            Dimension = dimension;
            CodeLength = codeLength;
        }
        /**
        * sukuria generuojančią matricą su atsitiktinėmis reikšmėmis
        **/
        public void GenerateStandardFormMatrix()
        {
            int matrixSize = PostfixLength * Dimension;
            var bits = new BitArray(matrixSize);
            for (int i = 0; i < matrixSize; i++)
                bits[i] = RandomBool();
            GenerateStandardFormMatrix(bits);
        }
        /**
        * sukuria generuojančią matricą iš parametrų perduoto bitų masyvo.
        * masyve pateikiamos tik nevienetinės matricos dalies reikšmės eilutėmis
        **/
        public void GenerateStandardFormMatrix(BitArray bits)
        {
            if (bits.Count != Dimension * PostfixLength)
                throw new ArgumentException($"lenth of {nameof(bits)} must be {Dimension * PostfixLength}");
            Matrix = new BitArray[Dimension];
            for (int i = 0; i < Dimension; i++)
                Matrix[i] = new BitArray(PostfixLength);

            for (int i = 0; i < Dimension; i++)
                for (int j = 0; j < PostfixLength; j++)
                    Matrix[i][j] = bits[i * PostfixLength + j];
        }

        private Random _rand = new Random();
        private bool RandomBool()
        {
            if (_rand.Next() % 2 == 0)
                return false;
            return true;
        }
    }
}
