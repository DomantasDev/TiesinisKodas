using Code.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Implementation
{
    public class StraightCode : ICode
    {
        private GeneratingMatrix _matrix;
        private BitArray[] _controlMatrix = null;
        private List<MinimizedStandardTableEntry> _cosetLeaders = new List<MinimizedStandardTableEntry>();

        public StraightCode(GeneratingMatrix matrix)
        {
            _matrix = matrix;
        }

        public BitArray EncodeData(byte[] data)
        {
            var bits = new BitArray(data);
            int nrOfFullVectors = bits.Length / _matrix.Dimension;
            int remainingBits = bits.Count % _matrix.Dimension;
            BitArray result = remainingBits == 0 ? 
                new BitArray(nrOfFullVectors * _matrix.CodeLength) : 
                new BitArray((nrOfFullVectors + 1) * _matrix.CodeLength);

            for (int i = 0; i < nrOfFullVectors; i++)
            {
                var vector = new BitArray(_matrix.Dimension);
                for (int j = 0; j < _matrix.Dimension; j++)
                    vector[j] = bits[i * _matrix.Dimension + j];
                var encodedVector = EncodeVector(vector);
                for (int j = 0; j < _matrix.CodeLength; j++)
                    result[i * _matrix.CodeLength + j] = encodedVector[j];
            }            
            if (remainingBits != 0)
            {
                var vector = new BitArray(_matrix.Dimension, false);
                for (int i = 0; i < remainingBits; i++)
                    vector[i] = bits[nrOfFullVectors * _matrix.Dimension + i];
                var encodedVector = EncodeVector(vector);
                for(int i = 0; i < _matrix.CodeLength; i++)
                    result[nrOfFullVectors * _matrix.CodeLength + i] = encodedVector[i];
            }
            return result;
        }

        public BitArray EncodeVector(BitArray vector)
        {
            if (vector == null)
                throw new ArgumentNullException($"{nameof(vector)} can't be null");
            if (vector.Count % _matrix.Dimension != 0)
                return null;

            BitArray result = new BitArray(_matrix.CodeLength, false);
            for (int i = 0; i < vector.Count; i++)
                result[i] = vector[i];

            for (int i = 0; i < _matrix.PostfixLength; i++)
            {
                bool bit = false;

                for (int j = 0; j < _matrix.Dimension; j++)
                    bit ^= (vector[j] && _matrix.Matrix[j][i]);

                result[_matrix.Dimension + i] = bit;
            }

            return result;
        }

        public byte[] DecodeData(BitArray data)
        {
            var result = new BitArray(data.Length / _matrix.CodeLength * _matrix.Dimension);

            for (int i = 0; i < data.Length / _matrix.CodeLength; i++)
            {
                var encodedVector = new BitArray(_matrix.CodeLength);
                for (int j = 0; j < _matrix.CodeLength; j++)
                    encodedVector[j] = data[i * _matrix.CodeLength + j];
                var decodedVector = DecodeVector(encodedVector);
                for (int j = 0; j < _matrix.Dimension; j++)
                {
                    result[i * _matrix.Dimension + j] = decodedVector[j];
                }

            }
            return result.ToBytes();
        }     

        public BitArray DecodeVector(BitArray vector)
        {
            if (_controlMatrix == null)
                SetControlMatrix();
            if (!_cosetLeaders.Any())
                for (int i = 1; i <= _matrix.CodeLength - 1; i++)
                    SetCosetLeaders(i, new BitArray(_matrix.CodeLength, false));

            var syndrome = GetSyndrome(vector);
            int currentWeight = _cosetLeaders.First(l => CompareBits(l.Syndrome, syndrome)).Weight;
            if (currentWeight == 0)
                return RemovePostfix(vector);

            int newWeight;
            for(int i = 0; i < _matrix.CodeLength; i++)
            {
                var newVector = new BitArray(vector);
                newVector[i] = !newVector[i];
                syndrome = GetSyndrome(newVector);
                newWeight = _cosetLeaders.First(l => CompareBits(l.Syndrome, syndrome)).Weight;

                if (newWeight == 0)
                    return RemovePostfix(newVector);

                if (newWeight < currentWeight)
                {
                    currentWeight = newWeight;
                    vector = newVector;
                }
            }
            return null;
        }

        private BitArray RemovePostfix(BitArray vector)
        {
            BitArray result = new BitArray(_matrix.Dimension);
            for (int i = 0; i < _matrix.Dimension; i++)
                result[i] = vector[i];
            return result;
        }

        private void SetControlMatrix()
        {
            _controlMatrix = new BitArray[_matrix.PostfixLength];
            for (int i = 0; i < _matrix.PostfixLength; i++)
                _controlMatrix[i] = new BitArray(_matrix.Dimension);

            for (int i = 0; i < _matrix.Dimension; i++)
                for (int j = 0; j < _matrix.PostfixLength; j++)
                    _controlMatrix[j][i] = _matrix.Matrix[i][j];

            //return result;
        }

        
        private void SetCosetLeaders(int rekursions, BitArray vector)
        {
            int limit = (int)Math.Pow(2, _matrix.PostfixLength);
            for (int i = 0; i < vector.Count; i++)
            {
                var newVector = new BitArray(vector);
                newVector[i] = true;
                if (rekursions > 1)
                    SetCosetLeaders(rekursions - 1, newVector);
                else
                {
                    var syndrome = GetSyndrome(vector);
                    if (!_cosetLeaders.Any(l => CompareBits(l.Syndrome,syndrome)))
                        _cosetLeaders.Add(new MinimizedStandardTableEntry { CosetLeader = vector, Syndrome = syndrome, Weight = GetWeight(vector) });                  
                }
                if (_cosetLeaders.Count == limit)
                    break;
            }
        }

        private bool CompareBits(BitArray vector1, BitArray vector2)
        {
            if (vector1.Count != vector2.Count)
                return false;
            for (int i = 0; i < vector1.Count; i++)
                if (vector1[i] != vector2[i])
                    return false;
            return true;
        }

        private BitArray GetSyndrome(BitArray vector)
        {
            var result = new BitArray(_matrix.PostfixLength);

            for(int i = 0; i < result.Count; i++)
            {
                bool bit = false;
                for (int j = 0; j < _matrix.Dimension; j++)
                    bit ^= (_controlMatrix[i][j] && vector[j]);
                bit ^= vector[_matrix.Dimension + i];

                result[i] = bit;
            }

            return result;
        }

        private int GetWeight(BitArray vector)
        {
            int result = 0;
            foreach (bool bit in vector)
                if (bit)
                    result++;
            return result;
        }
    }
}
