using CreditCardApi.Infrastructure;
using CreditCardApi.Application;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();
builder.Services.AddHealthChecksUI(opt =>
{
    opt.SetEvaluationTimeInSeconds(10); 
    opt.MaximumHistoryEntriesPerEndpoint(60);   
    opt.SetApiMaxActiveRequests(1); 
    opt.AddHealthCheckEndpoint("feedback SQL SERVER", "/sql/health").AddHealthCheckEndpoint("feedback API", "/api/health");

})
    .AddInMemoryStorage();

builder.Services
    .AddHttpContextAccessor()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/sql/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    AllowCachingResponses = false
});

app.MapHealthChecks("/api/health", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = async (context, report) =>
    {
        var result = JsonConvert.SerializeObject(new
        {
            status = report.Status.ToString(),
            checks = report.Entries.Select(entry => new
            {
                name = "Api endpoints",
                status = HealthStatus.Healthy,
                description = entry.Value.Description,
                tags = new[] { "Feedback", "Endpoints" }
            }),
        });

        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    },
    AllowCachingResponses = false
});


app.UseHealthChecksUI(config =>
{
    config.UIPath = "/health-ui";
});

app.Run();
