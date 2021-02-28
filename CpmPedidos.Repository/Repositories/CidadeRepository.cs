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

        public dynamic Get(string order)
        {
            var result = Context.Cidades
                .Where(x => x.Ativo)
                .OrderCitiesByName(order)
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

        public int Criar(CidadeDTO model)
        {
            if (model.Id > 0) return 0;

            var nomeDuplicado = Context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper());

            if (nomeDuplicado) return 0;

            var entity = new Cidade()
            {
                Nome = model.Nome,
                UF = model.UF,
                Ativo = model.Ativo
            };

            try
            {
                Context.Cidades.Add(entity);
                Context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public int Alterar(CidadeDTO model)
        {
            if (model.Id <= 0) return 0;

            var entity = Context.Cidades.Find(model.Id);

            if (entity == null) return 0;

            var nomeDuplicado = Context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper() && x.Id != model.Id);

            if (nomeDuplicado) return 0;

            entity.Nome = model.Nome;
            entity.UF = model.UF;
            entity.Ativo = model.Ativo;

            try
            {
                Context.Cidades.Update(entity);
                Context.SaveChanges();

                return entity.Id;
            }
            catch (Exception ex)
            {
            }

            return 0;
        }

        public bool Excluir(int id)
        {
            if (id <= 0) return false;

            var cidade = Context.Cidades.Find(id);

            if (cidade == null) return false;

            try
            {
                Context.Cidades.Remove(cidade);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
           
            return true;
        }
    }
}

