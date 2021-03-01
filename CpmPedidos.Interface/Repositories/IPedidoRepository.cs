using CpmPedidos.Domain;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        Task<decimal> MaxTicket();
        Task<dynamic> ClientOrder();
    }
}
