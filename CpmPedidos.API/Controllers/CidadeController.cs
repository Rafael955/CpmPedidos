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
        public dynamic Get([FromQuery] string order)
        {
            return GetService<ICidadeRepository>().Get(order);
        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);
        }

        [HttpPut]
        public int Alterar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Alterar(model);
        }

        [HttpDelete("{id:int}")]
        public bool Excluir(int id)
        {
            return GetService<ICidadeRepository>().Excluir(id);
        }
    }
}
