using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<dynamic> GetOrdered(string order);
        Task<dynamic> Search(string text, int page, string order);
        Task<dynamic> Detail(int id);
        Task<dynamic> Images(int id);
    }
}
