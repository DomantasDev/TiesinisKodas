using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Contracts
{
    public interface ICode
    {
        BitArray EncodeVector(BitArray vector);       
        BitArray DecodeVector(BitArray data);

        BitArray EncodeData(byte[] data);
        byte[] DecodeData(BitArray data);
    }
}
