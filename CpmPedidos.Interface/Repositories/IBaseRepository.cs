using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface.Repositories
{
    public interface IBaseRepository<T> 
        where T : BaseDomain 
        //where D : BaseDTO 
    {
        Task<int> Criar(T model);
        
        Task<int> Alterar(T model);
        
        Task<bool> Excluir(int id);
       
        Task<T> Get(int id);
        
        Task<List<T>> GetAll();
    }
}
