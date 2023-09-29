using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Plugin.Core;

public interface IRegister
{
    void Register(IServiceCollection services, IConfiguration configuration);
}
