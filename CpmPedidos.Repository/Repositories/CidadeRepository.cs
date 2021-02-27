using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {

        public CidadeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public dynamic Get()
        {
            var result = Context.Cidades
                .Where(x => x.Ativo)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.UF,
                    x.Ativo
                })
                .ToList();

            return result;
        }
    }
}

