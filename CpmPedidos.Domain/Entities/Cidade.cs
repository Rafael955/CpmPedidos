using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain
{
    public class Cidade : BaseDomain, IExibivel
    {   
        public string Nome { get; set; }
        
        public string UF { get; set; }

        public bool Ativo { get; set; }

        public override bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
