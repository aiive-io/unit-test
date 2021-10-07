using System;

namespace Aula04.Negocios
{
    public interface IChequeEspecialRepositorio
    {
        bool ValidarEmprestimo(Guid id, decimal valor);
        void CriarEmprestimo (Guid id, decimal valor);
    }
    
}
