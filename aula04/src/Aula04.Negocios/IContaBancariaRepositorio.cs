using System;

namespace Aula04.Negocios
{
    public interface IContaBancariaRepositorio
    {
        void Debitar(Guid id, decimal valor);
        ContaBancaria GetById(Guid id);
   }
    
}
