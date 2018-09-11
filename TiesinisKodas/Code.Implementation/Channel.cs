using Code.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Implementation
{
    public class Channel : IChannel
    {
        private Random _rand = new Random();

        public BitArray Send(BitArray data, double failureRate)
        {
            if (failureRate > 1 || failureRate < 0)
                throw new ArgumentException($"{nameof(failureRate)} must be a number between 0 and 100");

            for (int i = 0; i < data.Count; i++)
                if (_rand.NextDouble() < failureRate)
                    data[i] = !data[i];

            return data;
        }

        public byte[] Send(byte[] data, double failureRate)
        {
            return Send(new BitArray(data), failureRate).ToBytes();
        }
    }
}
