using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEC
{
    public class MyBitArray
    {
        private bool[] bits;

        public int Length { get { return bits.Length; } }
        
        public MyBitArray (MyBitArray array)
        {
            bits = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                bits[i] = array[i];
            }
        }

        public MyBitArray(int count)
        {
            bits = new bool[count];
        }

        public MyBitArray(byte[] bytes)
        {
            bits = new bool[bytes.Length * 8];
            //(bytes[0] >> 5 ) & 01
            for (int i = 0; i < bytes.Length; i++)
            {
                for (int j = 7; j >= 0; j--)
                {
                    bits[ j + (8 * (i))] = ((bytes[i] >> 7-j ) & 01) == 1;
                }
            }
        }

        public MyBitArray(int[] integers)
        {
            bits = new bool[integers.Length * 32];
            //(bytes[0] >> 5 ) & 01
            for (int i = 0; i < integers.Length; i++)
            {
                for (int j = 31; j >= 0; j--)
                {
                    bits[j + (32 * (i))] = ((integers[i] >> 31 - j) & 01) == 1;
                }
            }
        }

        // только в 1 случае используется
        public MyBitArray(bool[] _bits)
        {
            bits = new bool[8];
            for (int i = 1; i <= _bits.Length; i++)
            {
                bits[bits.Length - i] = _bits[ _bits.Length - i];
            }
        }

        public bool this[int index]
        {
            get { return bits[index]; }
            set { bits[index] = value; }
        }

        public byte[] GetBytesArray()
        {
            byte[] res;
            if (bits.Length % 8 == 0)
            {
                res = new byte[(bits.Length / 8)];
            }
            else
            {
                res = new byte[(bits.Length / 8) + 1];
            }
            

            
            for (int i = 0; i < bits.Length; i += 8)
            {
                for (int j = 0; j < 8 && j < bits.Length; j++)
                {
                    int temp = (bits[i + j]) ? 1 : 0;
                    res[i / 8] = (byte)(res[i / 8] | temp << (7 - j));
                }
            }
            return res;
        }

        public byte Get6Bit()
        {
            byte res = 0;
            for (int i = 1; i <= 6; i++)
            {
                int temp = (bits[Length - i]) ? 1 : 0;
                res = (byte)(res | temp << ((i - 1)));
            }
            return res;
        }






    }
}
