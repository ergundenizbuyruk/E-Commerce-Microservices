using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToString().ToLower()}.json");

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

await app.UseOcelot();
app.Run();

