using System;

namespace Aula04.Negocios
{
    public interface IContaBancariaRepositorio
    {
        void Atualizar(ContaBancaria contaBancaria);
        ContaBancaria GetById(Guid id);
   }
    
}
