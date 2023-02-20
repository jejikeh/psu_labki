using System;

class SHA1Example
{
    static readonly uint[] K = new uint[] { 0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xCA62C1D6 };

    static uint RotateLeft(uint x, int n)
    {
        return (x << n) | (x >> (32 - n));
    }

    static uint[] CreateHash(byte[] data)
    {
        int length = data.Length;
        int pad = 40 - (length + 9) % 64;
        if (pad < 0) pad += 64;
        pad += 9;

        byte[] padded = new byte[length + pad];
        Array.Copy(data, padded, length);
        padded[length] = 0x80;
        for (int i = length + 1; i < length + pad; i++)
        {
            padded[i] = 0x00;
        }

        byte[] lengthInBits = BitConverter.GetBytes(length * 8);
        Array.Reverse(lengthInBits);
        Array.Copy(lengthInBits, 0, padded, length + pad - 4, 4);

        uint a = 0x67452301;
        uint b = 0xEFCDAB89;
        uint c = 0x98BADCFE;
        uint d = 0x10325476;
        uint e = 0xC3D2E1F0;

        for (int i = 0; i < padded.Length; i += 64)
        {
            uint[] w = new uint[80];
            for (int j = 0; j < 16; j++)
            {
                int startIndex = i + j * 4;
                if (startIndex + 4 <= padded.Length)
                {
                    w[j] = BitConverter.ToUInt32(padded, startIndex);
                }
            }

            for (int j = 16; j < 80; j++)
            {
                w[j] = RotateLeft(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1);
            }

            uint aa = a;
            uint bb = b;
            uint cc = c;
            uint dd = d;
            uint ee = e;

            for (int j = 0; j < 80; j++)
            {
                uint f, k;
                if (j < 20)
                {
                    f = (b & c) | (~b & d);
                    k = K[0];
                }
                else if (j < 40)
                {
                    f = b ^ c ^ d;
                    k = K[1];
                }
                else if (j < 60)
                {
                    f = (b & c) | (b & d) | (c & d);
                    k = K[2];
                }
                else
                {
                    f = b ^ c ^ d;
                    k = K[3];
                }

                uint temp = RotateLeft(a, 5) + f + e + k + w[j];
                e = d;
                d = c;
                c = RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            a += aa;
            b += bb;
            c += cc;
            d += dd;
            e += ee;
        }

        uint[] hash = new uint[] { a, b, c, d, e };
        return hash;
    }

    static void Main()
    {
        string input = "Hello, world!";
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

        uint[] hash = CreateHash(inputBytes);

        Console.WriteLine("The SHA-1 hash of " + input + " is:");
        foreach (uint h in hash)
        {
            Console.Write(h.ToString("x8"));
        }

        Console.WriteLine();
    }
}