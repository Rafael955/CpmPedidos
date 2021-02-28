using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CpmPedidos.API.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        protected readonly IServiceProvider ServiceProvider;

        public ApiBaseController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
