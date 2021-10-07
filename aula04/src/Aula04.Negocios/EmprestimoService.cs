using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04.Negocios
{
    public interface IEmprestimoService
    {
        bool Validar(Guid contaId, decimal valor);
    }

    public class EmprestimoService : IEmprestimoService
    {       
       public bool Validar(Guid contaId, decimal valor)
        {
            if (contaId == Guid.NewGuid())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
