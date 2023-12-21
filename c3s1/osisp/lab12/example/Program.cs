using System;
using System.Runtime.InteropServices;

public static class Program {
    [DllImport("s.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern string ToLower(string str);

    [DllImport("s.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern string ToUpper(string str);

    public static void Main() {
        Console.WriteLine("tolower: " + ToLower("HELLO, WORLD"));
        Console.WriteLine("toupper: " + ToUpper("hello, world"));
    }
}