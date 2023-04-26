// See https://aka.ms/new-console-template for more information

using Lab6.Parts;

bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));
          
    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}

var primes = RsaCrypt.SetPrimes(250);

foreach(var r in primes)
    Console.Write(r + " ");


Console.WriteLine("Generating keys...");
var keys = RsaCrypt.SetKeys(primes);

// OR Input from keyboard
// Console.WriteLine("Input the public Key from keyboard");
// var publicKey = Console.ReadLine();
// while (true)
// {
//     publicKey = Console.ReadLine();
//     if(!int.TryParse(publicKey, out var n))
//         continue;
//     
//     if(!IsPrime(n))
//         continue;
// 
//     break;
// }

Console.WriteLine($"public_key:\t{keys.Item1}\n" +
                  $"private_key:\t{keys.Item2}\n" +
                  $"n:\t{keys.Item3}\n");

Console.WriteLine("Please, input the file_path: ");
var inputFilePath = Console.ReadLine();
while(inputFilePath == string.Empty)
    inputFilePath = Console.ReadLine();

var inputMessage = File.ReadAllText(inputFilePath!);
var encodingList = RsaCrypt.Encoder(inputMessage, keys.Item1, keys.Item3);
Console.WriteLine("The encoded message: \n");

foreach(var k in encodingList)
    Console.Write(k + " ");

var decodingText = RsaCrypt.Decoder(encodingList, keys.Item2, keys.Item3);
Console.WriteLine("\nThe decrypted text is: \n" +
                  decodingText);

while (true)
{
    Console.WriteLine("Please, input the R key");
    var key = Console.ReadLine();
    switch (key)
    {
        case "R":
            var tryCrackKeys = RsaCrypt.Crack(RsaCrypt.SetPrimes(250), keys.Item1, keys.Item3);
            Console.WriteLine($"public_key: {keys.Item1}\nprivate_key: {tryCrackKeys.Item1}\nn: {tryCrackKeys.Item2}");
            Console.WriteLine($"Decoded message: {RsaCrypt.Decoder(encodingList, tryCrackKeys.Item1, tryCrackKeys.Item2)}");
            break;
    }
}
