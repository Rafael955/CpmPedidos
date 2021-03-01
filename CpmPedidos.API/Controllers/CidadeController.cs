using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CpmPedidos.Domain;

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
        public async Task<dynamic> Get([FromQuery] string order)
        {
            return await GetService<ICidadeRepository>().GetOrdered(order);
        }

        [HttpPost]
        public async Task<int> Criar(CidadeDTO model)
        {
            return await GetService<ICidadeRepository>().Criar(model);
        }

        [HttpPut]
        public async Task<int> Alterar(CidadeDTO model)
        {
            return await GetService<ICidadeRepository>().Alterar(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<bool> Excluir(int id)
        {
            return await GetService<ICidadeRepository>().Excluir(id);
        }
    }
}
