using System.Security.Cryptography;

class SHA1Example
{
    static readonly uint[] K = new uint[] { 0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xCA62C1D6 };

    private static uint RotateLeft(uint value, int count)
    {
        return (value << count) | (value >> (32 - count));
    }

    private static byte[] PadMessage(byte[] message)
    {
// Добавление бита "1" в конец сообщения
        byte[] padded = new byte[message.Length + 1];
        Array.Copy(message, 0, padded, 0, message.Length);
        padded[message.Length] = 0x80;
        // Добавление нулей в конец сообщения до кратности 512 битам
        int paddingSize = (56 - (message.Length + 1) % 64 + 64) % 64;
        byte[] padding = new byte[paddingSize];
        Array.Clear(padding, 0, paddingSize);
        byte[] length = GetBytes((ulong)message.Length * 8);
        Array.Resize(ref padded, padded.Length + paddingSize + length.Length);
        Array.Copy(padding, 0, padded, message.Length + 1, paddingSize);
        Array.Copy(length, 0, padded, padded.Length - length.Length, length.Length);

        return padded;
    }
    private static byte[] GetBytes(uint value)
    {
        byte[] bytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            bytes[i] = (byte)(value >> (24 - i * 8));
        }
        return bytes;
    }
    
    private static byte[] GetBytes(ulong value)
    {
        byte[] bytes = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            bytes[i] = (byte)(value >> (56 - i * 8));
        }
        return bytes;
    }

    public static byte[] Sha1(byte[] message)
    {
        // Дополнение сообщения
        var padded = PadMessage(message);

        // Инициализация переменных
        byte[] hash = new byte[20];
        uint h0 = 0x67452301;
        uint h1 = 0xEFCDAB89;
        uint h2 = 0x98BADCFE;
        uint h3 = 0x10325476;
        uint h4 = 0xC3D2E1F0;

        // Обработка блоков сообщения
        for (int i = 0; i < padded.Length; i += 64)
        {
            // Разбивка блока на слова
            uint[] w = new uint[80];
            for (int j = 0; j < 16; j++)
            {
                w[j] = (uint)((padded[i + j * 4] << 24) | (padded[i + j * 4 + 1] << 16) | (padded[i + j * 4 + 2] << 8) |
                              padded[i + j * 4 + 3]);
            }

            for (int j = 16; j < 80; j++)
            {
                w[j] = RotateLeft(w[j - 3] ^ w[j - 8] ^ w[j - 14] ^ w[j - 16], 1);
            }

            // Инициализация временных переменных
            uint a = h0;
            uint b = h1;
            uint c = h2;
            uint d = h3;
            uint e = h4;

            // Основной цикл
            for (int j = 0; j < 80; j++)
            {
                uint f, k;
                if (j < 20)
                {
                    f = (b & c) | ((~b) & d);
                    k = 0x5A827999;
                }
                else if (j < 40)
                {
                    f = b ^ c ^ d;
                    k = 0x6ED9EBA1;
                }
                else if (j < 60)
                {
                    f = (b & c) | (b & d) | (c & d);
                    k = 0x8F1BBCDC;
                }
                else
                {
                    f = b ^ c ^ d;
                    k = 0xCA62C1D6;
                }

                uint temp = RotateLeft(a, 5) + f + e + k + w[j];
                e = d;
                d = c;
                c = RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Обновление значений хэш-функции
            h0 = h0 + a;
            h1 = h1 + b;
            h2 = h2 + c;
            h3 = h3 + d;
            h4 = h4 + e;
        }

        // Формирование итогового хэша
        byte[] result = new byte[20];
        Array.Copy(GetBytes(h0), 0, result, 0, 4);
        Array.Copy(GetBytes(h1), 0, result, 4, 4);
        Array.Copy(GetBytes(h2), 0, result, 8, 4);
        Array.Copy(GetBytes(h3), 0, result, 12, 4);
        Array.Copy(GetBytes(h4), 0, result, 16, 4);

        return result;
    }


    static void Main()
    {
        string input = "Hello world!";
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

        byte[] hash = Sha1(inputBytes);
        
        Console.WriteLine("The SHA-1 hash of " + input + " is:");
        foreach (var h in hash)
            Console.Write(h.ToString("x8"));
        
        RSAParameters sharedParameters;
        byte[] signedHash;
        using (RSA rsa = RSA.Create())
        {
            sharedParameters = rsa.ExportParameters(false);

            RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
            rsaFormatter.SetHashAlgorithm(nameof(SHA1));

            signedHash = rsaFormatter.CreateSignature(hash);
        }
        
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportParameters(sharedParameters);

            RSAPKCS1SignatureDeformatter rsaDeformatter = new(rsa);
            rsaDeformatter.SetHashAlgorithm(nameof(SHA1));

            if (rsaDeformatter.VerifySignature(hash, signedHash))
                Console.WriteLine("The signature is valid.");
            else
                Console.WriteLine("The signature is not valid.");
        }
    }
}