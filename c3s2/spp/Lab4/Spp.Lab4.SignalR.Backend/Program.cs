using Quartz;
using Spp.Lab4.SignalR.Backend.Hubs;
using Spp.Lab4.SignalR.Backend.Jobs;

var builder = WebApplication.CreateBuilder(args);

const string _allowFrontendPolicyName = "_allowFrontendPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(_allowFrontendPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddSignalR();

builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("SendAdsJob");
    q.AddJob<SendAdsJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("SendEmailJob-trigger")
        //This Cron interval can be described as "run every minute" (when second is zero)
        .WithCronSchedule("0 * * ? * *")
    );
});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();


app.MapHub<AdsHub>("/ads");
app.UseCors(_allowFrontendPolicyName);

app.Run();
