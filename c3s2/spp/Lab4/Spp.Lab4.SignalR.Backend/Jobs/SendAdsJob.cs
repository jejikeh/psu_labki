using Microsoft.AspNetCore.SignalR;
using Quartz;
using Spp.Lab4.SignalR.Backend.Hubs;

namespace Spp.Lab4.SignalR.Backend.Jobs;

public class SendAdsJob(IHubContext<AdsHub> _adsHubContext) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Sending ads");

        await _adsHubContext.Clients.All.SendAsync("ReceiveAds", $"Hello, im an ad with {Guid.NewGuid()}");
    }
}