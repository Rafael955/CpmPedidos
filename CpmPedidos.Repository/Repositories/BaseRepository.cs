using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository.Repositories
{
    public abstract class BaseRepository<T> where T : class
    {
        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}

