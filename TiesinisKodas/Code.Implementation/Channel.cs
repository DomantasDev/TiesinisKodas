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
        public BitArray Result { get; private set; }

        public void Send(BitArray data, int failureRate)
        {
            Random rand = new Random();

            for (int i = 0; i < data.Count; i++)
                if (rand.Next(1, 101) <= failureRate)
                    data[i] = !data[i];

            Result = data;
        }
    }
}
