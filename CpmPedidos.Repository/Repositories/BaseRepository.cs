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
    public abstract class BaseRepository<T> : IBaseRepository<T> 
        where T : BaseDomain
        //where D : BaseDTO
    {
        protected const int TamanhoPagina = 5;

        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<int> Alterar(T model)
        {
            if (model.Id > 0) return 0;

            try
            {
                Context.Set<T>().Update(model);
                await Context.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public virtual async Task<int> Criar(T model)
        {
            if (model.Id > 0) return 0;

            try
            {
                Context.Set<T>().Add(model);
                await Context.SaveChangesAsync();

                return model.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public virtual async Task<bool> Excluir(int id)
        {
            if (id <= 0) return false;

            var entity = Context.Set<T>().Find(id);

            if (entity == null) return false;

            try
            {
                Context.Set<T>().Remove(entity);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }

            return true;
        }

        public virtual async Task<T> Get(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await Context.Set<T>()
              .ToListAsync();
        }
    }
}

