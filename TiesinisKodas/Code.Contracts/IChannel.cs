using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Contracts
{
    public interface IChannel
    {
        BitArray Send(BitArray data, int failureRate);
        byte[] Send(byte[] data, int failureRate);
    }
}
