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
        void Send(BitArray data, int failureRate);
        BitArray Result { get; }
    }
}
