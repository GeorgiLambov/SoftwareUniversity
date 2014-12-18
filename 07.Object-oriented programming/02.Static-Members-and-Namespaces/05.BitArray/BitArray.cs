using System;
using System.Numerics;

class BitArray
{
    private byte[] bits;

    public BitArray(int p)
    {
        if (p < 0 || p > 100000)
        {
            throw new IndexOutOfRangeException("The value must be in range [1....100000]!!!");
        }
        this.bits = new byte[p];
    }
    public byte this[int index]
    {
        get { return this.bits[index]; }
        set
        {
            if (index < 0 || index > this.bits.Length - 1)
            {
                throw new IndexOutOfRangeException("The value must be in range [0...." + (this.bits.Length - 1) + "]!!!");
            }
            if (value != 0 && value != 1)
            {
                throw new IndexOutOfRangeException("The value must be 1 or 0!");
            }

            this.bits[index] = value;
        }
    }
    public override string ToString()
    {
        BigInteger number = 0;
        for (int i = 0; i < this.bits.Length; i++)
        {
            if (this.bits[i] == 1)
            {
                number += BigInteger.Pow(2, i);
            }

        }

        return number.ToString();
    }

}

