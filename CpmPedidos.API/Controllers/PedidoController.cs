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
    public class PedidoController : ApiBaseController
    {
        public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet("ticket-maximo")]
        public decimal MaxTicket()
        {
            var repository = (IPedidoRepository)ServiceProvider.GetService(typeof(IPedidoRepository));

            return repository.MaxTicket();
        }

        [HttpGet("por-cliente")]
        public dynamic ClientOrder()
        {
            var repository = (IPedidoRepository)ServiceProvider.GetService(typeof(IPedidoRepository));

            return repository.ClientOrder();
        }
    }
}
