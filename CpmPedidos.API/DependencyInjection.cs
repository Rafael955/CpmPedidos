using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmPedidos.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependency(serviceProvider);
        }

        private static void RepositoryDependency(IServiceCollection serviceProvider)
        {

        }
    }
}
