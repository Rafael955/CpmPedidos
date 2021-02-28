using CpmPedidos.Domain;

namespace CpmPedidos.Interface.Repositories
{
    public interface ICidadeRepository
    {
        dynamic Get(string order);
        int Criar(CidadeDTO model);
        int Alterar(CidadeDTO model);
        bool Excluir(int id);
    }
}
