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
        public async Task<dynamic> Get([FromQuery] string order = "")
        {
            var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return await repository.GetOrdered(order);
        }

        [HttpGet("busca/{text}/{page?}")]
        public async Task<dynamic> GetSearch(string text, int page = 1, [FromQuery] string order = "")
        {
            var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return await repository.Search(text, page, order);
        }

        [HttpGet("{id:int?}")]
        public async Task<dynamic> Detail(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

                return await repository.Detail(id.Value);
            }

            return null;
        }

        [HttpGet("{id:int?}/imagens")]
        public async Task<dynamic> Images(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

                return await repository.Images(id.Value);
            }

            return null;
        }

        [HttpPost]
        public async Task<int> Criar(Produto produto)
        {
            var repository = (IProdutoRepository)ServiceProvider.GetService(typeof(IProdutoRepository));

            return await repository.Criar(produto);
        }
    }
}
