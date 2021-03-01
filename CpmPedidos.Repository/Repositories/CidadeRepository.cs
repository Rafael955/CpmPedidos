using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using CpmPedidos.Repository.Extensions;
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

        public async Task<dynamic> GetOrdered(string order)
        {
            var result = await Context.Cidades
                .Where(x => x.Ativo)
                .OrderCitiesByName(order)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.UF,
                    x.Ativo
                })
                .ToListAsync();

            return result;
        }

        public async Task<int> Criar(CidadeDTO model)
        {
            if (model.Id > 0) return 0;

            var nomeDuplicado = Context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper());

            if (nomeDuplicado) return 0;

            var entity = new Cidade(model.Nome, model.UF, model.Ativo);
          
            try
            {
                Context.Cidades.Add(entity);
                await Context.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public async Task<int> Alterar(CidadeDTO model)
        {
            if (model.Id <= 0) return 0;

            var entity = Context.Cidades.Find(model.Id);

            if (entity == null) return 0;

            var nomeDuplicado = Context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper() && x.Id != model.Id);

            if (nomeDuplicado) return 0;

            entity.AlterarNome(model.Nome);
            entity.AlterarUF(model.UF);
            entity.AlterarStatus(model.Ativo);

            try
            {
                Context.Cidades.Update(entity);
                await Context.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }
    }
}

