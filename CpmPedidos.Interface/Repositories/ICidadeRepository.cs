using CpmPedidos.Domain;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<int> Criar(CidadeDTO model);

        Task<int> Alterar(CidadeDTO model);

        Task<dynamic> GetOrdered(string order);
    }
}
