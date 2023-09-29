using System.Reflection;
using Plugin.API.Extensions;
using Plugin.Core;

var builder = WebApplication.CreateBuilder(args);

var pluginDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)??string.Empty, "Plugins");

builder.Services.AddPlugins();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRegisterServices, ServiceRegistry>();
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;
builder.Services.BuildServiceProvider().GetService<IRegisterServices>().Build(services, configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
