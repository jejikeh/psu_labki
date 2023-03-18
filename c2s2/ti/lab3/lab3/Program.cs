using System.Diagnostics;
using System.Numerics;

int ToInt(char c)
{
    return c - '0';
}


string RowSum(string a, string b)
{
    var result = string.Empty;
    while (a.Length > b.Length)
        b = "0" + b;
    while (b.Length > a.Length)
        a = "0" + a;

    var rem = 0;
    for (var i = a.Length - 1; i >= 0; i--)
    {
        var res = (ToInt(a[i]) + ToInt(b[i])).ToString();
        result = (ToInt(res[^1]) + rem) + result;
        if(res.Length > 1)
            rem = ToInt(res[0]);
    }

    if (rem != 0)
        result = rem + result;
    return result;
}

string RowMultiply(string a, string b)
{
    var result = string.Empty;
    var rem = 0;
    if (a.Length > b.Length)
        (a, b) = (b, a);

    foreach (var na in a.Reverse())
    {
        foreach (var nb in b.Reverse())
        {
            var res = (ToInt(nb) * ToInt(na)).ToString();
            result = (ToInt(res[^1]) + rem) + result;
            if(res.Length > 1)
                rem = ToInt(res[0]);
        }
    }

    if (rem != 0)
        result = rem + result;
    return result;
}

string RowDivide(string a, string b)
{
    var result = string.Empty;
    var rem = 0;
    if (a.Length < b.Length)
        (a, b) = (b, a);


    var i = 0;
    while(a.Length > 0)
    {
        i = 0;
        var s = a[i].ToString();
        
        while (Compare(s, b) != 1)
        {
            i += 1;
            s += a[i];
        }

        var k = 1;
        var temp = RowMultiply(b, k.ToString());
        while(Compare(s, temp) != -1)
        {
            k++;
            temp = RowMultiply(b, k.ToString());
        }

        var minus = int.Parse(s) - int.Parse(RowMultiply(b, (k - 1).ToString()));

        a = a.Replace(s, minus + s[(i + 1)..]);
        if (a.First() == '0')
            a = a[1..];
        
        result += (k - 1);
        if (a.All(x => x == '0'))
        {
            for (var l = 0; l < a.Length; l++)
                result += '0';
            
            break;
        }
    }
    
    if (rem != 0)
        result = rem + result;
    return result;
}

int Compare(string a, string b)
{
    if (a.Length > b.Length)
        return 1;
    if (b.Length > a.Length)
        return -1;

    for (var i = 0; i < a.Length; i++)
    {
        if (ToInt(a[i]) > ToInt(b[i]))
            return 1;

        if (ToInt(b[i]) > ToInt(a[i]))
            return -1;
    }

    return 0;
}

BigInteger Karacyba(BigInteger x, BigInteger y) {
    var n = Math.Max(x.GetBitLength(), y.GetBitLength());
    if (n <= 2000) 
        return x * y;
    
    n = (n / 2) + (n % 2);
    var b = x >> (int)n;
    var a = x - b << (int)(n);
    var d = y >> (int)(n);
    var c = y - d << (int)(n);
    var ac = Karacyba(a, c);
    var bd = Karacyba(b, d);
    var abcd = Karacyba(BigInteger.Add(a, b), BigInteger.Add(c, d));
    return BigInteger.Add(
        BigInteger.Add(ac, abcd - ac -  ((bd) << (int)(n))), 
        bd << (int)(2*n));
}

Console.WriteLine("RowSum: " + RowSum("534325535235", "553251414"));
Console.WriteLine("RowDivide: " + RowDivide("50332535135222", "2"));

var st = new Stopwatch();
st.Start();
Console.WriteLine("RowMultiply" + RowMultiply("3254334234234325", "5253256326326"));
st.Stop();
Console.WriteLine($"Ellsaped RowMultiply {st.ElapsedTicks}");

st.Reset();
st.Start();
Console.WriteLine(Karacyba(3254334234234325, 5253256326326));
st.Stop();
Console.WriteLine($"Ellsaped Karacyba {st.ElapsedTicks}");
