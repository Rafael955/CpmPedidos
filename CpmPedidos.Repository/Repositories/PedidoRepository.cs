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
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {

        public PedidoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public decimal MaxTicket()
        {
            var hoje = DateTime.Today;

            return Context.Pedidos
                .Where(x => x.CriadoEm.Date == hoje)
                .Max(x => (decimal?)x.ValorTotal) ?? 0;
        }

        public dynamic ClientOrder()
        {
            var hoje = DateTime.Today;
            var inicioMes = new DateTime(hoje.Year, hoje.Month , 1);
            var finalMes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));

            var result = Context.Pedidos
                .Where(x => x.CriadoEm.Date >= inicioMes && x.CriadoEm.Date <= finalMes)
                .GroupBy(pedido => new { pedido.ClienteId, pedido.Cliente.Nome },
                (chave, pedidos) => new
                {
                    Cliente = chave.Nome,
                    Pedidos = pedidos.Count(),
                    Total = pedidos.Sum(pedido => pedido.ValorTotal)
                })
                //.GroupBy(pedido => new { pedido.ClienteId, pedido.Cliente.Nome })
                //.Select(x => new
                //{
                //    Cliente = x.Key.Nome,
                //    Pedidos = x.Count(),
                //    Total = x.Sum(p => p.ValorTotal)
                //})
                .ToList();

            return result;
        }
    }
}

