using Grpc.Core;
using Spp.Practice4.GrpcService.Server;

namespace Spp.Practice4.GrpcService.Server.Services;

public class Worker
{
    public string Name { get; set; }
    public int ManufactureId { get; set; }
}

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;

    private static List<Worker> GenerateMockedWorkers()
    {
        var workers = new List<Worker>();
        for (var i = 0; i < 100; i++)
        {
            workers.Add(new Worker { Name = $"Worker {Random.Shared.Next(10)}", ManufactureId = Random.Shared.Next(10) });
        }

        return workers;
    }
    
    private static List<Worker> _workers = GenerateMockedWorkers();

    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task SayHello(HelloRequest request, IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
    {
        foreach (var worker in _workers.Where(x => x.ManufactureId == request.Id))
        {
            _logger.LogInformation(worker.Name);
            responseStream.WriteAsync(new HelloReply
            {
                Message = $"Hello, {worker.Name} from {worker.ManufactureId} Manufacture"
            });
        }
        
        return Task.CompletedTask;
    }
}