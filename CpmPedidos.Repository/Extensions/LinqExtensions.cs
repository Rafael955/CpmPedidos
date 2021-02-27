using CpmPedidos.Domain;
using CpmPedidos.Repository.Enums;
using System.Linq;

namespace CpmPedidos.Repository.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<Produto> OrderByName(this IQueryable<Produto> query, string order)
        {
            if (string.IsNullOrEmpty(order) || order.ToUpper() == QueryOrder.ASC)
                query = query.OrderBy(x => x.Nome);
            else if (order.ToUpper() == QueryOrder.DESC)
                query = query.OrderByDescending(x => x.Nome);

            return query;
        }
    } 
}

