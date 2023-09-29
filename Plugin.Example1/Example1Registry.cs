using Plugin.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Plugin.Example1;

public class Example1Registry : IRegister
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IStandardRepository, InMemoryClientAddressRepository>();
    }
}