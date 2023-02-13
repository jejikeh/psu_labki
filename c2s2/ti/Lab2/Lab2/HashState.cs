using System.Runtime.CompilerServices;

namespace Lab2;

public class HashState
{
    public uint A;
    public uint B;
    public uint C;
    public uint D;
    public uint E;
    public HashState()
    {
        Initialize();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Initialize()
    {
        A = 0x67452301;
        B = 0xefcdab89;
        C = 0x98badcfe;
        D = 0x10325476;
        E = 0xc3d2e1f0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public byte[] ToByteArray()
    {
        var result = new byte[20];

        BigEndian.Copy(A, result);
        BigEndian.Copy(B, result.AsSpan(4));
        BigEndian.Copy(C, result.AsSpan(8));
        BigEndian.Copy(D, result.AsSpan(12));
        BigEndian.Copy(E, result.AsSpan(16));

        return result;
    }
}