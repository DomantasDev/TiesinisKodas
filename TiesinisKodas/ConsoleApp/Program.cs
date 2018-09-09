using Code.Contracts;
using Code.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new GeneratingMatrix(5,3);
            matrix.GenerateStandardFormMatrix();
            PrintMatrix(matrix.Matrix);

            var code = new StraightCode(matrix);

            //var vector = new BitArray(new[] { true, false, true, false });
            //Console.Write("Vector: ");
            //PrintBitArray(vector);

            string x = "~";
            Console.Write("string:  ");
            var data = Encoding.ASCII.GetBytes(x);
            PrintBits(new BitArray(data));

            var encoded = code.EncodeData(data);
            Console.Write("Encoded: \t");
            PrintBits(encoded);

            var channel = new Channel();
            var fromChanel = channel.Send(encoded, 30);
            Console.Write("from channel: \t");
            PrintBits(fromChanel);

            var decoded = code.DecodeData(fromChanel);
            Console.Write("Decoded: \t");
            PrintBytes(decoded);
            string a = Encoding.ASCII.GetString(decoded);
            Console.Write($"Decoded string: {a}");

            Console.ReadLine();
        }

        

        private static void PrintBits(BitArray bits)
        {
            foreach (bool bit in bits)
                if (bit)
                    Console.Write(1);
                else
                    Console.Write(0);
            Console.WriteLine();
        }

        private static void PrintBytes(byte[] bytes)
        {
            PrintBits(new BitArray(bytes));
        }

        private static void PrintMatrix(BitArray[] a)
        {
            foreach (var array in a)
                PrintBits(array);
            Console.WriteLine();
        }


    }
}
