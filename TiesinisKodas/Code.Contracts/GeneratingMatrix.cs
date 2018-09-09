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
        public int PostfixLength { get; private set; }
        public int Dimension { get; private set; }
        public int CodeLength { get; private set; }

        public GeneratingMatrix(int codeLength, int dimension)
        {
            if (codeLength < dimension)
                throw new ArgumentException($"{nameof(codeLength)} cant be greater than {nameof(dimension)}");

            PostfixLength = codeLength - dimension;
            Dimension = dimension;
            CodeLength = codeLength;

            //Matrix = new BitArray[dimension];
            //for(int i = 0; i < dimension; i++)
            //    Matrix[i] = new BitArray(codeLength);

            //for (int i = 0; i < dimension; i++)
            //    for (int j = 0; j < codeLength; j++)
            //        Matrix[i][j] = RandomBool();
        }

        public void GenerateStandardFormMatrix()
        {
            Matrix = new BitArray[Dimension];
            for (int i = 0; i < Dimension; i++)
                Matrix[i] = new BitArray(PostfixLength);

            for (int i = 0; i < Dimension; i++)
                for (int j = 0; j < PostfixLength; j++)
                    Matrix[i][j] = RandomBool();
            //Matrix[0] = new BitArray(new[] {true, false });
            //Matrix[1] = new BitArray(new[] {true, true });
            //Matrix[2] = new BitArray(new[] {false, true });
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
