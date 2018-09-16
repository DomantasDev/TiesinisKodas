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
     * realizuoją duomenų kanalo abstrakciją
     **/
    public class Channel : IChannel
    {
        private Random _rand = new Random();

        /**
         * imituoja bitų masyvo siuntima kanalu su pasirinkta klaidos tikimybe,
         * gražiną per kanalą praėjusį bitų masyvą
         **/
        public BitArray Send(BitArray data, double failureRate)
        {
            if (failureRate > 1 || failureRate < 0)
                throw new ArgumentException($"{nameof(failureRate)} must be a number between 0 and 100");

            for (int i = 0; i < data.Count; i++)
                if (_rand.NextDouble() < failureRate)
                    data[i] = !data[i];

            return data;
        }
        /**
         * imituoja bitų masyvo siuntima kanalu su pasirinkta klaidos tikimybe,
         * gražina per kanalą praėjusį bitų masyvą.
         * failures - masyvas pozicijų, kuriuose ivyko klaidos
         **/
        public BitArray Send(BitArray data, double failureRate, out List<int> failures)
        {
            if (failureRate > 1 || failureRate < 0)
                throw new ArgumentException($"{nameof(failureRate)} must be a number between 0 and 100");

            failures = new List<int>();
            for (int i = 0; i < data.Count; i++)
                if (_rand.NextDouble() < failureRate)
                {
                    data[i] = !data[i];
                    failures.Add(i + 1);
                }
            return data;
        }
        /**
         * imituoja baitų masyvo siuntima kanalu su pasirinkta klaidos tikimybe,
         * gražiną per kanalą praėjusį baitų masyvą
         **/
        public byte[] Send(byte[] data, double failureRate)
        {
            return Send(new BitArray(data), failureRate).ToBytes();
        }
    }
}
