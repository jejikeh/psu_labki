namespace Lab6.Parts;

public static class RsaCrypt
{
    public static int gcd(int a, int b)
    {
        while (a != 0 && b != 0)
        {
            if (a > b)
                a %= b;
            else
                b %= a;
        }

        return a | b;
    }
    
    public static List<int> SetPrimes(int length)
    {
        var boolMap = new bool[length];
        boolMap[0] = true;
        boolMap[1] = true;
        for (var i = 2; i < length; i++) 
            for (var j = i * 2; j < length; j += i)
                boolMap[j] = true;

        var prime = new List<int>();
        for (var i = 0; i < boolMap.Length; i++)
            if (!boolMap[i])
                prime.Add(i);

        return prime;
    }

    private static int PickRandomPrime(ref List<int> primeList)
    {
        var random = new Random();
        if (primeList.Count == 0)
            return 0;
        
        var k = random.Next(0, primeList.Count);
        var ret = primeList[k];
        primeList.RemoveAt(k);
        return ret;
    }
    
    private static int PickRandomPrime(List<int> primeList)
    {
        var random = new Random();
        if (primeList.Count == 0)
            return 0;
        
        var k = random.Next(0, primeList.Count);
        var ret = primeList[k];
        return ret;
    }

    private static int Encrypt(double message, int publicKey, int n)
    {
        var e = publicKey;
        var encryptedText = 1;
        while (e-- > 0)
            encryptedText = (int)(encryptedText * message % n);
        
        return encryptedText;
    }
    
    public static long Decrypt(int encryptedText, int privateKey, int n)
    {
        var d = privateKey;
        var decrypted = 1;
        while (d-- > 0)
            decrypted = (decrypted * encryptedText) % n;
        
        return decrypted;
    }
    
    public static List<int> Encoder(string message, int publicKey, int n)
    {
        return message.Select(letter => Encrypt(letter, publicKey, n)).ToList();
    }

    public static string Decoder(List<int> encoded, int privateKey, int n)
    {
        var s = string.Empty;
        foreach (var i in encoded)
            s += (char)Decrypt(i, privateKey, n);

        return s;
    }
    
    public static (int, int, int) SetKeys(List<int> primeList)
    {
        var prime1 = PickRandomPrime(ref primeList);
        var prime2 = PickRandomPrime(ref primeList);

        var n = prime1 * prime2;
        var fi = (prime1 - 1) * (prime2 - 1);
        var e = 2;

        while (true)
        {
            if (gcd(e, fi) == 1)
                break;

            e++;
        }

        var publicKey = e;
        var d = 2;
        while (true)
        {
            if (d * e % fi == 1)
                break;

            d++;
        }

        var privateKey = d;
        return (publicKey, privateKey, n);
    }
    
    public static (int, int) Crack(List<int> primeList, int publicKey, int n)
    {
        var prime1 = PickRandomPrime(primeList);
        var prime2 = PickRandomPrime(primeList);

        while (n != prime1 * prime2)
        {
            prime1 = PickRandomPrime(primeList);
            prime2 = PickRandomPrime(primeList);
            Console.WriteLine($"guessing the prime1: {prime1} and prime2: {prime2}");
        }

        var fi = (prime1 - 1) * (prime2 - 1);

        var d = 2;
        while (true)
        {
            if (d * publicKey % fi == 1 || d < 0)
                break;

            d++;
            Console.WriteLine($"{d} current private_key");
        }

        return (d, n);
    }
}