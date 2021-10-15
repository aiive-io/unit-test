using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public interface IEmailService
    {

    }

    public class CadastradorDeClientesService
    {
        private readonly IEmailService _emailService;

        public CadastradorDeClientesService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void EnviarBoasVindas(string email)
        {

        }
    }
}
