using Grpc.Core;
using Grpc.Net.Client;
using Spp.Practice4.GrpcService.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7051");
var client = new Greeter.GreeterClient(channel);

while (true)
{
    Console.WriteLine("Enter manufacture id: ");
    var index = Console.ReadLine();
    
    var replies = client.SayHello(new HelloRequest { Id = int.Parse(index) });

    await foreach (var reply in replies.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine("Greeting: " + reply);
    }
}

Console.ReadKey();