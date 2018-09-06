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

        public GeneratingMatrix()
        {
            //Matrix = new BitArray[dimension];
            //for(int i = 0; i < dimension; i++)
            //    Matrix[i] = new BitArray(codeLength);

            //for (int i = 0; i < dimension; i++)
            //    for (int j = 0; j < codeLength; j++)
            //        Matrix[i][j] = RandomBool();

        }

        public void GenerateNormalFormMatrix(int codeLength, int dimension)
        {
            if (codeLength < dimension)
                throw new ArgumentException($"{nameof(codeLength)} cant be greater than {nameof(dimension)}");
            Matrix = new BitArray[dimension];
            for (int i = 0; i < dimension; i++)
                Matrix[i] = new BitArray(codeLength);

            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < codeLength; j++)
                    Matrix[i][j] = RandomBool();
        }

        private bool RandomBool()
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
                return false;
            return true;
        }
    }
}
