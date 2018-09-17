using Code.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Implementation
{
    /**
    * Tiesinio kodo realizacija
    **/
    public class LinearCode : ICode
    {
        private GeneratingMatrix _matrix;
        private BitArray[] _controlMatrix = null;
        private List<MinimizedStandardTableEntry> _cosetLeaders = new List<MinimizedStandardTableEntry>();

        public LinearCode(GeneratingMatrix matrix)
        {
            _matrix = matrix;
        }

        /**
         * Užkoduoją parametru perduotą baitų masyvą ir jį grąžiną
         **/
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
                /**
                 * suskaido baitų masyvą į kodo dimensijos ilgio vektorius
                 **/
                var vector = new BitArray(_matrix.Dimension);
                for (int j = 0; j < _matrix.Dimension; j++)
                    vector[j] = bits[i * _matrix.Dimension + j];
                /**
                 * kiekvieną vektorių užkoduoją ir pridedą jį prie galutinio bitų masyvo
                 **/
                var encodedVector = EncodeVector(vector);
                for (int j = 0; j < _matrix.CodeLength; j++)
                    result[i * _matrix.CodeLength + j] = encodedVector[j];
            }
            /**
             * jeigu pramametru perduoto baitų masyvo ilgis bitais nėra kodo dimensijos ilgio kartotinis,
             * prie gale likusių bitų yra pridedama tiek 0, kad susidarytų kodo dimensijos ilgio vektorius,
             * šis vektorius užkoduojamas ir pridedamas prie galutinio bitų masyvo
             **/
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

        /**
         * Užkoduoją parametru perduotą bitų masyvą ir jį grąžina. 
         * Parametru perduodamas bitų masyvas turi būti tokio pat ilgio kaip kodo dimensijos ilgis
         **/
        public BitArray EncodeVector(BitArray vector)
        {
            if (vector == null)
                throw new ArgumentNullException($"{nameof(vector)} can't be null");
            if (vector.Count != _matrix.Dimension)
                throw new ArgumentException($"{nameof(vector)} length must be {_matrix.Dimension}, but was {vector.Count}");

            BitArray result = new BitArray(_matrix.CodeLength, false);
            for (int i = 0; i < vector.Count; i++)
                result[i] = vector[i];
            /**
             * Parametru perduotas bitų masyvas dauginamas su generuojančia matrica
             **/
            for (int i = 0; i < _matrix.PostfixLength; i++) 
            {
                bool bit = false;

                for (int j = 0; j < _matrix.Dimension; j++)
                    bit ^= (vector[j] && _matrix.Matrix[j][i]);

                result[_matrix.Dimension + i] = bit;
            }

            return result;
        }
        /**
         * Grandinionio(step-by-step) dekodavimo algoritmo realizaciją
         * Parametrų perduoto bitų masyvo ilgis turi būti lygus kodo ilgiui
         **/
        public BitArray DecodeVector(BitArray vector)
        {
            if (vector.Count != _matrix.CodeLength)
                throw new ArgumentException($"{nameof(vector)} length must be {_matrix.CodeLength}, but was {vector.Count}");
            if (_controlMatrix == null) // jei kontrolinė matrica dar nesukurta, ją sukuriam
                SetControlMatrix();
            if (!_cosetLeaders.Any())   // jei dar nėra sudarytą lentelė su klasiu sindromais ir svoriais, ją sudarome
            {
                _cosetLeaders.Add(new MinimizedStandardTableEntry {Syndrome = new BitArray(_matrix.PostfixLength), Weight = 0 });
                for (int i = 1; i <= _matrix.CodeLength - 1; i++)
                    SetCosetLeaders(i, new BitArray(_matrix.CodeLength, false));
            }

            var syndrome = GetSyndrome(vector);
            int currentWeight = _cosetLeaders.First(l => CompareBits(l.Syndrome, syndrome)).Weight;
            if (currentWeight == 0)
                return RemovePostfix(vector);

            /**
             * 
             **/
            int newWeight;
            for (int i = 0; i < _matrix.CodeLength; i++) // bitai iš kairės į dešinę po vieną invertuojami
            {
                var newVector = new BitArray(vector);
                newVector[i] = !newVector[i];       //vieno bito invertavimas
                syndrome = GetSyndrome(newVector);  //randam naują sindromą
                newWeight = _cosetLeaders.First(l => CompareBits(l.Syndrome, syndrome)).Weight;//randam naują sindromą atitinkantį svorį

                if (newWeight == 0)
                    return RemovePostfix(newVector);

                if (newWeight < currentWeight) // jei naujas svoris mažesnis už buvusį, toliau tęsime su newVector
                {
                    currentWeight = newWeight;
                    vector = newVector;
                }
            }
            return null;
        }
        /**
         * Grandinionio(step-by-step) dekodavimo algoritmu dekoduojami duomenys.
         * duomenys grąžinami baitų masyvo pavidalu. 
         * jei dekoduoto bitų masyvo ilgis nėra 8 kartotinis, paskutiniai bitai yra ignoruojami
         **/
        public byte[] DecodeData(BitArray data)
        {
            int nrOfWords = data.Length / _matrix.CodeLength;
            var result = new BitArray(nrOfWords * _matrix.Dimension);

            for (int i = 0; i < nrOfWords; i++)
            {
                var encodedVector = new BitArray(_matrix.CodeLength); // parametru perduoti duomenys suskaidomi į kodo ilgio vektorius
                for (int j = 0; j < _matrix.CodeLength; j++)
                    encodedVector[j] = data[i * _matrix.CodeLength + j];
                var decodedVector = DecodeVector(encodedVector);    //kiekvienas vektorius dekoduojamas is pridedamas prie dekoduotu bitų masyvo
                for (int j = 0; j < _matrix.Dimension; j++)
                {
                    result[i * _matrix.Dimension + j] = decodedVector[j];
                }
            }
            return result.ToBytes();
        }     
        /**
         * nuo parametru perduoto bitu masyvo galo "nukerpamas" bitų skaičius lygus skirtumui tarp kodo ilgio ir dimensijos
         **/
        private BitArray RemovePostfix(BitArray vector)
        {
            BitArray result = new BitArray(_matrix.Dimension);
            for (int i = 0; i < _matrix.Dimension; i++)
                result[i] = vector[i];
            return result;
        }
        /**
         * sukuriama kontroline matrica
         **/
        private void SetControlMatrix()
        {
            _controlMatrix = new BitArray[_matrix.PostfixLength];
            for (int i = 0; i < _matrix.PostfixLength; i++)
                _controlMatrix[i] = new BitArray(_matrix.Dimension);

            for (int i = 0; i < _matrix.Dimension; i++) // generuojančios matricos ne vienetinė dalis transponuojama
                for (int j = 0; j < _matrix.PostfixLength; j++)
                    _controlMatrix[j][i] = _matrix.Matrix[i][j];
        }
        /**
        * rekursijos pagrindu įgyvendintas standartinės lentelės sudarymas.
        * recursions - kelių bitų visos variacijos bus išbandomos.
        * vector - bitų vektorius, kuriame varijuosime bitų pozicijas
        **/
        private void SetCosetLeaders(int recursions, BitArray vector)
        {
            int limit = (int)Math.Pow(2, _matrix.PostfixLength); // skaičius kiek klasių turi kodas, 2^(n-d)
            for (int i = 0; i < vector.Count; i++)
            {
                if (!vector[i]) // jei vektoriaus einamasis bitas yra 0
                {
                    var newVector = new BitArray(vector);   //susikuriame vektoriaus kopiją
                    newVector[i] = true;                    //ir joje tą patį einamąjį bitą pakeičiame į 1
                    if (recursions > 1)
                        SetCosetLeaders(recursions - 1, newVector);
                    else
                    {
                        var syndrome = GetSyndrome(newVector); // randame naujo vektoriaus sindromą 
                        if (!_cosetLeaders.Any(l => CompareBits(l.Syndrome, syndrome))) // jei tokio sindromo lentelėje dar nėra, pridedame jį kartu su klasės lyderio svoriu
                            _cosetLeaders.Add(new MinimizedStandardTableEntry { Syndrome = syndrome, Weight = GetWeight(newVector) });
                    }
                    if (_cosetLeaders.Count == limit)
                        break;
                }
            }
        }
        /**
        * palygina ar du bitų vektoriai yra lygūs
        **/
        private bool CompareBits(BitArray vector1, BitArray vector2)
        {
            if (vector1.Count != vector2.Count)
                return false;
            for (int i = 0; i < vector1.Count; i++)
                if (vector1[i] != vector2[i])
                    return false;
            return true;
        }
        /**
        * grąžina parametru perduoto bitų vektoriaus sindromą
        **/
        private BitArray GetSyndrome(BitArray vector)
        {
            var result = new BitArray(_matrix.PostfixLength);

            for(int i = 0; i < result.Count; i++) // vektorius dauginamas su kontroline matrica
            {
                bool bit = false;
                for (int j = 0; j < _matrix.Dimension; j++)
                    bit ^= (_controlMatrix[i][j] && vector[j]);
                bit ^= vector[_matrix.Dimension + i];

                result[i] = bit;
            }

            return result;
        }
        /**
        * grąžina parametru perduoto bitų vektoriaus svorį
        **/
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
