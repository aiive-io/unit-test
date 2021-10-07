using System;

namespace Aula04.Negocios
{
    public interface IContaBancariaService
    {
        void Debitar(Guid id, decimal valor);
    }
    
}
