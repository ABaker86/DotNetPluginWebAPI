using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Plugin.Core;

public interface IRegisterServices
{
    void Build(IServiceCollection services, IConfiguration configuration);
}
