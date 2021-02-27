using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface IProdutoRepository
    {
        dynamic Get(string order);
        dynamic Search(string text, int page, string order);
        dynamic Detail(int id);
        dynamic Images(int id);
    }
}
