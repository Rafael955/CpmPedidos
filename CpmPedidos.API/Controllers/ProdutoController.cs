using CpmPedidos.Domain;
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
    public class ProdutoController : ApiBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet]
        public dynamic Get([FromQuery] string order = "")
        {
            var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return repository.Get(order);
        }

        [HttpGet("busca/{text}/{page?}")]
        public dynamic GetSearch(string text, int page = 1, [FromQuery] string order = "")
        {
            var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return repository.Search(text, page, order);
        }

        [HttpGet("{id:int?}")]
        public dynamic Detail(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

                return repository.Detail(id.Value);
            }

            return null;
        }

        [HttpGet("{id:int?}/imagens")]
        public dynamic Images(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

                return repository.Images(id.Value);
            }

            return null;
        }
    }
}
