using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ApiBaseController
    {
        public CidadeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public dynamic Get()
        {
            var repository = (ICidadeRepository)ServiceProvider.GetService(typeof(ICidadeRepository));

            return repository.Get();
        }
    }
}
