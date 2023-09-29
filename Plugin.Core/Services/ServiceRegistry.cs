using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Core
{

    public sealed class ServiceRegistry : IRegisterServices
    {
        private IEnumerable<IRegister> _Registeries;
        public ServiceRegistry(IEnumerable<IRegister> registeries)
        {
            _Registeries = registeries ?? throw new ArgumentNullException(nameof(registeries));
        }

        public void Build(IServiceCollection services, IConfiguration configuration) =>
            _Registeries.ToList().ForEach(x => { x.Register(services, configuration); });
    }

}